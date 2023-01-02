namespace BarberShop.Application.Models
{
    public record BookingInputModel(long Id, long UserId, DateTime BookingTime, DateTime CreatedAt);
}