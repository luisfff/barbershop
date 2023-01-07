using BarberShop.Domain.Interfaces;
using BarberShop.Domain.Models;
using BarberShop.Infrastructure.Connection;
using BarberShop.Infrastructure.Entities;
using BarberShop.Infrastructure.Extensions;
using Dapper;
using Microsoft.Extensions.Caching.Distributed;

namespace BarberShop.Infrastructure.Repositories
{
    public class BookingRepository : IBookingRepository
    {
        private const string RecordKey = "all_bookings";
        private readonly IConnectionProvider _connectionProvider;
        private readonly IDistributedCache _distributedCache;

        public BookingRepository(IConnectionProvider connectionProvider, IDistributedCache distributedCache)
        {
            _connectionProvider = connectionProvider;
            _distributedCache = distributedCache;
        }
        public async Task<Booking> Get(long id)
        {
            using var connection = _connectionProvider.GetConnection();

            const string query = @"SELECT b.Id, b.Userid, b.BookingDateTime FROM Bookings AS b WHERE b.Id = @id";

            var bookingEntity = await connection.QuerySingleAsync<BookingEntity>(query, new { id});

            var booking = new Booking
            {
                Id = bookingEntity.Id,
                UserId = bookingEntity.UserId,
                BookingDateTime = bookingEntity.BookingDateTime
            };

           return booking;
        }

        public async Task<IEnumerable<Booking>> GetByUserId(long userId)
        {
            using var connection = _connectionProvider.GetConnection();

            const string query = @"SELECT b.Id, b.Userid, b.BookingDateTime FROM Bookings AS b WHERE b.UserId = @userId";

            var bookingEntity = await connection.QueryAsync<BookingEntity>(query, new {userId});

            var bookings = bookingEntity.Select(x =>
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
            var cachedBookings = await GetAllBookingsCached();

            if (cachedBookings is not null)
            {
                return cachedBookings;
            }
            var bookings = await GetAllInternal();

            await SetAllBookingsCached(bookings);

            return bookings;

        }

        private async Task<IEnumerable<Booking>> GetAllInternal()
        {
            using var connection = _connectionProvider.GetConnection();

            const string query = @"SELECT b.Id, b.Userid, b.BookingDateTime FROM Bookings AS b";

            var bookingEntity = await connection.QueryAsync<BookingEntity>(query);

            var bookings = bookingEntity.Select(x =>
                new Booking
                {
                    Id = x.Id,
                    UserId = x.UserId,
                    BookingDateTime = x.BookingDateTime
                });

            return bookings;
        }

        private async Task<IEnumerable<Booking>> GetAllBookingsCached()
        {
            return await _distributedCache.GetRecordAsync<IEnumerable<Booking>>(RecordKey);
        }

        private async Task SetAllBookingsCached(IEnumerable<Booking> bookingResults)
        {
            await _distributedCache.SetRecordAsync(RecordKey, bookingResults, TimeSpan.FromSeconds(10));
        }
    }
}