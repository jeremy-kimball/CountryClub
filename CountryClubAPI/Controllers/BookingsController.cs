using CountryClubAPI.DataAccess;
using CountryClubAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace CountryClubAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingsController : Controller
    {
        private readonly CountryClubContext _context;

        public BookingsController(CountryClubContext context)
        {
            _context = context;
        }

        public ActionResult AllBookings()
        {
            var bookings = _context.Bookings;
            return new JsonResult(bookings);
        }

        [HttpPost]
        public ActionResult CreateBooking(Booking booking)
        {
            //Check if sent in model is valid
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            _context.Bookings.Add(booking);
            _context.SaveChanges();

            var savedBooking = _context.Bookings.OrderBy(m => m.Id).Last();

            Response.StatusCode = 201;
            return new JsonResult(savedBooking);
        }
    }
}
