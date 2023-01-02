using BarberShop.Application.Models;

namespace BarberShop.Application.Handlers
{
    public class CreateBookingHandler
    {
        public CreateBookingHandler()
        {
        }

        public async Task<bool> Handle(BookingInputModel model)
        {
            return true;
        }
    }
}