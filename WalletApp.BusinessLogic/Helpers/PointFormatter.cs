namespace WalletApp.BusinessLogic.Helpers;
public static class PointFormatter
{
    public static string FormatPoints(int points)
    {
        return points > 1000 ? $"{points / 1000}K" : points.ToString();
    }
}