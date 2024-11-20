using WalletApp.DataAccess.Entities;

namespace WalletApp.BusinessLogic.Services.Interfaces;
public interface IUserService
{
    Task<User> GetUserWithWalletAsync(Guid userId, CancellationToken cancellationToken);
}
