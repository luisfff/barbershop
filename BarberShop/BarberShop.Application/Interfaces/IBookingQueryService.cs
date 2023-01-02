using BarberShop.Application.Models;

namespace BarberShop.Application.Interfaces;

public interface IBookingQueryService
{
    Task<BookingResult> GetById(long id);
    Task<IEnumerable<BookingResult>> GetByUserId(long userId);
    Task<IEnumerable<BookingResult>> GetAll();
}