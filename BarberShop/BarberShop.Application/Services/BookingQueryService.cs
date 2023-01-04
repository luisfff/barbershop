using BarberShop.Application.Interfaces;
using AutoMapper;
using BarberShop.Application.Extensions;
using BarberShop.Application.Models;
using BarberShop.Domain.Interfaces;
using Microsoft.Extensions.Caching.Distributed;

namespace BarberShop.Application.Services
{
    public class BookingQueryService : IBookingQueryService
    {
        private const string RecordKey = "_bookings";
        private readonly IBookingRepository _bookingRepository;
        private readonly IMapper _mapper;
        private readonly IDistributedCache _distributedCache;

        public BookingQueryService(IBookingRepository bookingRepository, IMapper mapper, IDistributedCache distributedCache )
        {
            _bookingRepository = bookingRepository;
            _mapper = mapper;
            _distributedCache = distributedCache;
        }

        public async Task<BookingResult> GetById(long id)
        {
           var booking = await  _bookingRepository.Get(id);
           var result = _mapper.Map<BookingResult>(booking);

           return result;
        }

        public async Task<IEnumerable<BookingResult>> GetByUserId(long userId)
        {
            var bookings = await _bookingRepository.GetByUserId(userId);
            var result = _mapper.Map<IEnumerable<BookingResult>>(bookings);
            return result;
        }

        public async Task<IEnumerable<BookingResult>> GetAll()
        {
            var cachedBookings = await GetAllCached();

            if (cachedBookings is not null)
            {
                return cachedBookings.ToList();
            }
            var bookings = await _bookingRepository.GetAll();
            var result = _mapper.Map<IEnumerable<BookingResult>>(bookings);

            await SetCachedBooking(result);

            return result;
        }

        private async Task<BookingResult[]> GetAllCached()
        {
            return await _distributedCache.GetRecordAsync<BookingResult[]>(RecordKey);
        }

        private async Task SetCachedBooking(IEnumerable<BookingResult> bookingResults)
        {
            await _distributedCache.SetRecordAsync(RecordKey, bookingResults, TimeSpan.FromSeconds(10));
        }
    }
}