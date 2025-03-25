using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net.WebSockets;
using System.Security.Claims;
using UngDungHenHo.Data;
using UngDungHenHo.DTOs;
using UngDungHenHo.Entities;
using UngDungHenHo.Interfaces;

namespace UngDungHenHo.Controllers
{
    [Authorize]
    public class UsersController(IUserRepository userRepository, IMapper mapper) : BaseApiController
    {
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MemberDto>>> GetUsers()
        {
            var users = await userRepository.GetMembersAsync();

            return Ok(users);
        }

        [HttpGet("{username}")] //api/id
        public async Task<ActionResult<MemberDto>> GetUser(string username)
        {
            var users = await userRepository.GetMemberAsync(username);
            if(users == null)
            {
                return NotFound();
            }
            return users;
        }

        [HttpPut]
        public async Task<ActionResult> UpdateUser(MemberUpdateDto memberUpdateDto)
        {
            var username = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (username == null) return BadRequest("No username found in token");

            var user = await userRepository.GetUserByUsernameAsync(username);

            if (user == null) return BadRequest("Could not find user");

            mapper.Map(memberUpdateDto, user);

            userRepository.Update(user);

            if (await userRepository.SaveAllAsync()) return NoContent();

            return BadRequest("Failed to update the user");
        }
    }
}
