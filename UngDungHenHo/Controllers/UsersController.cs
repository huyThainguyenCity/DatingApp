using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net.WebSockets;
using UngDungHenHo.Data;
using UngDungHenHo.DTOs;
using UngDungHenHo.Entities;
using UngDungHenHo.Interfaces;

namespace UngDungHenHo.Controllers
{
    [Authorize]
    public class UsersController(IUserRepository userRepository) : BaseApiController
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
    }
}
