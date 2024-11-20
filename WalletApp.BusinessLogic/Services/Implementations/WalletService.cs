using Microsoft.EntityFrameworkCore;
using WalletApp.BusinessLogic.Services.Interfaces;
using WalletApp.DataAccess.Data;
using WalletApp.DataAccess.Entities;


namespace WalletApp.BusinessLogic.Services.Implementations;

public class WalletService : IWalletService
{
    private readonly WalletAppDbContext _context;

    public WalletService(WalletAppDbContext context)
    {
        _context = context;
    }

    public async Task<Wallet> GetWalletAsync(Guid userId, CancellationToken cancellationToken)
    {
        var user = await _context.Wallets.FirstOrDefaultAsync(w => w.UserId == userId, cancellationToken);

        if (user != null)
        {
            return user;
        }
        throw new InvalidOperationException($"User with ID {userId} was not found.");
    }
}