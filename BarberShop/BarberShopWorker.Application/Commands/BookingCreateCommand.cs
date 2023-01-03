using MediatR;

namespace BarberShopWorker.Application.Commands
{
    public class BookingCreateCommand : IRequest<Unit>
    {
        public long UserId { get; set; }
        public DateTime BookingDateTime { get; set; }
    }
}
