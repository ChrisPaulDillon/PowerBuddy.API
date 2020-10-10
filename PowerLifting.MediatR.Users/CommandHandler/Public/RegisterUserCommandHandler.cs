using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using PowerLifting.Data;
using PowerLifting.Data.DTOs.System;
using PowerLifting.Data.Entities;
using PowerLifting.Data.Exceptions.Account;
using PowerLifting.MediatR.Users.Command.Public;

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
            //if (!Enum.IsDefined(typeof(SportEnum), request.RegisterUserDTO.SportType.ToUpper())) throw new UserValidationException("Incorrect Sport");

            var doesUserExist = await _context.User.AsNoTracking().AnyAsync(x => x.Email == request.RegisterUserDTO.Email || x.NormalizedUserName == request.RegisterUserDTO.UserName.ToUpper(), cancellationToken: cancellationToken);
            if (doesUserExist) throw new EmailOrUserNameInUseException();

            request.RegisterUserDTO.SportType = "PowerLifting";

            var userEntity = _mapper.Map<User>(request.RegisterUserDTO);
            userEntity.MemberStatusId = 1;

            userEntity.UserSetting = new UserSetting()
            {
                UserId = userEntity.Id
            };

            var result = await _userManager.CreateAsync(userEntity, request.RegisterUserDTO.Password);

            if (result.Succeeded)
            {
                var exercisesToAdd = await _context.Set<Exercise>() //temp
                    .Where(x => x.ExerciseSports.Any(j => j.ExerciseSportStr.ToLower().Equals("PowerLifting".ToLower())) && x.IsApproved)
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