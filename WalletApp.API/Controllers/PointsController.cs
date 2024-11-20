using Microsoft.AspNetCore.Mvc;
using WalletApp.BusinessLogic.Helpers;
using WalletApp.BusinessLogic.Services.Implementations;
using WalletApp.BusinessLogic.Services.Interfaces;

namespace WalletApp.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PointsController : ControllerBase
{
    private readonly IUserService _userService;

    public PointsController(IUserService userService)
    {
        _userService = userService;
    }


    [HttpGet("{userId}/daily-points")]
    public async Task<IActionResult> GetDailyPoints(Guid userId, CancellationToken cancellationToken)
    {
        var user = await _userService.GetUserWithWalletAsync(userId, cancellationToken);
        if (user == null)
        {
            return NotFound();
        }

        // Calculate daily points
        var pointsCalculator = new PointsCalculator();
        int dailyPoints = pointsCalculator.CalculateDailyPoints(DateTime.UtcNow);

        // Format the points using the FormatPoints method
        string formattedDailyPoints = PointFormatter.FormatPoints(dailyPoints);

        return Ok(new
        {
            UserId = userId,
            FormattedDailyPoints = formattedDailyPoints
        });
    }

}