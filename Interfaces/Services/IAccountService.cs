using AccountManager.Dto;

namespace AccountManager.Interfaces.Services
{
    public interface IAccountService
    {
        Task<IEnumerable<AccountDto>> GetAllAccountsAsync();
        Task<AccountDto?> GetAccountByIdAsync(int accountId);
        Task<AccountDto> CreateAccountAsync(AccountDto accountDto);
        Task<bool> UpdateAccountAsync(int accountId, AccountDto accountDto);
        Task<bool> DeleteAccountAsync(int accountId);
    }
}
