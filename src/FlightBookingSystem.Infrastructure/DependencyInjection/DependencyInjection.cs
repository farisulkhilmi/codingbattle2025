using FlightBookingSystem.Application.Abstractions;
using FlightBookingSystem.Infrastructure.Persistence;
using FlightBookingSystem.Infrastructure.Persistence.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace FlightBookingSystem.Infrastructure.DependencyInjection
{
    public static class DependencyInjection
    {

        public static IServiceCollection RegisterInfrastructure(this IServiceCollection services)
        {
            services.AddDbContext<ApplicationDbContext>();

            services.AddScoped<IAircraftRepository, AircraftRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IDestinationRepository, DestinationRepository>();

            return services;
        }
    }
}
