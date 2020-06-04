using AutoMapper;
using PowerLifting.Service.Users.DTO;
using PowerLifting.Service.Users.Model;

namespace PowerLifting.Service.Users.AutoMapper
{
    public class UserMappingProfile : Profile
    {
        public UserMappingProfile()
        {
            //Users
            CreateMap<User, UserDTO>();
            CreateMap<UserDTO, User>();
            CreateMap<RegisterUserDTO, User>();
            CreateMap<User, RegisterUserDTO>();
            CreateMap<NewUserDTO, User>();
            CreateMap<User, NewUserDTO>();
        }
    }
}
