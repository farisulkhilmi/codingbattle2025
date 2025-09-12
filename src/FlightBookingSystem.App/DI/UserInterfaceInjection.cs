using FlightBookingSystem.App.UserInterface;
using FlightBookingSystem.App.UserInterface.Contracts;
using FlightBookingSystem.Application.Abstractions;
using FlightBookingSystem.Infrastructure.Persistence.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace FlightBookingSystem.App.DI
{
    public static class UserInterfaceInjection
    {
        public static IServiceCollection AddConsoleUi(this IServiceCollection services)
        {
            services.AddScoped<ILoginMenu, LoginMenu>();
            services.AddScoped<IRegisterAircraft, RegisterAircraft>();
            services.AddScoped<IRegisterDestination, RegisterDestination>();
            services.AddScoped<IRegisterFlightRoute, RegisterFlightRoute>();
            services.AddScoped<IOrderFlight, OrderFlight>();

            return services;
        }
    }
}
