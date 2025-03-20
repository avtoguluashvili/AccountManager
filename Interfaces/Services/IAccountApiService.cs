using AccountManager.Dto;

namespace AccountManager.Client
{
    public interface IAccountApiService
    {
        Task<IEnumerable<AccountDto>> GetAccountsAsync(string searchTerm);
        Task<AccountDto> GetAccountByIdAsync(int accountId);
        Task<bool> CreateAccountAsync(AccountDto account);
        Task<bool> UpdateAccountAsync(int accountId, AccountDto account);
        Task<bool> DeleteAccountAsync(int accountId);
    }
}
