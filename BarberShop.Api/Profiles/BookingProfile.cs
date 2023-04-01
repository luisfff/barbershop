using AutoMapper;
using BarberShop.Application.Models;
using BarberShop.Domain.Models;

namespace BarberShop.Api.Profiles
{
    internal class BookingProfile : Profile
    {
        public BookingProfile()
        {
            CreateMap<Booking, BookingResult>();
        }
    }
}
