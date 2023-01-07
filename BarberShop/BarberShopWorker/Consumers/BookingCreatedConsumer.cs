using BarberShop.Common;
using BarberShopWorker.Application.Commands;
using MediatR;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace BarberShopWorker.Consumers
{
    public class BookingCreatedConsumer : ConsumerBase, IHostedService
    {
        protected override string QueueName => "barbershop.booking.created";

        public BookingCreatedConsumer(
            IMediator mediator,
            ConnectionFactory connectionFactory) :
            base(mediator, connectionFactory)
        {

            var consumer = new AsyncEventingBasicConsumer(Channel);
            consumer.Received += OnEventReceived<BookingCreateCommand>;
            Channel.BasicConsume(queue: QueueName, autoAck: false, consumer: consumer);

        }

        public virtual Task StartAsync(CancellationToken cancellationToken) => Task.CompletedTask;

        public virtual Task StopAsync(CancellationToken cancellationToken)
        {
            Dispose();
            return Task.CompletedTask;
        }
    }
}
