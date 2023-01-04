using BarberShop.Application.Events;
using BarberShop.Application.Interfaces;
using BarberShop.Application.Services;
using BarberShop.Application.Services.Producers;
using BarberShop.Common;
using Microsoft.Extensions.DependencyInjection;

namespace BarberShop.DependencyInjection
{
    public static class ServicesConfiguration
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped<IBookingQueryService, BookingQueryService>();
            services.AddSingleton<IRabbitMqProducer<BookingCreatedEvent>, BookingCreatedProducer>();

            return services;
        }
    }
}
