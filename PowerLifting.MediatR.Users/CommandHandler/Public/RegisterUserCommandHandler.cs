using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using PowerLifting.Data.DTOs.Account;
using PowerLifting.Data.DTOs.System;
using PowerLifting.Data.Entities.Account;
using PowerLifting.Data.Entities.Exercises;
using PowerLifting.Data.Entities.LiftingStats;
using PowerLifting.Data.Exceptions.Account;
using PowerLifting.MediatR.Users.Command.Public;
using PowerLifting.MediatR.Users.Query.Account;
using PowerLifting.Persistence;

namespace PowerLifting.MediatR.Users.CommandHandler.Public
{
    public class RegisterUserCommandHandler : IRequestHandler<RegisterUserCommand, bool>
    {
        private readonly PowerLiftingContext _context;
        private readonly IMapper _mapper;
        private readonly UserManager<User> _userManager;
        public RegisterUserCommandHandler(PowerLiftingContext context, IMapper mapper, UserManager<User> userManager)
        {
            _context = context;
            _mapper = mapper;
            _userManager = userManager;
        }

        public async Task<bool> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
        {
            if (string.IsNullOrEmpty(request.RegisterUserDTO.Email)) throw new UserValidationException("Email cannot be empty");
            if (string.IsNullOrEmpty(request.RegisterUserDTO.Password)) throw new UserValidationException("Password cannot be empty");
            if (string.IsNullOrEmpty(request.RegisterUserDTO.UserName)) throw new UserValidationException("UserName cannot be empty");

            var doesUserExist = await _context.User.AsNoTracking().AnyAsync(x => x.Email == request.RegisterUserDTO.Email || x.NormalizedUserName == request.RegisterUserDTO.UserName.ToUpper());
            if (doesUserExist) throw new EmailOrUserNameInUseException();

            var userEntity = _mapper.Map<User>(request.RegisterUserDTO);

            userEntity.UserSetting = new UserSetting()
            {
                UserId = userEntity.Id
            };

            var result = await _userManager.CreateAsync(userEntity, request.RegisterUserDTO.Password);

            if (result.Succeeded)
            {
                var exercisesToAdd = await _context.Set<Exercise>()
                    .Where(x => x.ExerciseSports.Any(j => j.ExerciseSportStr == request.RegisterUserDTO.SportType) && x.IsApproved)
                    .ProjectTo<TopLevelExerciseDTO>(_mapper.ConfigurationProvider)
                    .AsNoTracking()
                    .ToListAsync(cancellationToken: cancellationToken);

                var repRanges = new int[] { 1, 2, 3, 5, 10 };
                foreach (var exercise in exercisesToAdd)
                {
                    foreach (var repRange in repRanges)
                    {
                        _context.LiftingStat.Add(
                            new LiftingStat()
                            {
                                UserId = userEntity.Id,
                                ExerciseId = exercise.ExerciseId,
                                RepRange = repRange,
                                LastUpdated = DateTime.UtcNow
                            });
                    }
                }

                await _context.SaveChangesAsync(cancellationToken);
            }
            return result.Succeeded;
        }
    }
}