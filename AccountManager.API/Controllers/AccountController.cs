using Microsoft.AspNetCore.Mvc;
using AccountManager.Interfaces.Services;
using AccountManager.Dto;

namespace AccountManager.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService _accountService;

        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<AccountDto>>> GetAll()
        {
            var accounts = await _accountService.GetAllAsync();
            return Ok(accounts);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<AccountDto>> GetById(int id)
        {
            var account = await _accountService.GetByIdAsync(id);
            if (account == null) return NotFound();
            return Ok(account);
        }

        [HttpGet("search")]
        public async Task<ActionResult<IEnumerable<AccountDto>>> SearchAccounts([FromQuery] string query)
        {
            var accounts = await _accountService.SearchAccountsAsync(query);
            if (accounts == null || !accounts.Any())
                return NotFound("No matching accounts found.");

            return Ok(accounts);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] AccountDto accountDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var createdAccount = await _accountService.CreateAsync(accountDto);
                return CreatedAtAction(nameof(GetById), new { id = createdAccount.AccountId }, createdAccount);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error creating account: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, AccountDto accountDto)
        {
            if (id != accountDto.AccountId) return BadRequest();

            var updated = await _accountService.UpdateAsync(accountDto);
            if (!updated) return NotFound();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await _accountService.DeleteAsync(id);
            if (!deleted) return NotFound();

            return NoContent();
        }

        [HttpPatch("{id}/toggle")]
        public async Task<IActionResult> ToggleIsActive(int id)
        {
            var updated = await _accountService.ToggleIsActiveAsync(id);
            if (!updated) return NotFound();

            return NoContent();
        }
    }
}
