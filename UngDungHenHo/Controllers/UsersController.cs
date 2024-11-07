using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UngDungHenHo.Data;
using UngDungHenHo.Entities;

namespace UngDungHenHo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        public readonly DataContext _context;
        public UsersController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<AppUser>>> ListUser()
        {
            var users = await _context.Users.ToListAsync();
            return Ok(users);
        }

        [HttpGet("{id:int}")] //api/id
        public async Task<ActionResult<AppUser>> GetUser(int id)
        {
            var users = await _context.Users.FindAsync(id);
            if(users == null)
            {
                return NotFound();
            }
            return Ok(users);
        }
    }
}
