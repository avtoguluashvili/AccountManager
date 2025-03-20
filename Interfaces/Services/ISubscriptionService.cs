using AccountManager.Dto;

namespace AccountManager.Interfaces.Services
{
    public interface ISubscriptionService
    {
        Task<IEnumerable<SubscriptionDto>> GetAllSubscriptionsAsync();
        Task<SubscriptionDto?> GetSubscriptionByIdAsync(int subscriptionId);
        Task<bool> UpdateSubscriptionAsync(int subscriptionId, SubscriptionDto subscriptionDto);
    }
}
