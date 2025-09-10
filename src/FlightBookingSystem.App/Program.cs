using FlightBookingSystem.App.DI;
using FlightBookingSystem.App.Menu;
using FlightBookingSystem.App.UserInterface.Contracts;
using FlightBookingSystem.Application.DependencyInjection;
using FlightBookingSystem.Infrastructure;
using FlightBookingSystem.Infrastructure.DependencyInjection;
using FlightBookingSystem.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace FlightBookingSystem.App
{
    internal static class Program
    {
        private static void Main(string[] args)
        {
            var services = new ServiceCollection()
                .RegisterApplication()
                .RegisterInfrastructure()
                .AddConsoleUi()
                .BuildServiceProvider();

            using (var scope = services.CreateScope())
            {
                var db = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
                db.Database.EnsureCreated();
            }

            var login = services.GetRequiredService<ILoginMenu>();
            login.Show();
        }
    }
}