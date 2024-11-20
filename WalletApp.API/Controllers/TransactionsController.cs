using Microsoft.AspNetCore.Mvc;
using WalletApp.BusinessLogic.Services.Interfaces;
using WalletApp.DataAccess.Entities;

namespace WalletApp.API.Controllers;
[Route("api/[controller]")]
[ApiController]
public class TransactionsController : ControllerBase
{
    private readonly ITransactionService _transactionService;

    public TransactionsController(ITransactionService transactionService)
    {
        _transactionService = transactionService;
    }

    [HttpGet("{userId}")]
    public async Task<IActionResult> GetLatestTransactions(Guid userId, CancellationToken cancellationToken)
    {
        var transactions = await _transactionService.GetLatestTransactionsAsync(userId, cancellationToken);
        return Ok(transactions);
    }

    [HttpPost]
    public IActionResult CreateTransaction([FromBody] Transaction transaction)
    {
        transaction.Date = DateTime.UtcNow;

        return CreatedAtAction(nameof(GetLatestTransactions), new { userId = transaction.UserId }, transaction);
    }
}