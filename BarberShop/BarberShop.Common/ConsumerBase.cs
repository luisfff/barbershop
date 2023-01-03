﻿using System.Text;
using MediatR;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace BarberShop.Common
{
    public abstract class ConsumerBase : RabbitMqClientBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger<ConsumerBase> _logger;
        protected abstract string QueueName { get; }

        public ConsumerBase(
            IMediator mediator,
            ConnectionFactory connectionFactory) :
            base(connectionFactory)
        {
            _mediator = mediator;
        }

        protected virtual async Task OnEventReceived<T>(object sender, BasicDeliverEventArgs @event)
        {
            try
            {
                var body = Encoding.UTF8.GetString(@event.Body.ToArray());
                var message = JsonConvert.DeserializeObject<T>(body);

                await _mediator.Send(message);
            }
            catch (Exception ex)
            {
                _logger.LogCritical(ex, "Error while retrieving message from queue.");
            }
            finally
            {
                Channel.BasicAck(@event.DeliveryTag, false);
            }
        }
    }
}
