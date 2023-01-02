using BarberShop.Domain.Interfaces;
using BarberShop.Domain.Models;
using Dapper;

namespace BarberShop.Infrastructure.Repositories
{
    public class BookingRepository : IBookingRepository
    {
        private readonly IConnectionProvider _connectionProvider;

        public BookingRepository(IConnectionProvider connectionProvider)
        {
            _connectionProvider = connectionProvider;
        }
        public async Task<Booking> Get(int id)
        {
            using var connection = _connectionProvider.GetConnection();

            var query = @"SELECT * FROM Booking AS b WHERE b.Id = @id";

            var bookingDto = await connection.QuerySingleAsync<BookingDto>(query, id);

            var booking = new Booking
            {
                Id = bookingDto.Id,
                UserId = bookingDto.UserId,
                BookingDateTime = bookingDto.BookingDateTime
            };

           return booking;
        }

        public async Task<IEnumerable<Booking>> GetByUserId(int userId)
        {
            using var connection = _connectionProvider.GetConnection();

            var query = @"SELECT * FROM Booking AS b WHERE b.UserId = @userId";

            var bookingsDto = await connection.QueryAsync<BookingDto>(query, userId);

            var bookings = bookingsDto.Select(x =>
                new Booking
                {
                    Id = x.Id,
                    UserId = x.UserId,
                    BookingDateTime = x.BookingDateTime
                });  

            return bookings;
        }


        public async Task<IEnumerable<Booking>> GetAll()
        {
            using var connection = _connectionProvider.GetConnection();

            var query = @"SELECT * FROM Booking";

            var bookingsDto = await connection.QueryAsync<BookingDto>(query);

            var bookings = bookingsDto.Select(x =>
                new Booking
                {
                    Id = x.Id,
                    UserId = x.UserId,
                    BookingDateTime = x.BookingDateTime
                });

            return bookings;
        }

        private record BookingDto(long Id, long UserId, DateTime BookingDateTime);

    }
}