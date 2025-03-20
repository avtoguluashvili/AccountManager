using AccountManager.Dto;

namespace AccountManager.Interfaces.Services
{
    public interface ISubscriptionService
    {
        Task<IEnumerable<SubscriptionDto>> GetAllSubscriptionsAsync();
        Task<SubscriptionDto?> GetSubscriptionByIdAsync(int id);
        Task<SubscriptionDto> CreateSubscriptionAsync(SubscriptionDto subscriptionDto);
        Task<bool> UpdateSubscriptionAsync(int id, SubscriptionDto subscriptionDto);
        Task<bool> DeleteSubscriptionAsync(int id);
    }
}
