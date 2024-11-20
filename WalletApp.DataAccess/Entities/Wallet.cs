namespace WalletApp.DataAccess.Entities;
public class Wallet
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public decimal Balance { get; set; }
    public decimal CardLimit { get; set; } = 1500;
}
