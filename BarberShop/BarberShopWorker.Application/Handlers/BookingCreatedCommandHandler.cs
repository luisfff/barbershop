using BarberShopWorker.Application.Commands;
using BarberShopWorker.Domain;
using BarberShopWorker.Domain.Models;
using MediatR;
using Microsoft.Extensions.Logging;

namespace BarberShopWorker.Application.Handlers
{
    public class BookingCreatedCommandHandler : IRequestHandler<BookingCreateCommand>
    {
        private readonly ILogger<BookingCreatedCommandHandler> _logger;
        private readonly IBookingRepository _bookingRepository;

        public BookingCreatedCommandHandler(ILogger<BookingCreatedCommandHandler> logger, IBookingRepository bookingRepository)
        {
            _logger = logger;
            _bookingRepository = bookingRepository;
        }

        public async Task<Unit> Handle(BookingCreateCommand request, CancellationToken cancellationToken)
        {
            var booking = new Booking
            {
                Id = -1,
                UserId = request.UserId,
                BookingDateTime = request.BookingDateTime
            };

            await _bookingRepository.Create(booking);

            _logger.LogInformation("---- Received message: {Message} ----", request.UserId);
            return await Task.FromResult(Unit.Value);
        }
    }

}
