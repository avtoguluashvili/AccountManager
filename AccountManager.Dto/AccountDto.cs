using System;
using System.ComponentModel.DataAnnotations;

namespace AccountManager.Dto
{
    public class AccountDto
    {
        public int AccountId { get; set; }

        [Required]
        [MaxLength(128)]
        public string Token { get; set; } = Guid.NewGuid().ToString();

        public int IsActive { get; set; } = 0;

        [Required]
        [MaxLength(100)]
        public string CompanyName { get; set; }

        [MaxLength(50)]
        public string? Country { get; set; } = string.Empty;

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public bool Is2FAEnabled { get; set; }
        public bool IsIPFilterEnabled { get; set; }
        public bool IsSessionTimeoutEnabled { get; set; }
        public int SessionTimeOut { get; set; }

        [MaxLength(100)]
        public string? LocalTimeZone { get; set; }
        public AccountSubscriptionDto? AccountSubscription { get; set; }
    }
}
