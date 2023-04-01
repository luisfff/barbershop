using BarberShop.Application.Interfaces;
using BarberShop.Application.Models;

namespace BarberShop.Application.Handlers.Booking
{
    public class GetUserBookingsHandler
    {
        private readonly IBookingQueryService _bookingQueryService;

        public GetUserBookingsHandler(IBookingQueryService bookingQueryService)
        {
            _bookingQueryService = bookingQueryService;
        }

        public async Task<IEnumerable<BookingResult>> Handle(long userId)
        {
            var result = await _bookingQueryService.GetByUserId(userId);
            return result;
        }
    }
}