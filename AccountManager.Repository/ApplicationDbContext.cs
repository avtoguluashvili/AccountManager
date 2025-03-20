using Microsoft.EntityFrameworkCore;
using AccountManager.Domain.Entities;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace AccountManager.Repository
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Account> Accounts { get; set; }
        public DbSet<AccountSubscription> AccountSubscriptions { get; set; }
        public DbSet<AccountSubscriptionStatus> AccountSubscriptionStatuses { get; set; }
        public DbSet<Subscription> Subscriptions { get; set; }
        public DbSet<AccountChangesLog> AccountChangesLogs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            // Account - AccountSubscription (One-to-Many Relationship)
            modelBuilder.Entity<Account>()
                .HasMany(a => a.AccountSubscriptions)
                .WithOne(a => a.Account)
                .HasForeignKey(a => a.AccountId)
                .OnDelete(DeleteBehavior.Restrict); // No cascading delete

            // AccountSubscription - Subscription (Many-to-One Relationship)
            modelBuilder.Entity<AccountSubscription>()
                .HasOne(a => a.Subscription)
                .WithMany()
                .HasForeignKey(a => a.SubscriptionId)
                .OnDelete(DeleteBehavior.Restrict); // No cascading delete

            // AccountSubscription - AccountSubscriptionStatus (Many-to-One Relationship)
            modelBuilder.Entity<AccountSubscription>()
                .HasOne(a => a.AccountSubscriptionStatus)
                .WithMany()
                .HasForeignKey(a => a.SubscriptionStatusId)
                .OnDelete(DeleteBehavior.Restrict); // No cascading delete

            base.OnModelCreating(modelBuilder);
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.ConfigureWarnings(warnings => warnings.Ignore(RelationalEventId.PendingModelChangesWarning));
        }

    }
}
