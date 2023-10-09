using CountryClubAPI.DataAccess;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CountryClubAPI.Models;

namespace CountryClubAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MembersController : ControllerBase
    {
        private readonly CountryClubContext _context;

        public MembersController(CountryClubContext context)
        {
            _context = context;
        }

        public IActionResult AllMembers()
        {
            var members = _context.Members;

            return new JsonResult(members);
        }

        [HttpGet("{id}")]
        public ActionResult GetMember(int id)
        {
            var member = _context.Members.Find(id);
            return new JsonResult(member);
        }

        [HttpPost]
        public ActionResult PostMember(Member member)
        {
            //Check if sent in model is valid
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            _context.Members.Add(member);
            _context.SaveChanges();

            var savedMember = _context.Members.OrderBy(m => m.Id).Last();

            Response.StatusCode = 201;
            return new JsonResult(savedMember);
        }

        [HttpPut]
        public ActionResult PutMember(Member member)
        {
            //Check if sent in model is valid
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            _context.Members.Update(member);
            _context.SaveChanges();

            var savedMember = _context.Members.Find(member.Id);

            Response.StatusCode = 204;
            return new JsonResult(savedMember);
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteMember(int id)
        {
            //If ID doesn't exist return bad request
            if(_context.Members.Find(id) == null)
            {
                return BadRequest();
            }

            var member = _context.Members.Find(id);
            _context.Members.Remove(member);
            _context.SaveChanges();

            Response.StatusCode = 204;
            return new JsonResult(_context.Members);
        }
    }
}
