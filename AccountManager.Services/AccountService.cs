using AccountManager.Domain.Entities;
using AccountManager.Dto;
using AccountManager.Interfaces.Repositories;
using AccountManager.Interfaces.Services;
using AutoMapper;

namespace AccountManager.Services
{
    public class AccountService : IAccountService
    {
        private readonly IAccountRepository _accountRepository;
        private readonly IMapper _mapper;

        public AccountService(IAccountRepository accountRepository, IMapper mapper)
        {
            _accountRepository = accountRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<AccountDto>> GetAllAccountsAsync()
        {
            var accounts = await _accountRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<AccountDto>>(accounts);
        }

        public async Task<AccountDto?> GetAccountByIdAsync(int accountId)
        {
            var account = await _accountRepository.GetByIdAsync(accountId);
            return account is null ? null : _mapper.Map<AccountDto>(account);
        }

        public async Task<AccountDto> CreateAccountAsync(AccountDto accountDto)
        {
            var accountEntity = _mapper.Map<Account>(accountDto);
            var createdAccount = await _accountRepository.CreateAsync(accountEntity);
            return _mapper.Map<AccountDto>(createdAccount);
        }

        public async Task<bool> UpdateAccountAsync(int accountId, AccountDto accountDto)
        {
            var accountEntity = _mapper.Map<Account>(accountDto);
            accountEntity.AccountId = accountId;
            return await _accountRepository.UpdateAsync(accountEntity);
        }

        public async Task<bool> DeleteAccountAsync(int accountId)
        {
            return await _accountRepository.DeleteAsync(accountId);
        }
    }
}
