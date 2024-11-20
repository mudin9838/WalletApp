using WalletApp.DataAccess.Enum;

namespace WalletApp.DataAccess.Entities;
public class Transaction
{

    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public TransactionType Type { get; set; }
    public decimal Amount { get; set; }
    public string TransactionName { get; set; } = null!;
    public string Description { get; set; } = null!;
    public DateTime Date { get; set; }
    public TransactionStatus Status { get; set; } = TransactionStatus.Pending;
    public string? AuthorizedUser { get; set; }
    public string? Icon { get; set; }
    public string DateDisplay { get; set; } = null!;
}
