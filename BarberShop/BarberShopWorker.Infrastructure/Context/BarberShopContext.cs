using BarberShopWorker.Infrastructure.Entities;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore.Sqlite;

namespace BarberShopWorker.Infrastructure.Context
{
    public class BarberShopContext : DbContext
    {
        public BarberShopContext(DbContextOptions<BarberShopContext> options)
            : base(options)
        {
        }

        public DbSet<BookingEntity> Bookings { get; set; }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlite("Data Source=mydatabase.db");
        //}
    }

    public class BarberShopContextFactory : IDbContextFactory<BarberShopContext>
    {
        public BarberShopContext CreateDbContext()
        {
            var optionsBuilder = new DbContextOptionsBuilder<BarberShopContext>();

         //   optionsBuilder.UseSqlite(@"Data Source=barbershop.sqlite;Pooling=true;");

            optionsBuilder.UseSqlite("Data Source=barbershop.db");
            return new BarberShopContext(optionsBuilder.Options);

          //  var conn = new SqliteConnection(@"Data Source=barbershop.sqlite;Pooling=true;");
  
            //optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=Blogging;Trusted_Connection=True;");
            //return new BarberShopContext(optionsBuilder.Options);
        }
    }
}