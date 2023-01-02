using BarberShop.Domain.Models;

namespace BarberShop.Domain.Interfaces;

public interface IBookingRepository
{
    Task<Booking> Get(int id);
    Task<IEnumerable<Booking>> GetByUserId(int userId);
    Task<IEnumerable<Booking>> GetAll();
}