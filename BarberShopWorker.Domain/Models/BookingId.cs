namespace BarberShopWorker.Domain.Models;

public sealed record BookingId(long Value)
{
    public static readonly BookingId Empty = new(-1);
}