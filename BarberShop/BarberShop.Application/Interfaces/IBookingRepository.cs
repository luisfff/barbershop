using BarberShop.Domain.Models;

namespace BarberShop.Application.Interfaces;

public interface IBookingRepository
{
    Task<Booking> Get(long id);
    Task<IEnumerable<Booking>> GetByUserId(long userId);
    Task<IEnumerable<Booking>> GetAll();
}