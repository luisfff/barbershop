using BarberShopWorker.Domain.Models;

namespace BarberShopWorker.Domain;

public interface IBookingRepository
{
    Task Create(Booking booking);
}