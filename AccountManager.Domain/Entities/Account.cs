using System.ComponentModel.DataAnnotations;

/// <summary>
///     Represents a customer or client account.
/// </summary>
public class Account
{
    [Key] public int AccountId { get; set; }

    public string Token { get; set; } = Guid.NewGuid().ToString();
    public bool IsActive { get; set; }
    public string CompanyName { get; set; } = string.Empty;
    public string Country { get; set; } = string.Empty;
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public virtual AccountSubscription? AccountSubscription { get; set; }
    public bool Is2FAEnabled { get; set; }
    public bool IsIPFilterEnabled { get; set; }
    public bool IsSessionTimeoutEnabled { get; set; }
    public int SessionTimeOut { get; set; }
    public string? LocalTimeZone { get; set; }
}