using FlightBookingSystem.App.DI;
using FlightBookingSystem.App.UserInterface.Contracts;
using FlightBookingSystem.Application.DependencyInjection;
using FlightBookingSystem.Infrastructure.DependencyInjection;
using FlightBookingSystem.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace FlightBookingSystem.App
{
    internal static class Program
    {
        public static IHostBuilder CreateHostBuilder(string[] args)
        {
            return Host.CreateDefaultBuilder(args)
                .ConfigureLogging(logging =>
                {
                    logging.AddConsole();
                    logging.AddFilter("Microsoft.EntityFrameworkCore", LogLevel.Warning);
                    logging.AddFilter("Microsoft.EntityFrameworkCore.Database.Command", LogLevel.Warning);
                    logging.AddFilter("Microsoft.EntityFrameworkCore.Migrations", LogLevel.Warning);
                })
                .ConfigureAppConfiguration((ctx, cfg) =>
                {
                    cfg.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
                })
                .ConfigureServices((ctx, services) =>
                {
                    services
                        .RegisterApplication()
                        .RegisterInfrastructure(ctx.Configuration)
                        .AddConsoleUi();
                });
        }

        private static void Main(string[] args)
        {
            using var host = CreateHostBuilder(args).Build();

            using (var scope = host.Services.CreateScope())
            {
                var db = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
                db.Database.Migrate();
            }

            var login = host.Services.GetRequiredService<ILoginMenu>();
            login.Show();
        }
    }
}