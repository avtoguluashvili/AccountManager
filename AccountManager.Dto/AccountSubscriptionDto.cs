using System.ComponentModel.DataAnnotations;

namespace AccountManager.Dto
{
    public class AccountSubscriptionDto
    {
        public int AccountSubscriptionId { get; set; }

        [Required]
        public int SubscriptionId { get; set; }

        public int AccountId { get; set; }

        [Required]
        public int SubscriptionStatusId { get; set; }

        public bool Is2FAAllowed { get; set; }
        public bool IsIPFilterAllowed { get; set; }
        public bool IsSessionTimeoutAllowed { get; set; }

        // Navigation property for easier client rendering
        public string? SubscriptionName { get; set; }
        public string? StatusDescription { get; set; }
    }
}
