using BarberShop.Application.Events;
using BarberShop.Common;
using RabbitMQ.Client;

namespace BarberShop.Application.Services.Producers
{
    public class BookingCreatedProducer : ProducerBase<BookingCreatedEvent>
    {
        public BookingCreatedProducer(
            ConnectionFactory connectionFactory) :
            base(connectionFactory)
        {
        }
        protected override string ExchangeName => "Barbershop.BookingExchange";

        protected override string Queue => "Barbershop.booking.created";
        protected override string RoutingKeyName => "booking.created";
        protected override string AppId => "BookingProducer";
    }

}
