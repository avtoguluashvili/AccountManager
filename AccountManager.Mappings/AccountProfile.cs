using AccountManager.Domain.Entities;
using AccountManager.Dto;
using AutoMapper;

namespace AccountManager.Mappings.AutoMapperProfiles
{
    public class AccountProfile : Profile
    {
        public AccountProfile()
        {
            CreateMap<Account, AccountDto>()
                .ForMember(dest => dest.IsActive, opt => opt.MapFrom(src => src.IsActive))
                .ForMember(dest => dest.CompanyName, opt => opt.MapFrom(src => src.CompanyName))
                .ForMember(dest => dest.Token, opt => opt.MapFrom(src => src.Token))
                .ForMember(dest => dest.CreatedAt, opt => opt.MapFrom(src => src.CreatedAt))
                .ForMember(dest => dest.Is2FAEnabled, opt => opt.MapFrom(src => src.Is2FAEnabled))
                .ForMember(dest => dest.IsIPFilterEnabled, opt => opt.MapFrom(src => src.IsIPFilterEnabled))
                .ForMember(dest => dest.IsSessionTimeoutEnabled, opt => opt.MapFrom(src => src.IsSessionTimeoutEnabled))
                .ForMember(dest => dest.SessionTimeOut, opt => opt.MapFrom(src => src.SessionTimeOut))
                .ForMember(dest => dest.LocalTimeZone, opt => opt.MapFrom(src => src.LocalTimeZone))
                .ForMember(dest => dest.AccountSubscription, opt => opt.MapFrom(src => src.AccountSubscription));

            CreateMap<AccountDto, Account>();
        }
    }
}
