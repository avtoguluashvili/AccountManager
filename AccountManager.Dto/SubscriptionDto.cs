﻿using System.ComponentModel.DataAnnotations;

namespace AccountManager.Dto
{
    public class SubscriptionDto
    {
        public int SubscriptionId { get; set; }

        [MaxLength(100)]
        public string? Description { get; set; }

        public bool IsDefault { get; set; }
        public bool IsActive { get; set; }
        public bool AvailableYearly { get; set; }
        public bool Is2FAAllowed { get; set; }
        public bool IsIPFilterAllowed { get; set; }
        public bool IsSessionTimeoutAllowed { get; set; }
    }
}
