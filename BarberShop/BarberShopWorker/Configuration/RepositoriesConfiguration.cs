using BarberShopWorker.Domain;
using BarberShopWorker.Infrastructure.Context;
using BarberShopWorker.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

namespace BarberShopWorker.Configuration
{
    internal static class RepositoriesConfiguration
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddTransient<IBookingRepository, BookingRepository>();
            services.AddDbContextFactory<BarberShopContext, BarberShopContextFactory>();

            //services.AddDbContextFactory<BarberShopContext>(
            //    options =>
            //        options.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=Test"));

            return services;
        }
    }
}