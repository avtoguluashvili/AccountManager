using System.ComponentModel.DataAnnotations;

namespace AccountManager.Domain.Entities
{
    public class AccountSubscriptionStatus
    {
        [Key]
        public int SubscriptionStatusId { get; set; }

        public string Description { get; set; }

        public bool IsDefault { get; set; }

        public bool IsActive { get; set; }

        public bool IsCancelled { get; set; }

        public bool IsDeleted { get; set; }
    }
}
