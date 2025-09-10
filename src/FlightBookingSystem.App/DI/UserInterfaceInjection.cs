using FlightBookingSystem.App.UserInterface;
using FlightBookingSystem.App.UserInterface.Contracts;
using Microsoft.Extensions.DependencyInjection;

namespace FlightBookingSystem.App.DI
{
    public static class UserInterfaceInjection
    {
        public static IServiceCollection AddConsoleUi(this IServiceCollection services)
        {
            services.AddSingleton<ILoginMenu, LoginMenu>();
            services.AddSingleton<IRegisterAircraft, RegisterAircraft>();
            services.AddSingleton<IRegisterDestination, RegisterDestination>();

            return services;
        }
    }
}
