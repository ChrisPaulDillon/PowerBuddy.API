using System;
using AutoMapper;
using PowerLifting.Service.Users.Model;
using PowerLifting.WebApp.Models;

namespace PowerLifting.WebApp
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<UserRegistrationModel, User>()
                .ForMember(u => u.UserName, opt => opt.MapFrom(x => x.Email));
        }
    }
}
