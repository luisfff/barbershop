namespace BarberShopWorker.Domain.Models;

public record Booking
{
    public required long Id { get; init; } = -1;
    public required long UserId { get; init; }
    public required DateTime BookingDateTime { get; init; }

}