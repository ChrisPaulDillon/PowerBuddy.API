using AutoMapper;
using PowerLifting.Entity.Users.DTO;
using PowerLifting.Entity.Users.Model;
using PowerLifting.Service.Users.DTO;
using PowerLifting.Service.Users.Model;
using PowerLifting.Service.UserSettings.DTO;
using PowerLifting.Service.UserSettings.Model;

namespace PowerLifting.Service.Users.AutoMapper
{
    public class UserMappingProfile : Profile
    {
        public UserMappingProfile()
        {
            //Users
            CreateMap<User, UserDTO>().ReverseMap();
            CreateMap<RegisterUserDTO, User>().ReverseMap();
            CreateMap<NewUserDTO, User>().ReverseMap();
            CreateMap<UserSetting, UserSettingDTO>().ReverseMap();
            CreateMap<User, PublicUserDTO>().ReverseMap();

            CreateMap<NotificationDTO, Notification>().ReverseMap();
            CreateMap<NotificationInteraction, NotificationInteractionDTO>().ReverseMap();

        }
    }
}
