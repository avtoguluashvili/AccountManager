using AccountManager.Domain.Entities;
using AccountManager.Dto;
using AccountManager.Interfaces.Repositories;
using AccountManager.Interfaces.Services;

namespace AccountManager.Services
{
    public class AccountService : IAccountService
    {
        private readonly IAccountRepository _accountRepository;

        public AccountService(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }

        public async Task<IEnumerable<AccountDto>> GetAllAsync()
        {
            var accounts = await _accountRepository.GetAllAsync();
            return accounts.Select(a => new AccountDto
            {
                AccountId = a.AccountId,
                CompanyName = a.CompanyName,
                IsActive = a.IsActive,
                Token = a.Token
            });
        }

        public async Task<IEnumerable<AccountDto>> SearchAccountsAsync(string query)
        {
            var accounts = await _accountRepository.SearchAsync(query);
            return accounts.Select(a => new AccountDto
            {
                AccountId = a.AccountId,
                CompanyName = a.CompanyName,
                IsActive = a.IsActive,
                Token = a.Token
            });
        }

        public async Task<AccountDto?> GetByIdAsync(int id)
        {
            var account = await _accountRepository.GetByIdAsync(id);
            if (account == null) return null;

            return new AccountDto
            {
                AccountId = account.AccountId,
                CompanyName = account.CompanyName,
                IsActive = account.IsActive,
                Token = account.Token
            };
        }

        public async Task<AccountDto> CreateAsync(AccountDto accountDto)
        {
            var newAccount = new Account
            {
                CompanyName = accountDto.CompanyName,
                IsActive = accountDto.IsActive,
                Token = Guid.NewGuid().ToString()
            };

            await _accountRepository.CreateAsync(newAccount);
            return new AccountDto
            {
                AccountId = newAccount.AccountId,
                CompanyName = newAccount.CompanyName,
                IsActive = newAccount.IsActive,
                Token = newAccount.Token
            };
        }

        public async Task<bool> UpdateAsync(AccountDto accountDto)
        {
            var account = await _accountRepository.GetByIdAsync(accountDto.AccountId);
            if (account == null) return false;

            account.CompanyName = accountDto.CompanyName;
            account.IsActive = accountDto.IsActive;

            return await _accountRepository.UpdateAsync(account);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await _accountRepository.DeleteAsync(id);
        }

        public async Task<bool> ToggleIsActiveAsync(int id)
        {
            var account = await _accountRepository.GetByIdAsync(id);
            if (account == null) return false;

            account.IsActive = account.IsActive == 1 ? 0 : 1;
            return await _accountRepository.UpdateAsync(account);
        }
    }
}
