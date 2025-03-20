using System.Net.Http.Json;
using AccountManager.Client;
using AccountManager.Dto;

namespace AccountManager.Services
{
    public class AccountApiService : IAccountApiService
    {
        private readonly HttpClient _httpClient;

        public AccountApiService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<AccountDto>> GetAccountsAsync(string searchTerm)
        {
            return await _httpClient.GetFromJsonAsync<IEnumerable<AccountDto>>($"api/Account?searchTerm={searchTerm}") ?? new List<AccountDto>();
        }

        public async Task<AccountDto> GetAccountByIdAsync(int accountId)
        {
            return await _httpClient.GetFromJsonAsync<AccountDto>($"api/Account/{accountId}") ?? new AccountDto();
        }

        public async Task<bool> CreateAccountAsync(AccountDto account)
        {
            var response = await _httpClient.PostAsJsonAsync("api/Account", account);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> UpdateAccountAsync(int accountId, AccountDto account)
        {
            var response = await _httpClient.PutAsJsonAsync($"api/Account/{accountId}", account);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> DeleteAccountAsync(int accountId)
        {
            var response = await _httpClient.DeleteAsync($"api/Account/{accountId}");
            return response.IsSuccessStatusCode;
        }
    }
}
