using BarberShopWorker.Domain;
using BarberShopWorker.Infrastructure.Context;
using BarberShopWorker.Infrastructure.Repositories;

namespace BarberShopWorker.Configuration
{
    internal static class RepositoriesConfiguration
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<IBookingRepository, BookingRepository>();
            services.AddDbContextFactory<BarberShopContext, BarberShopContextFactory>();

            return services;
        }
    }
}