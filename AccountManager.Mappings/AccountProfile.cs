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
                .ForMember(x => x.IsActive, opt => opt.MapFrom(src => src.IsActive))
                .ForMember(x => x.CompanyName, opt => opt.MapFrom(src => src.CompanyName))
                .ForMember(x => x.Token, opt => opt.MapFrom(src => src.Token))
                .ForMember(x => x.CreatedAt, opt => opt.MapFrom(src => src.CreatedAt))
                .ForMember(x => x.Is2FAEnabled, opt => opt.MapFrom(src => src.Is2FAEnabled))
                .ForMember(x => x.IsIPFilterEnabled, opt => opt.MapFrom(src => src.IsIPFilterEnabled))
                .ForMember(x => x.IsSessionTimeoutEnabled, opt => opt.MapFrom(src => src.IsSessionTimeoutEnabled))
                .ForMember(x => x.SessionTimeOut, opt => opt.MapFrom(src => src.SessionTimeOut))
                .ForMember(x => x.LocalTimeZone, opt => opt.MapFrom(src => src.LocalTimeZone));

            CreateMap<AccountDto, Account>();
        }
    }
}
