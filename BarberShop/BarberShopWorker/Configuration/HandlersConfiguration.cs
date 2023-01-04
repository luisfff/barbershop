using BarberShopWorker.Application.Commands;
using BarberShopWorker.Application.Handlers;
using MediatR;

namespace BarberShopWorker.Configuration
{
    internal static class HandlersConfiguration
    {
        public static IServiceCollection AddHandlers(this IServiceCollection services)
        {
            services
                .AddTransient<IRequestHandler<BookingCreateCommand, Unit>, BookingCreatedCommandHandler>();

            return services;
        }
    }
}