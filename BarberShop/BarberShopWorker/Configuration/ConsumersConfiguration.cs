using BarberShopWorker.Consumers;

namespace BarberShopWorker.Configuration
{
    internal static class ConsumersConfiguration
    {
        public static IServiceCollection AddConsumers(this IServiceCollection services)
        {
            services
                .AddHostedService<BookingCreatedConsumer>();

            return services;
        }
    }
}
