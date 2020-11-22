﻿using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using PowerBuddy.Context;
using PowerBuddy.Data.DTOs.Account;

namespace PowerBuddy.MediatR.FriendsLists.Querys.Account
{
    public class GetUserFriendsListQuery : IRequest<IEnumerable<FriendsListAssocDTO>>
    {
        public string UserId { get; }
        public GetUserFriendsListQuery(string userId)
        {
            UserId = userId;
        }
    }
    public class GetUserFriendsListQueryHandler : IRequestHandler<GetUserFriendsListQuery, IEnumerable<FriendsListAssocDTO>>
    {
        private readonly PowerLiftingContext _context;
        private readonly IMapper _mapper;
        public GetUserFriendsListQueryHandler(PowerLiftingContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<FriendsListAssocDTO>> Handle(GetUserFriendsListQuery request, CancellationToken cancellationToken)
        {
            return await _context.FriendsListAssoc.Where(x => x.UserId == request.UserId || x.OtherUserId == request.UserId)
                .AsNoTracking()
                .ProjectTo<FriendsListAssocDTO>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken: cancellationToken);
        }
    }
}