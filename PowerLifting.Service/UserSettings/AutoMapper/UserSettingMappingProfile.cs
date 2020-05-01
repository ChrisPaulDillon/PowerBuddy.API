using AutoMapper;
using PowerLifting.Service.UserSettings.DTO;
using PowerLifting.Service.UserSettings.Model;

namespace PowerLifting.Service.UserSettings.AutoMapper
{
    public class UserSettingMappingProfile : Profile
    {
        public UserSettingMappingProfile()
        {
            //UserSettings
            CreateMap<UserSetting, UserSettingDTO>();
            CreateMap<UserSettingDTO, UserSetting>();
        }
    }
}
