using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AccountManager.Domain.Entities
{
    public class AccountSubscription
    {
        [Key]
        public int AccountSubscriptionId { get; set; }

        public int SubscriptionId { get; set; }

        // Navigation property to the related Subscription
        public Subscription Subscription { get; set; }

        public int AccountId { get; set; }

        // Navigation property to the related Account
        public Account Account { get; set; }

        [ForeignKey("AccountSubscriptionStatus")]
        public int SubscriptionStatusId { get; set; }

        // Navigation property to the related Subscription Status
        public AccountSubscriptionStatus AccountSubscriptionStatus { get; set; }

        public bool Is2FAAllowed { get; set; }
        public bool IsIPFilterAllowed { get; set; }
        public bool IsSessionTimeoutAllowed { get; set; }
    }
}
