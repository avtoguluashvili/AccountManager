using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AccountManager.Domain.Entities;

namespace AccountManager.Interfaces.Repositories
{
    /// <summary>
    ///     CRUD operations for AccountSubscriptionStatus.
    /// </summary>
    public interface IAccountSubscriptionStatusRepository
    {
        Task<List<AccountSubscriptionStatus>> GetAllAsync();
        Task<AccountSubscriptionStatus?> GetByIdAsync(int id);
        Task<AccountSubscriptionStatus> CreateAsync(AccountSubscriptionStatus status);
        Task<AccountSubscriptionStatus> UpdateAsync(AccountSubscriptionStatus status);
        Task DeleteAsync(int id);
    }
}
