using AccountManager.Domain.Entities;
using System.ComponentModel.DataAnnotations;

public class AccountSubscription
{
    [Key]
    public int AccountSubscriptionId { get; set; }

    public int SubscriptionId { get; set; }
    public virtual Subscription Subscription { get; set; }

    public int AccountId { get; set; }
    public virtual Account Account { get; set; }

    public int SubscriptionStatusId { get; set; }
    public virtual AccountSubscriptionStatus AccountSubscriptionStatus { get; set; }

    public bool Is2FAAllowed { get; set; }
    public bool IsIPFilterAllowed { get; set; }
    public bool IsSessionTimeoutAllowed { get; set; }
}
