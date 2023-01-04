using BarberShopWorker.Application.Commands;
using BarberShopWorker.Application.Handlers;
using BarberShopWorker.Domain;
using BarberShopWorker.Infrastructure.Context;
using BarberShopWorker.Infrastructure.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;

namespace BarberShopWorker.Configuration
{
    internal static class RepositoriesConfiguration
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {

            services.AddScoped<IBookingRepository, BookingRepository>();
            services.AddDbContextFactory<BarberShopContext, BarberShopContextFactory>();
          //  services.AddDbContext<BarberShopContext>();

            return services;
        }
    }
}