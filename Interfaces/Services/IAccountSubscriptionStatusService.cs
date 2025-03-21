using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AccountManager.Domain.Entities;

namespace AccountManager.Interfaces.Services
{
    /// <summary>
    ///     Business logic for subscription statuses.
    /// </summary>
    public interface IAccountSubscriptionStatusService
    {
        Task<List<AccountSubscriptionStatus>> GetAllAsync();
        Task<AccountSubscriptionStatus?> GetByIdAsync(int id);
        Task<AccountSubscriptionStatus> CreateAsync(AccountSubscriptionStatus status);
        Task<AccountSubscriptionStatus> UpdateAsync(AccountSubscriptionStatus status);
        Task DeleteAsync(int id);
    }
}
