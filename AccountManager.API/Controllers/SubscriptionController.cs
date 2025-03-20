using AccountManager.Dto;
using AccountManager.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace AccountManager.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SubscriptionController : ControllerBase
    {
        private readonly ISubscriptionService _subscriptionService;

        public SubscriptionController(ISubscriptionService subscriptionService)
        {
            _subscriptionService = subscriptionService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<SubscriptionDto>>> GetAllSubscriptions()
        {
            var subscriptions = await _subscriptionService.GetAllSubscriptionsAsync();
            return Ok(subscriptions);
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<SubscriptionDto>> GetSubscriptionById(int id)
        {
            var subscription = await _subscriptionService.GetSubscriptionByIdAsync(id);
            if (subscription == null) return NotFound();

            return Ok(subscription);
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdateSubscription(int id, [FromBody] SubscriptionDto subscriptionDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var updated = await _subscriptionService.UpdateSubscriptionAsync(id, subscriptionDto);
            if (!updated)
                return NotFound();

            return NoContent();
        }
    }
}
