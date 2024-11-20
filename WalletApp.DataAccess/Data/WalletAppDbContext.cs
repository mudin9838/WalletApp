using Microsoft.EntityFrameworkCore;
using WalletApp.DataAccess.Entities;
using WalletApp.DataAccess.Enum;

namespace WalletApp.DataAccess.Data;

public class WalletAppDbContext : DbContext
{
    public WalletAppDbContext()
    {

    }
    public WalletAppDbContext(DbContextOptions<WalletAppDbContext> options) : base(options) { }

    public DbSet<User> Users { get; set; }
    public DbSet<Transaction> Transactions { get; set; }
    public DbSet<Wallet> Wallets { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    { optionsBuilder.UseNpgsql(@"Host=localhost;Database=wallet_db;Username=postgres;Password=root"); }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

        modelBuilder.Entity<Transaction>().Property(t => t.Type).HasConversion<string>();
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Transaction>().Property(t => t.Status).HasConversion<string>();
        base.OnModelCreating(modelBuilder);

        // Seed initial data
        var user = new User { Id = Guid.NewGuid(), Name = "John Doe" };
        modelBuilder.Entity<User>().HasData(user);

        var wallet = new Wallet { Id = Guid.NewGuid(), UserId = user.Id, Balance = 100, CardLimit = 1500 };

        // Seed Transactions
        modelBuilder.Entity<Wallet>().HasData(wallet);

        modelBuilder.Entity<Transaction>().HasData(
            new Transaction
            {
                Id = Guid.NewGuid(),
                UserId = user.Id,
                Type = TransactionType.Payment,
                Amount = 20,
                TransactionName = "IKEA",
                Description = "Desc about IKEA",
                DateDisplay = DateTime.UtcNow.ToString("yyyy-MM-dd HH:mm:ss"),
                Date = DateTime.UtcNow.AddDays(-5),
                Status = TransactionStatus.Completed
            },
            new Transaction
            {
                Id = Guid.NewGuid(),
                UserId = user.Id,
                Type = TransactionType.Credit,
                Amount = 50,
                TransactionName = "Target",
                Description = "Desc about Target",
                DateDisplay = DateTime.UtcNow.ToString("yyyy-MM-dd HH:mm:ss"),
                Date = DateTime.UtcNow.AddDays(-2),
                Status = TransactionStatus.Completed
            },
            new Transaction
            {
                Id = Guid.NewGuid(),
                UserId = user.Id,
                Type = TransactionType.Payment,
                Amount = 100,
                DateDisplay = DateTime.UtcNow.ToString("yyyy-MM-dd HH:mm:ss"),
                TransactionName = "Fuel",
                Description = "Refueling the car",
                Date = DateTime.UtcNow.AddDays(-1),
                Status = TransactionStatus.Pending
            }
        );
    }
}