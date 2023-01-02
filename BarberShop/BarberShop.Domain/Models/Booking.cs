namespace BarberShop.Domain.Models;

public record Booking
{
    public required long Id { get; init; }
    public required long UserId { get; init; }
    public required DateTime BookingDateTime { get; init; }

}