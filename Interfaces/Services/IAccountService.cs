using AccountManager.Dto;

namespace AccountManager.Interfaces.Services
{
    public interface IAccountService
    {
        Task<IEnumerable<AccountDto>> GetAllAsync();
        Task<AccountDto?> GetByIdAsync(int id);
        Task<AccountDto> CreateAsync(AccountDto accountDto);
        Task<bool> UpdateAsync(AccountDto accountDto);
        Task<bool> DeleteAsync(int id);
        Task<bool> ToggleIsActiveAsync(int id);
        Task<IEnumerable<AccountDto>> SearchAccountsAsync(string query); // New method
    }
}