using BarberShop.Application.Events;
using BarberShop.Application.Models;
using BarberShop.Common;

namespace BarberShop.Application.Handlers.Booking
{
    public class CreateBookingHandler
    {
        private readonly IRabbitMqProducer<BookingCreatedEvent> _producer;

        public CreateBookingHandler(IRabbitMqProducer<BookingCreatedEvent> producer)
        {
            _producer = producer;
        }

        public async Task Handle(BookingInputModel model)
        {
            var @event = new BookingCreatedEvent(model.UserId, model.BookingTime);
            _producer.Publish(@event);
        }
    }
}