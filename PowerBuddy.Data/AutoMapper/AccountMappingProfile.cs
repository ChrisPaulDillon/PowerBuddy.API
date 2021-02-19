using System.Linq;
using AutoMapper;
using PowerBuddy.Data.Dtos.Account;
using PowerBuddy.Data.Dtos.Users;
using PowerBuddy.Data.Entities;
using PowerBuddy.Data.Requests.Users;

namespace PowerBuddy.Data.AutoMapper
{
    public class AccountMappingProfile : Profile
    {
        public AccountMappingProfile()
        {
            CreateMap<EditProfileDto, User>()
                .ForMember<string>(x => x.Id, d => d.MapFrom(src => src.UserId))
                .ForMember<string>(x => x.FirstName, d => d.MapFrom(src => src.FirstName))
                .ForMember<string>(x => x.LastName, d => d.MapFrom(src => src.LastName))
                .ForMember(x => x.IsBanned, d => d.Ignore())
                .ForMember(x => x.GenderId, d => d.Ignore())
                .ForMember(x => x.IsPublic, d => d.Ignore())
                .ForMember(x => x.IsBanned, d => d.Ignore())
                .ForMember(x => x.SportType, d => d.Ignore())
                .ForMember(x => x.FirstVisit, d => d.Ignore())
                .ForMember(x => x.MemberStatusId, d => d.Ignore())
                .ForMember(x => x.UserName, d => d.Ignore())
                .ForMember(x => x.NormalizedUserName, d => d.Ignore())
                .ForMember(x => x.EmailConfirmed, d => d.Ignore())
                .ForMember(x => x.Email, d => d.Ignore())
                .ForMember(x => x.NormalizedEmail, d => d.Ignore())
                .ForMember(x => x.PasswordHash, d => d.Ignore())
                .ForMember(x => x.SecurityStamp, d => d.Ignore())
                .ForMember(x => x.ConcurrencyStamp, d => d.Ignore())
                .ForMember(x => x.PhoneNumber, d => d.Ignore())
                .ForMember(x => x.PhoneNumberConfirmed, d => d.Ignore())
                .ForMember(x => x.TwoFactorEnabled, d => d.Ignore())
                .ForMember(x => x.LockoutEnabled, d => d.Ignore())
                .ForMember(x => x.LockoutEnd, d => d.Ignore())
                .ForMember(x => x.AccessFailedCount, d => d.Ignore())
                .ForMember(x => x.LiftingStatAudit, d => d.Ignore())
                .ForMember(x => x.Gender, d => d.Ignore())
                .ForMember(x => x.MemberStatus, d => d.Ignore())
                .ForMember(x => x.UserSetting, d => d.Ignore());

            CreateMap<EditProfileDto, UserSetting>()
                .ForMember<decimal>(x => x.BodyWeight, d => d.MapFrom(src => src.BodyWeight))
                .ForMember<bool>(x => x.QuotesEnabled, d => d.MapFrom(src => src.QuotesEnabled))
                .ForMember<bool>(x => x.UsingMetric, d => d.MapFrom(src => src.UsingMetric))
                .ForMember(x => x.UserSettingId, d => d.Ignore())
                .ForMember(x => x.LiftingLevelId, d => d.Ignore())
                .ForMember(x => x.LiftingLevel, d => d.Ignore());

            CreateMap<User, UserDto>()
                .ForMember(x => x.UserId, d => d.MapFrom<string>(src => src.Id))
                .ForMember(x => x.UserName, d => d.MapFrom<string>(src => src.UserName))
                .ForMember(x => x.PhoneNumber, d => d.MapFrom<string>(src => src.PhoneNumber))
                .ForMember(x => x.PhoneNumberConfirmed, d => d.MapFrom<bool>(src => src.PhoneNumberConfirmed))
                .ForMember(x => x.Email, d => d.MapFrom<string>(src => src.Email))
                .ForMember(x => x.LiftingLevel, d => d.MapFrom(src => src.UserSetting.LiftingLevel.LiftingLevelStr))
                .ForMember(x => x.FirstName, d => d.MapFrom<string>(src => src.FirstName))
                .ForMember(x => x.LastName, d => d.MapFrom<string>(src => src.LastName))
                .ForMember(x => x.SportType, d => d.MapFrom<string>(src => src.SportType))
                .ForMember(x => x.FirstVisit, d => d.MapFrom<bool>(src => src.FirstVisit))
                .ForMember(x => x.Gender, d => d.MapFrom<string>(src => src.Gender.GenderName))
                .ForMember(x => x.MemberStatusId, d => d.MapFrom<int?>(src => src.MemberStatusId))
                .ForMember(x => x.UsingMetric, d => d.MapFrom(src => src.UserSetting.UsingMetric))
                .ForMember(x => x.BodyWeight, d => d.MapFrom<decimal>(src => src.UserSetting.BodyWeight))
                .ForMember(x => x.QuotesEnabled, d => d.MapFrom<bool>(src => src.UserSetting.QuotesEnabled));

            CreateMap<RegisterUserRequest, User>()
                .ForMember<string>(x => x.UserName, d => d.MapFrom(src => src.UserName))
                .ForMember<string>(x => x.PasswordHash, d => d.MapFrom(src => src.Password))
                .ForMember<string>(x => x.Email, d => d.MapFrom(src => src.Email))
                .ForMember<string>(x => x.SportType, d => d.MapFrom(src => src.SportType))
                .ForMember(x => x.Id, d => d.Ignore())
                .ForMember(x => x.FirstName, d => d.Ignore())
                .ForMember(x => x.LastName, d => d.Ignore())
                .ForMember(x => x.IsBanned, d => d.Ignore())
                .ForMember(x => x.GenderId, d => d.Ignore())
                .ForMember(x => x.IsPublic, d => d.Ignore())
                .ForMember(x => x.IsBanned, d => d.Ignore())
                .ForMember(x => x.FirstVisit, d => d.Ignore())
                .ForMember(x => x.MemberStatusId, d => d.Ignore())
                .ForMember(x => x.NormalizedUserName, d => d.Ignore())
                .ForMember(x => x.EmailConfirmed, d => d.Ignore())
                .ForMember(x => x.NormalizedEmail, d => d.Ignore())
                .ForMember(x => x.SecurityStamp, d => d.Ignore())
                .ForMember(x => x.ConcurrencyStamp, d => d.Ignore())
                .ForMember(x => x.PhoneNumber, d => d.Ignore())
                .ForMember(x => x.PhoneNumberConfirmed, d => d.Ignore())
                .ForMember(x => x.TwoFactorEnabled, d => d.Ignore())
                .ForMember(x => x.LockoutEnabled, d => d.Ignore())
                .ForMember(x => x.LockoutEnd, d => d.Ignore())
                .ForMember(x => x.AccessFailedCount, d => d.Ignore())
                .ForMember(x => x.LiftingStatAudit, d => d.Ignore())
                .ForMember(x => x.Gender, d => d.Ignore())
                .ForMember(x => x.MemberStatus, d => d.Ignore())
                .ForMember(x => x.UserSetting, d => d.Ignore());

            CreateMap<User, PublicUserDto>()
                .ForMember(x => x.UserId, d => d.MapFrom<string>(src => src.Id))
                .ForMember(x => x.UserName, d => d.MapFrom<string>(src => src.UserName))
                .ForMember(x => x.SportType, d => d.MapFrom<string>(src => src.SportType))
                .ForMember(x => x.BodyWeight, d => d.MapFrom<decimal>(src => src.UserSetting.BodyWeight))
                .ForMember(x => x.IsPublic, d => d.MapFrom<bool>(src => src.IsPublic))
                .ForMember(x => x.MemberStatusId, d => d.MapFrom<int?>(src => src.MemberStatusId))
                .ForMember(x => x.Gender, d => d.MapFrom<string>(src => src.Gender.GenderName))
                .ForMember(x => x.LiftingLevel, d => d.MapFrom(src => src.UserSetting.LiftingLevel.LiftingLevelStr))
                .ForMember(x => x.LiftFeed, d => d.MapFrom(src => src.LiftingStatAudit))
                .ForMember(x => x.PersonalBestCount, d => d.MapFrom(src => src.LiftingStatAudit.Count()))
                .ForMember(x => x.LiftFeed, d => d.MapFrom(src => src.WorkoutDays.Count()));

            CreateMap<User, AdminUserDto>()
                .ForMember(x => x.UserId, d => d.MapFrom<string>(src => src.Id))
                .ForMember(x => x.UserName, d => d.MapFrom<string>(src => src.UserName))
                .ForMember(x => x.Email, d => d.MapFrom<string>(src => src.Email))
                .ForMember(x => x.FirstName, d => d.MapFrom<string>(src => src.FirstName))
                .ForMember(x => x.LastName, d => d.MapFrom<string>(src => src.LastName))
                .ForMember(x => x.SportType, d => d.MapFrom<string>(src => src.SportType))
                .ForMember(x => x.IsPublic, d => d.MapFrom<bool>(src => src.IsPublic))
                .ForMember(x => x.BodyWeight, d => d.MapFrom(src => src.UserSetting.BodyWeight))
                .ForMember(x => x.QuotesEnabled, d => d.MapFrom(src => src.UserSetting.QuotesEnabled))
                .ForMember(x => x.IsBanned, d => d.MapFrom<bool>(src => src.IsBanned));
        }
    }
}
