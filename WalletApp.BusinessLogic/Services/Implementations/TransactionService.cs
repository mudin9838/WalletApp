using Microsoft.EntityFrameworkCore;
using WalletApp.BusinessLogic.Services.Interfaces;
using WalletApp.DataAccess.Data;
using WalletApp.DataAccess.Entities;
using WalletApp.DataAccess.Enum;

namespace WalletApp.BusinessLogic.Services.Implementations;
public class TransactionService : ITransactionService
{
    private readonly WalletAppDbContext _context;

    public TransactionService(WalletAppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Transaction>> GetLatestTransactionsAsync(Guid userId, CancellationToken cancellationToken)
    {
        var transactions = await _context.Transactions
            .Where(t => t.UserId == userId)
            .OrderByDescending(t => t.Date)
            .Take(10)
            .ToListAsync(cancellationToken);

        foreach (var transaction in transactions)
        {
            transaction.Icon = GetRandomIcon();
            transaction.Description = transaction.Status == TransactionStatus.Pending
                ? "(Pending) " + transaction.Description
                : transaction.Description;

            transaction.DateDisplay = transaction.Date >= DateTime.UtcNow.AddDays(-7)
                ? transaction.Date.ToString("dddd")
                : transaction.Date.ToString("MMMM dd");
        }

        return transactions;
    }

    private string GetRandomIcon()
    {
        return "IconPlaceholder"; // random icon select
    }
}