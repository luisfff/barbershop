namespace BarberShopWorker.Domain.Models;

public record Booking
{
    public required BookingId Id { get; init; }
    public required long UserId { get; init; }
    public required DateTime BookingDateTime { get; init; }
    public required DateTime CreatedAt { get; init; }

}