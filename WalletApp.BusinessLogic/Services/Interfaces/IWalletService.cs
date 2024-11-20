using WalletApp.DataAccess.Entities;

namespace WalletApp.BusinessLogic.Services.Interfaces;
public interface IWalletService
{
    Task<Wallet> GetWalletAsync(Guid userId, CancellationToken cancellationToken);
}
