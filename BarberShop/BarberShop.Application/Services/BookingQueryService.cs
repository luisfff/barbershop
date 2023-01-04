﻿using BarberShop.Application.Interfaces;
using AutoMapper;

using BarberShop.Application.Models;
using BarberShop.Domain.Interfaces;

namespace BarberShop.Application.Services
{
    public class BookingQueryService : IBookingQueryService
    {
        private readonly IBookingRepository _bookingRepository;
        private readonly IMapper _mapper;

        public BookingQueryService(IBookingRepository bookingRepository, IMapper mapper)
        {
            _bookingRepository = bookingRepository;
            _mapper = mapper;
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
            var bookings = await _bookingRepository.GetAll();
            var result = _mapper.Map<IEnumerable<BookingResult>>(bookings);

            return result;
        }
    }
}