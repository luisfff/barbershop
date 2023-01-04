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

    public class BarberShopContextFactory : IDbContextFactory<BarberShopContext>
    {
        public BarberShopContext CreateDbContext()
        {
            // Configure DbContext options and return a new instance of the context
            var optionsBuilder = new DbContextOptionsBuilder<BarberShopContext>();
            //optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=Blogging;Trusted_Connection=True;");
            return new BarberShopContext(optionsBuilder.Options);
        }
    }
}