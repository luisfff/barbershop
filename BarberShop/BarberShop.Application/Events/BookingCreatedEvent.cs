namespace BarberShop.Application.Events
{
    public record BookingCreatedEvent(long UserId, DateTime BookingDateTime);

}