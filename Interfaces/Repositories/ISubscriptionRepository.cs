using AccountManager.Domain.Entities;

namespace AccountManager.Interfaces.Repositories
{
    public interface ISubscriptionRepository
    {
        Task<IEnumerable<Subscription>> GetAllAsync();
        Task<Subscription?> GetByIdAsync(int subscriptionId);
        Task<bool> UpdateAsync(Subscription subscription);
    }
}
