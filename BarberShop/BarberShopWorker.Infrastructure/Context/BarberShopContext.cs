using BarberShopWorker.Infrastructure.Entities;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.Configuration;

namespace BarberShopWorker.Infrastructure.Context
{
    public class BarberShopContext : DbContext
    {
        public DbContextOptions Options { get; }

        public BarberShopContext(DbContextOptions<BarberShopContext> dbContextOptions)
            : base(dbContextOptions)
        {
            Options = dbContextOptions;
        }

        internal BarberShopContext(string connectionString)
            : this(new DbContextOptionsBuilder<BarberShopContext>()
                .UseSqlite(connectionString).Options)
        {
        }

        public DbSet<BookingEntity> Bookings { get; set; }

    }

    public class BarberShopContextFactory : IDbContextFactory<BarberShopContext>
    {
        private readonly IConfiguration _configuration;

        public BarberShopContextFactory(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public BarberShopContext CreateDbContext()
        {
            var connectionString = _configuration.GetConnectionString("DbConnectionString");
            var optionsBuilder = new DbContextOptionsBuilder<BarberShopContext>();

            optionsBuilder.UseSqlite(connectionString);
            return new BarberShopContext(optionsBuilder.Options);
        }
    }
}