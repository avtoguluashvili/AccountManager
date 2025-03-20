using AccountManager.Dto;
using AccountManager.Domain.Entities;
using AccountManager.Interfaces.Repositories;
using AccountManager.Interfaces.Services;

namespace AccountManager.Services
{
    public class SubscriptionService : ISubscriptionService
    {
        private readonly ISubscriptionRepository _subscriptionRepository;

        public SubscriptionService(ISubscriptionRepository subscriptionRepository)
        {
            _subscriptionRepository = subscriptionRepository;
        }

        public async Task<IEnumerable<SubscriptionDto>> GetAllSubscriptionsAsync()
        {
            var subscriptions = await _subscriptionRepository.GetAllAsync();
            return subscriptions.Select(subscription => new SubscriptionDto
            {
                SubscriptionId = subscription.SubscriptionId,
                Description = subscription.Description,
                IsActive = subscription.IsActive,
                IsDefault = subscription.IsDefault,
                AvailableYearly = subscription.AvailableYearly,
                Is2FAAllowed = subscription.Is2FAAllowed,
                IsIPFilterAllowed = subscription.IsIPFilterAllowed,
                IsSessionTimeoutAllowed = subscription.IsSessionTimeoutAllowed
            });
        }

        public async Task<SubscriptionDto?> GetSubscriptionByIdAsync(int id)
        {
            var subscription = await _subscriptionRepository.GetByIdAsync(id);
            if (subscription == null) return null;

            return new SubscriptionDto
            {
                SubscriptionId = subscription.SubscriptionId,
                Description = subscription.Description,
                IsActive = subscription.IsActive,
                IsDefault = subscription.IsDefault,
                AvailableYearly = subscription.AvailableYearly,
                Is2FAAllowed = subscription.Is2FAAllowed,
                IsIPFilterAllowed = subscription.IsIPFilterAllowed,
                IsSessionTimeoutAllowed = subscription.IsSessionTimeoutAllowed
            };
        }

        public async Task<SubscriptionDto> CreateSubscriptionAsync(SubscriptionDto subscriptionDto)
        {
            var subscription = new Subscription
            {
                Description = subscriptionDto.Description,
                IsActive = subscriptionDto.IsActive,
                IsDefault = subscriptionDto.IsDefault,
                AvailableYearly = subscriptionDto.AvailableYearly,
                Is2FAAllowed = subscriptionDto.Is2FAAllowed,
                IsIPFilterAllowed = subscriptionDto.IsIPFilterAllowed,
                IsSessionTimeoutAllowed = subscriptionDto.IsSessionTimeoutAllowed
            };

            await _subscriptionRepository.CreateAsync(subscription);

            return new SubscriptionDto
            {
                SubscriptionId = subscription.SubscriptionId,
                Description = subscription.Description,
                IsActive = subscription.IsActive,
                IsDefault = subscription.IsDefault,
                AvailableYearly = subscription.AvailableYearly,
                Is2FAAllowed = subscription.Is2FAAllowed,
                IsIPFilterAllowed = subscription.IsIPFilterAllowed,
                IsSessionTimeoutAllowed = subscription.IsSessionTimeoutAllowed
            };
        }

        public async Task<bool> UpdateSubscriptionAsync(int id, SubscriptionDto subscriptionDto)
        {
            var subscription = await _subscriptionRepository.GetByIdAsync(id);
            if (subscription == null) return false;

            subscription.Description = subscriptionDto.Description;
            subscription.IsActive = subscriptionDto.IsActive;
            subscription.IsDefault = subscriptionDto.IsDefault;
            subscription.AvailableYearly = subscriptionDto.AvailableYearly;
            subscription.Is2FAAllowed = subscriptionDto.Is2FAAllowed;
            subscription.IsIPFilterAllowed = subscriptionDto.IsIPFilterAllowed;
            subscription.IsSessionTimeoutAllowed = subscriptionDto.IsSessionTimeoutAllowed;

            return await _subscriptionRepository.UpdateAsync(subscription);
        }

        public async Task<bool> DeleteSubscriptionAsync(int id)
        {
            return await _subscriptionRepository.DeleteAsync(id);
        }
    }
}
