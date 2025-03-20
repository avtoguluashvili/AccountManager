using AccountManager.Domain.Entities;
using AccountManager.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace AccountManager.Repository
{
    public class AccountRepository : IAccountRepository
    {
        private readonly ApplicationDbContext _context;

        public AccountRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Account>> GetAllAsync()
        {
            return await _context.Accounts.ToListAsync();
        }

        public async Task<Account?> GetByIdAsync(int id)
        {
            return await _context.Accounts.FindAsync(id);
        }

        public async Task<Account> CreateAsync(Account account)
        {
            _context.Accounts.Add(account);
            await _context.SaveChangesAsync();
            return account;
        }

        public async Task<bool> UpdateAsync(Account account)
        {
            _context.Accounts.Update(account);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var account = await GetByIdAsync(id);
            if (account == null) return false;

            _context.Accounts.Remove(account);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<IEnumerable<Account>> SearchAsync(string query)
        {
            return await _context.Accounts
                .Where(a => a.CompanyName.Contains(query))
                .ToListAsync();
        }
    }
}
