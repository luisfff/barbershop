using BarberShopWorker.Domain.Models;

namespace BarberShopWorker.Domain;

public interface IBookingRepository
{
    Task<Booking> Create(Booking booking);
}