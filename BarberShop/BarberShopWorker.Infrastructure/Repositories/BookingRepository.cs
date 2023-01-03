

using BarberShopWorker.Domain;
using BarberShopWorker.Domain.Models;

namespace BarberShopWorker.Infrastructure.Repositories
{
    public class BookingRepository : IBookingRepository
    {
        private readonly IConnectionProvider _connectionProvider;

        public BookingRepository(IConnectionProvider connectionProvider)
        {
            _connectionProvider = connectionProvider;
        }
        public async Task<Booking> Create(Booking booking)
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




        private record BookingDto(long Id, long UserId, DateTime BookingDateTime);

    }
}