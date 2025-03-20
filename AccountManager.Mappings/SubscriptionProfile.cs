using AutoMapper;
using AccountManager.Domain.Entities;
using AccountManager.Dto;

namespace AccountManager.Mappings.AutoMapperProfiles
{
    public class SubscriptionProfile : Profile
    {
        public SubscriptionProfile()
        {
            // Map from Subscription entity to SubscriptionDto and vice versa
            CreateMap<Subscription, SubscriptionDto>()
                .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
                .ForMember(dest => dest.IsDefault, opt => opt.MapFrom(src => src.IsDefault))
                .ForMember(dest => dest.IsActive, opt => opt.MapFrom(src => src.IsActive))
                .ForMember(dest => dest.AvailableYearly, opt => opt.MapFrom(src => src.AvailableYearly))
                .ForMember(dest => dest.Is2FAAllowed, opt => opt.MapFrom(src => src.Is2FAAllowed))
                .ForMember(dest => dest.IsIPFilterAllowed, opt => opt.MapFrom(src => src.IsIPFilterAllowed))
                .ForMember(dest => dest.IsSessionTimeoutAllowed, opt => opt.MapFrom(src => src.IsSessionTimeoutAllowed));

            // Reverse map to allow updating entities from DTOs
            CreateMap<SubscriptionDto, Subscription>();

            // Mapping for AccountSubscription
            CreateMap<AccountSubscription, AccountSubscriptionDto>()
                .ForMember(dest => dest.AccountSubscriptionId, opt => opt.MapFrom(src => src.AccountSubscriptionId))
                .ForMember(dest => dest.SubscriptionId, opt => opt.MapFrom(src => src.SubscriptionId))
                .ForMember(dest => dest.AccountId, opt => opt.MapFrom(src => src.AccountId))
                .ForMember(dest => dest.SubscriptionStatusId, opt => opt.MapFrom(src => src.SubscriptionStatusId))
                .ForMember(dest => dest.Is2FAAllowed, opt => opt.MapFrom(src => src.Is2FAAllowed))
                .ForMember(dest => dest.IsIPFilterAllowed, opt => opt.MapFrom(src => src.IsIPFilterAllowed))
                .ForMember(dest => dest.IsSessionTimeoutAllowed, opt => opt.MapFrom(src => src.IsSessionTimeoutAllowed))
                .ForMember(dest => dest.SubscriptionName, opt => opt.MapFrom(src => src.Subscription.Description))
                .ForMember(dest => dest.StatusDescription, opt => opt.MapFrom(src => src.AccountSubscriptionStatus.Description));

            // Reverse map
            CreateMap<AccountSubscriptionDto, AccountSubscription>();
        }
    }
}
