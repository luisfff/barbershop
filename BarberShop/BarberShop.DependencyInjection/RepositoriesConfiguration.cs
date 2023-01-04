using BarberShop.Domain.Interfaces;
using BarberShop.Infrastructure;
using BarberShop.Infrastructure.Connection;
using BarberShop.Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace BarberShop.DependencyInjection
{
    public static class RepositoriesConfiguration
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<IBookingRepository, BookingRepository>();
            services.AddScoped<IConnectionProvider, ConnectionProvider>();

            return services;
        }
    }
}
