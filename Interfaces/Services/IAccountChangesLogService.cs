using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountManager.Interfaces.Services
{
    /// <summary>
    ///     Business logic for account changes log.
    /// </summary>
    public interface IAccountChangesLogService
    {
        Task<List<AccountChangesLog>> GetAllAsync();
        Task<List<AccountChangesLog>> GetByAccountAsync(int accountId);
        Task<AccountChangesLog> CreateAsync(AccountChangesLog log);
        Task DeleteAsync(int logId);
    }
}
