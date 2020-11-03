using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using PowerLifting.Data.DTOs.Account;
using PowerLifting.Data.DTOs.Users;
using PowerLifting.Data.Entities;

namespace PowerLifting.Data.AutoMapper
{
    public class FriendsListMappingProfile : Profile
    {
        public FriendsListMappingProfile()
        {
            CreateMap<FriendRequest, FriendRequestDTO>()
                .ForMember(x => x.FriendRequestId, d => d.MapFrom(src => src.FriendRequestId))
                .ForMember(x => x.UserFromId, d => d.MapFrom(src => src.UserFromId))
                .ForMember(x => x.UserToId, d => d.MapFrom(src => src.UserToId))
                .ForMember(x => x.HasAccepted, d => d.MapFrom(src => src.HasAccepted))
                .ReverseMap();
        }
    }
}