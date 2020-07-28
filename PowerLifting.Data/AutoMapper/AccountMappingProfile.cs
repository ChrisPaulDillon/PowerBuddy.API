using AutoMapper;
using PowerLifting.Data.DTOs.Account;
using PowerLifting.Data.Entities.Account;

namespace PowerLifting.Data.AutoMapper
{
    public class AccountMappingProfile : Profile
    {
        public AccountMappingProfile()
        {
            CreateMap<User, UserDTO>().ReverseMap();
            CreateMap<RegisterUserDTO, User>().ReverseMap();
            CreateMap<NewUserDTO, User>().ReverseMap();
            CreateMap<UserSetting, UserSettingDTO>().ReverseMap();
            CreateMap<User, PublicUserDTO>().ReverseMap();

            CreateMap<NotificationDTO, Notification>().ReverseMap();
            CreateMap<NotificationInteraction, NotificationInteractionDTO>().ReverseMap();

            CreateMap<FriendRequest, FriendRequestDTO>().ReverseMap();
            CreateMap<FriendsListAssoc, FriendsListAssocDTO>().ReverseMap();
        }
    }
}
