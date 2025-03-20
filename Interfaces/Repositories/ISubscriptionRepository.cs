using AccountManager.Domain.Entities;

namespace AccountManager.Interfaces.Repositories
{
    public interface ISubscriptionRepository
    {
        Task<IEnumerable<Subscription>> GetAllAsync();
        Task<Subscription?> GetByIdAsync(int id);
        Task CreateAsync(Subscription subscription);
        Task<bool> UpdateAsync(Subscription subscription);
        Task<bool> DeleteAsync(int id);
    }
}
