using System;
using System.ComponentModel.DataAnnotations;

namespace AccountManager.Domain.Entities
{
    public class AccountChangesLog
    {
        [Key]
        public int AccountChangesLogId { get; set; }

        public int AccountId { get; set; }

        public string ChangedField { get; set; }

        public string OldValue { get; set; }

        public string NewValue { get; set; }

        public DateTime Timestamp { get; set; } = DateTime.UtcNow;
    }
}
