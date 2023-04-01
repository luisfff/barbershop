using BarberShop.Application.Interfaces;
using BarberShop.Application.Models;

namespace BarberShop.Application.Handlers.Booking
{
    public class GetAllBookingsHandler
    {
        private readonly IBookingQueryService _bookingQueryService;

        public GetAllBookingsHandler(IBookingQueryService bookingQueryService)
        {
            _bookingQueryService = bookingQueryService;
        }

        public async Task<IEnumerable<BookingResult>> Handle()
        {
            var result = await _bookingQueryService.GetAll();
            return result;
        }
    }
}