using WalletApp.DataAccess.Entities;

namespace WalletApp.BusinessLogic.Services.Interfaces;
public interface ITransactionService
{
    Task<IEnumerable<Transaction>> GetLatestTransactionsAsync(Guid userId, CancellationToken cancellationToken);
}
