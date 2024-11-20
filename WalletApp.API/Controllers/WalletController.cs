using Microsoft.AspNetCore.Mvc;
using WalletApp.BusinessLogic.Services.Interfaces;

namespace WalletApp.API.Controllers;
[Route("api/[controller]")]
[ApiController]
public class WalletController : ControllerBase
{
    private readonly IWalletService _walletService;

    public WalletController(IWalletService walletService)
    {
        _walletService = walletService;
    }

    [HttpGet("{userId}")]
    public async Task<IActionResult> GetWallet(Guid userId, CancellationToken cancellationToken)
    {
        var wallet = await _walletService.GetWalletAsync(userId, cancellationToken);
        if (wallet == null) return NotFound();

        return Ok(new
        {
            wallet.Balance,
            Available = wallet.CardLimit - wallet.Balance,
            PaymentStatus = $"You’ve paid your {DateTime.Now:MMMM} balance."
        });
    }
}

