using BarberShop.Application.Handlers;
using BarberShop.Application.Models;
using Microsoft.AspNetCore.Mvc;


namespace BarberShop.Api.Controllers
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("booking")]
    public class BookingController : ControllerBase
    {
        public BookingController( )
        {
        }

        [HttpGet("all")]
        public async Task<IActionResult> GetAll([FromServices] GetAllBookingsHandler handler)
        {
            var result = await handler.Handle();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get([FromServices] GetBookingHandler handler, [FromQuery]long id)
        {
            var result = await handler.Handle(id);
            return Ok(result);
        }

        [HttpPost()]
        public async Task<IActionResult> Create(BookingInputModel model)
        {
            return Ok();
        }

        [HttpPost()]
        public async Task<IActionResult> Update(BookingInputModel model)
        {
            return Ok();
        }
    }
}