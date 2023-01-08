namespace BarberShop.Application.Models
{
    public record BookingResult(long Id, long UserId, DateTime BookingDateTime, DateTime CreatedAt);

}