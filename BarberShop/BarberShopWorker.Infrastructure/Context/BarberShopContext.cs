using BarberShopWorker.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;

namespace BarberShopWorker.Infrastructure.Context
{
    public class BarberShopContext : DbContext
    {
        public BarberShopContext(DbContextOptions<BarberShopContext> options)
            : base(options)
        {
        }

        public DbSet<BookingEntity> Bookings { get; set; }
    }
}