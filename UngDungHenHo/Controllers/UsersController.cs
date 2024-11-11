using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UngDungHenHo.Data;
using UngDungHenHo.Entities;

namespace UngDungHenHo.Controllers
{
    public class UsersController(DataContext context) : BaseApiController
    {
        [AllowAnonymous]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AppUser>>> ListUser()
        {
            var users = await context.Users.ToListAsync();
            return Ok(users);
        }

        [Authorize]
        [HttpGet("{id:int}")] //api/id
        public async Task<ActionResult<AppUser>> GetUser(int id)
        {
            var users = await context.Users.FindAsync(id);
            if(users == null)
            {
                return NotFound();
            }
            return Ok(users);
        }
    }
}
