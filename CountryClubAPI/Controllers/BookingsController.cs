using CountryClubAPI.DataAccess;
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
    }
}
