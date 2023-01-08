
using Microsoft.EntityFrameworkCore;
using BarberShopWorker.Domain;
using BarberShopWorker.Domain.Models;
using BarberShopWorker.Infrastructure.Context;
using BarberShopWorker.Infrastructure.Entities;

namespace BarberShopWorker.Infrastructure.Repositories
{
    public class BookingRepository : IBookingRepository
    {
        private readonly IDbContextFactory<BarberShopContext> _context;

        public BookingRepository(IDbContextFactory<BarberShopContext> context)
        {
            _context = context;
        }
        public async Task Create(Booking booking)
        {
            await using var ctx = await _context.CreateDbContextAsync();

            var bookingEntity = new BookingEntity
            {
                UserId = booking.UserId,
                BookingDateTime = booking.BookingDateTime
            };

            ctx.Add(bookingEntity);

            await ctx.SaveChangesAsync();
        }
    }
}