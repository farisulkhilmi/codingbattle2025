using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace FlightBookingSystem.Application.DependencyInjection
{
    public static class DependencyInjection
    {
        public static IServiceCollection RegisterApplication(this IServiceCollection services)
        {
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

            return services;
        }
    }
}
