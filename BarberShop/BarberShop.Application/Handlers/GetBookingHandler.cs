using BarberShop.Application.Interfaces;
using BarberShop.Application.Models;

namespace BarberShop.Application.Handlers
{
    public class GetBookingHandler
    {
        private readonly IBookingQueryService _bookingQueryService;

        public GetBookingHandler(IBookingQueryService bookingQueryService)
        {
            _bookingQueryService = bookingQueryService;
        }

        public async Task<BookingResult> Handle(long id)
        {
            var result = await _bookingQueryService.GetById(id);
            return result;
        }
    }
}