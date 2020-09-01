using AutoMapper;
using PowerLifting.Data.DTOs.Account;
using PowerLifting.Data.DTOs.Users;
using PowerLifting.Data.Entities.Account;

namespace PowerLifting.Data.AutoMapper
{
    public class AccountMappingProfile : Profile
    {
        public AccountMappingProfile()
        {
            CreateMap<User, UserDTO>()
                .ForMember(x => x.UserId, d => d.MapFrom(src => src.Id))
                .ForMember(x => x.UserName, d => d.MapFrom(src => src.UserName))
                .ForMember(x => x.BodyWeight, d => d.MapFrom(src => src.BodyWeight))
                .ForMember(x => x.QuotesEnabled, d => d.MapFrom(src => src.QuotesEnabled))
                .ForMember(x => x.Email, d => d.MapFrom(src => src.Email))
                .ForMember(x => x.LiftingLevel, d => d.MapFrom(src => src.LiftingLevel))
                .ForMember(x => x.Gender, d => d.MapFrom(src => src.Gender))
               .ForMember(x => x.FirstName, d => d.MapFrom(src => src.FirstName))
                .ForMember(x => x.LastName, d => d.MapFrom(src => src.LastName))
                .ForMember(x => x.LiftingStatId, d => d.MapFrom(src => src.LiftingStatId))
                .ForMember(x => x.SportType, d => d.MapFrom(src => src.SportType))
                .ForMember(x => x.FirstVisit, d => d.MapFrom(src => src.FirstVisit))
                .ReverseMap();

            CreateMap<RegisterUserDTO, User>()
                .ForMember(x => x.UserName, d => d.MapFrom(src => src.UserName))
                .ForMember(x => x.PasswordHash, d => d.MapFrom(src => src.Password))
                .ForMember(x => x.Email, d => d.MapFrom(src => src.Email))
                .ForMember(x => x.SportType, d => d.MapFrom(src => src.SportType))
                .ReverseMap();

            CreateMap<User, PublicUserDTO>()
                .ForMember(x => x.UserId, d => d.MapFrom(src => src.Id))
                .ForMember(x => x.UserName, d => d.MapFrom(src => src.UserName))
                .ForMember(x => x.SportType, d => d.MapFrom(src => src.SportType))
                .ForMember(x => x.BodyWeight, d => d.MapFrom(src => src.BodyWeight))
                .ForMember(x => x.IsPublic, d => d.MapFrom(src => src.IsPublic))
                .ForMember(x => x.Rights, d => d.MapFrom(src => src.Rights))
                .ForMember(x => x.Gender, d => d.MapFrom(src => src.Gender))
                .ForMember(x => x.LiftingLevel, d => d.MapFrom(src => src.LiftingLevel))
                .ReverseMap();

            CreateMap<User, AdminUserDTO>()
                .ForMember(x => x.UserId, d => d.MapFrom(src => src.Id))
                .ForMember(x => x.UserName, d => d.MapFrom(src => src.UserName))
                .ForMember(x => x.Email, d => d.MapFrom(src => src.Email))
                .ForMember(x => x.FirstName, d => d.MapFrom(src => src.FirstName))
                .ForMember(x => x.LastName, d => d.MapFrom(src => src.LastName))
                .ForMember(x => x.LiftingStatId, d => d.MapFrom(src => src.LiftingStatId))
                .ForMember(x => x.SportType, d => d.MapFrom(src => src.SportType))
                .ForMember(x => x.IsPublic, d => d.MapFrom(src => src.IsPublic))
                .ForMember(x => x.IsBanned, d => d.MapFrom(src => src.IsBanned))
                .ReverseMap();

            CreateMap<UserSetting, UserSettingDTO>().ReverseMap();

            CreateMap<NotificationDTO, Notification>().ReverseMap();
            CreateMap<NotificationInteraction, NotificationInteractionDTO>().ReverseMap();

            CreateMap<FriendRequest, FriendRequestDTO>().ReverseMap();
            CreateMap<FriendsListAssoc, FriendsListAssocDTO>().ReverseMap();
        }
    }
}
