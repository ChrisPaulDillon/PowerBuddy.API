using AutoMapper;
using PowerBuddy.Data.DTOs.Account;
using PowerBuddy.Data.DTOs.Users;
using PowerBuddy.Data.Entities;

namespace PowerBuddy.Data.AutoMapper
{
    public class AccountMappingProfile : Profile
    {
        public AccountMappingProfile()
        {
            CreateMap<EditProfileDTO, User>().ForMember<string>(x => x.Id, d => d.MapFrom(src => src.UserId)).ForMember<string>(x => x.FirstName, d => d.MapFrom(src => src.FirstName)).ForMember<string>(x => x.LastName, d => d.MapFrom(src => src.LastName));

            CreateMap<EditProfileDTO, UserSetting>().ForMember<decimal>(x => x.BodyWeight, d => d.MapFrom(src => src.BodyWeight)).ForMember<bool>(x => x.QuotesEnabled, d => d.MapFrom(src => src.QuotesEnabled));

            CreateMap<User, UserDTO>()
                .ForMember(x => x.UserId, d => d.MapFrom<string>(src => src.Id))
                .ForMember(x => x.UserName, d => d.MapFrom<string>(src => src.UserName))
                .ForMember(x => x.BodyWeight, d => d.MapFrom<decimal>(src => src.UserSetting.BodyWeight))
                .ForMember(x => x.QuotesEnabled, d => d.MapFrom<bool>(src => src.UserSetting.QuotesEnabled))
                .ForMember(x => x.Email, d => d.MapFrom<string>(src => src.Email))
                .ForMember(x => x.LiftingLevel, d => d.MapFrom(src => src.UserSetting.LiftingLevel.LiftingLevelStr))
                .ForMember(x => x.FirstName, d => d.MapFrom<string>(src => src.FirstName))
                .ForMember(x => x.LastName, d => d.MapFrom<string>(src => src.LastName))
                .ForMember(x => x.LiftingStatId, d => d.MapFrom<int>(src => src.LiftingStatId))
                .ForMember(x => x.SportType, d => d.MapFrom<string>(src => src.SportType))
                .ForMember(x => x.FirstVisit, d => d.MapFrom<bool>(src => src.FirstVisit))
                .ForMember(x => x.Gender, d => d.MapFrom<string>(src => src.Gender.GenderName))
                .ForMember(x => x.MemberStatusId, d => d.MapFrom<int?>(src => src.MemberStatusId));

            CreateMap<RegisterUserDTO, User>().ForMember<string>(x => x.UserName, d => d.MapFrom(src => src.UserName)).ForMember<string>(x => x.PasswordHash, d => d.MapFrom(src => src.Password)).ForMember<string>(x => x.Email, d => d.MapFrom(src => src.Email)).ForMember<string>(x => x.SportType, d => d.MapFrom(src => src.SportType));

            CreateMap<User, PublicUserDTO>()
                .ForMember(x => x.UserId, d => d.MapFrom<string>(src => src.Id))
                .ForMember(x => x.UserName, d => d.MapFrom<string>(src => src.UserName))
                .ForMember(x => x.SportType, d => d.MapFrom<string>(src => src.SportType))
                .ForMember(x => x.BodyWeight, d => d.MapFrom<decimal>(src => src.UserSetting.BodyWeight))
                .ForMember(x => x.IsPublic, d => d.MapFrom<bool>(src => src.IsPublic))
                .ForMember(x => x.MemberStatusId, d => d.MapFrom<int?>(src => src.MemberStatusId))
                .ForMember(x => x.Gender, d => d.MapFrom<string>(src => src.Gender.GenderName))
                .ForMember(x => x.LiftingLevel, d => d.MapFrom(src => src.UserSetting.LiftingLevel.LiftingLevelStr))
                .ForMember(x => x.LiftFeed, d => d.MapFrom(src => src.LiftingStatAudit))
                .ForMember(x => x.PendingFriendRequestFrom, d => d.MapFrom(src => src.FriendRequestFrom == null ? false : src.FriendRequestFrom.HasAccepted == null? true : false))
                .ForMember(x => x.PendingFriendRequestTo, d => d.MapFrom(src => src.FriendRequestTo == null ? false : src.FriendRequestFrom.HasAccepted == null ? true : false));

            CreateMap<User, AdminUserDTO>()
                .ForMember(x => x.UserId, d => d.MapFrom<string>(src => src.Id))
                .ForMember(x => x.UserName, d => d.MapFrom<string>(src => src.UserName))
                .ForMember(x => x.Email, d => d.MapFrom<string>(src => src.Email))
                .ForMember(x => x.FirstName, d => d.MapFrom<string>(src => src.FirstName))
                .ForMember(x => x.LastName, d => d.MapFrom<string>(src => src.LastName))
                .ForMember(x => x.LiftingStatId, d => d.MapFrom<int>(src => src.LiftingStatId))
                .ForMember(x => x.SportType, d => d.MapFrom<string>(src => src.SportType))
                .ForMember(x => x.IsPublic, d => d.MapFrom<bool>(src => src.IsPublic))
                .ForMember(x => x.IsBanned, d => d.MapFrom<bool>(src => src.IsBanned))
                .ReverseMap();

            CreateMap<UserSetting, UserSettingDTO>().ReverseMap();

            CreateMap<NotificationDTO, Notification>().ReverseMap();
            CreateMap<NotificationInteraction, NotificationInteractionDTO>().ReverseMap();

            CreateMap<FriendRequest, FriendRequestDTO>().ReverseMap();
            CreateMap<FriendsListAssoc, FriendsListAssocDTO>().ReverseMap();
        }
    }
}
