namespace WalletApp.BusinessLogic.Services.Implementations;
public class PointsCalculator
{
    public int CalculateDailyPoints(DateTime date)
    {
        // Define the start dates for each season
        var seasonStartDates = new Dictionary<string, DateTime>
            {
                { "Spring", new DateTime(date.Year, 3, 1) },
                { "Summer", new DateTime(date.Year, 6, 1) },
                { "Autumn", new DateTime(date.Year, 9, 1) },
                { "Winter", new DateTime(date.Year, 12, 1) }
            };

        var currentSeason = seasonStartDates
            .Where(kv => date >= kv.Value && date < kv.Value.AddMonths(3))
            .Select(kv => kv.Key)
            .FirstOrDefault();

        if (currentSeason == null)
        {
            return 0;
        }

        var dailyPoints = new Dictionary<DateTime, int>();

        for (var d = seasonStartDates[currentSeason]; d <= date; d = d.AddDays(1))
        {
            int points;
            if (d.Date == seasonStartDates[currentSeason].Date)
            {
                points = 2; // First day of the season
            }
            else if (d.Date == seasonStartDates[currentSeason].Date.AddDays(1))
            {
                points = 3; // Second day of the season
            }
            else
            {
                points = CalculateNextPoints(dailyPoints, d);
            }

            dailyPoints[d] = points;
        }

        return dailyPoints.TryGetValue(date, out int dailyPointValue) ? dailyPointValue : 0;
    }

    private int CalculateNextPoints(Dictionary<DateTime, int> dailyPoints, DateTime currentDate)
    {
        var previousDate = currentDate.AddDays(-1);
        var twoDaysAgo = currentDate.AddDays(-2);

        if (!dailyPoints.TryGetValue(previousDate, out int previousPoints) ||
            !dailyPoints.TryGetValue(twoDaysAgo, out int twoDaysAgoPoints))
        {
            return 0;
        }

        return (int)Math.Round(previousPoints + (twoDaysAgoPoints * 0.6));
    }
}
