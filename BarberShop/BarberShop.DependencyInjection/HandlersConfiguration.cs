using BarberShop.Application.Handlers.Booking;
using Microsoft.Extensions.DependencyInjection;

namespace BarberShop.DependencyInjection
{
    public static class HandlersConfiguration
    {
        public static IServiceCollection AddHandlers(this IServiceCollection services)
        {
            services.AddScoped<CreateBookingHandler>();
            services.AddScoped<GetAllBookingsHandler>();
            services.AddScoped<GetBookingHandler>();
            services.AddScoped<GetUserBookingsHandler>();

            return services;
        }
    }
}
