using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AccountManager.Interfaces.Repositories;
using AccountManager.Interfaces.Services;
using AccountManager.Repository;

namespace AccountManager.Services
{
    /// <summary>
    ///     Implements account changes log logic.
    /// </summary>
    public class AccountChangesLogService(IAccountChangesLogRepository repo) : IAccountChangesLogService
    {
        public async Task<List<AccountChangesLog>> GetAllAsync()
        {
            return await repo.GetAllAsync();
        }

        public async Task<List<AccountChangesLog>> GetByAccountAsync(int accountId)
        {
            return await repo.GetByAccountAsync(accountId);
        }

        public async Task<AccountChangesLog> CreateAsync(AccountChangesLog log)
        {
            return await repo.CreateAsync(log);
        }

        public async Task DeleteAsync(int logId)
        {
            await repo.DeleteAsync(logId);
        }
    }
}
