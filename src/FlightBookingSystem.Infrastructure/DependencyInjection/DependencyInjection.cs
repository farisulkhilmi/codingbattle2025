using FlightBookingSystem.Application.Abstractions;
using FlightBookingSystem.Infrastructure.Persistence;
using FlightBookingSystem.Infrastructure.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace FlightBookingSystem.Infrastructure.DependencyInjection
{
    public static class DependencyInjection
    {

        public static IServiceCollection RegisterInfrastructure(this IServiceCollection services, IConfiguration config)
        {
            var connString = config.GetConnectionString("DefaultConnection");
            services.AddDbContext<ApplicationDbContext>(opt => opt.UseSqlite(connString));

            services.AddScoped<IAircraftRepository, AircraftRepository>();
            services.AddScoped<IFlightRouteRepository, FlightRouteRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IDestinationRepository, DestinationRepository>();

            return services;
        }
    }
}
