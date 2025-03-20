using AccountManager.Domain.Entities;

namespace AccountManager.Interfaces.Repositories
{
    public interface IAccountRepository
    {
        Task<IEnumerable<Account>> GetAllAsync();
        Task<Account?> GetByIdAsync(int id);
        Task<Account> CreateAsync(Account account);
        Task<bool> UpdateAsync(Account account);
        Task<bool> DeleteAsync(int id);
        Task<IEnumerable<Account>> SearchAsync(string query); // New method
    }
}
