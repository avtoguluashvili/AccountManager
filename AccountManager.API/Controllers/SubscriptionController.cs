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

        // GET: api/subscription
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SubscriptionDto>>> GetAllSubscriptions()
        {
            var subscriptions = await _subscriptionService.GetAllSubscriptionsAsync();
            return Ok(subscriptions);
        }

        // GET: api/subscription/5
        [HttpGet("{id:int}")]
        public async Task<ActionResult<SubscriptionDto>> GetSubscriptionById(int id)
        {
            var subscription = await _subscriptionService.GetSubscriptionByIdAsync(id);
            if (subscription == null)
                return NotFound();

            return Ok(subscription);
        }

        // POST: api/subscription
        [HttpPost]
        public async Task<ActionResult<SubscriptionDto>> CreateSubscription([FromBody] SubscriptionDto subscriptionDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var createdSubscription = await _subscriptionService.CreateSubscriptionAsync(subscriptionDto);
            return CreatedAtAction(nameof(GetSubscriptionById), new { id = createdSubscription.SubscriptionId }, createdSubscription);
        }

        // PUT: api/subscription/5
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

        // DELETE: api/subscription/5
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteSubscription(int id)
        {
            var deleted = await _subscriptionService.DeleteSubscriptionAsync(id);
            if (!deleted)
                return NotFound();

            return NoContent();
        }
    }
}
