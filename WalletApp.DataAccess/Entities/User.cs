namespace WalletApp.DataAccess.Entities;
public class User
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public virtual Wallet? Wallet { get; set; }
}
