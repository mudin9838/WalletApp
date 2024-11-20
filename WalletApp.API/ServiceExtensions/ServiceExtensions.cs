using Microsoft.EntityFrameworkCore;
using WalletApp.BusinessLogic.Services.Implementations;
using WalletApp.BusinessLogic.Services.Interfaces;
using WalletApp.DataAccess.Data;

namespace WalletApp.API.ServiceExtensions;

public static class ServiceExtensions
{
    public static void AddApplicationServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddControllers()
            .AddJsonOptions(options =>
            {
                options.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.IgnoreCycles;
            });

        services.AddDbContext<WalletAppDbContext>(options =>
            options.UseNpgsql(configuration.GetConnectionString("DefaultConnection")));

        services.AddScoped<IUserService, UserService>();
        services.AddScoped<ITransactionService, TransactionService>();
        services.AddScoped<IWalletService, WalletService>();

        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();
    }
}
