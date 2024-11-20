using Microsoft.EntityFrameworkCore;
using WalletApp.BusinessLogic.Services.Interfaces;
using WalletApp.DataAccess.Data;
using WalletApp.DataAccess.Entities;

namespace WalletApp.BusinessLogic.Services.Implementations;
public class UserService : IUserService
{
    private readonly WalletAppDbContext _context;

    public UserService(WalletAppDbContext context)
    {
        _context = context;
    }

    public async Task<User> GetUserWithWalletAsync(Guid userId, CancellationToken cancellationToken)
    {
        var user = await _context.Users.Include(u => u.Wallet).FirstOrDefaultAsync(u => u.Id == userId, cancellationToken);
        if (user != null)
        {
            return user;
        }

        throw new InvalidOperationException($"User with ID {userId} was not found.");
    }
}