﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;
using System.Text;
using UngDungHenHo.Data;
using UngDungHenHo.DTOs;
using UngDungHenHo.Entities;
using UngDungHenHo.Interfaces;

namespace UngDungHenHo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController(DataContext context, ITokenService tokenService) : BaseApiController
    {
        [HttpPost("register")] //account/register

        public async Task<ActionResult<UserDto>> Register (RegisterDto registerDto)
        {
            if (await UserExist(registerDto.Username))
            {
                return BadRequest("Tên tài khoản đã tồn tại!");
            }
            return Ok();
            //using var hmac = new HMACSHA512();

            //var user = new AppUser
            //{
            //    UserName = registerDto.Username.ToLower(),
            //    PasswordHard = hmac.ComputeHash(Encoding.UTF8.GetBytes(registerDto.Password)),
            //    PasswordSalt = hmac.Key
            //};

            //context.Users.Add(user);
            //await context.SaveChangesAsync();
            //return new UserDto
            //{
            //    Username = user.UserName,
            //    Token = tokenService.CreateToken(user)
            //};
        }

        [HttpPost("login")]
        public async Task<ActionResult<UserDto>> Login(LoginDto loginDto)
        {
            var user = await context.Users.FirstOrDefaultAsync(x => x.UserName == loginDto.Username.ToLower());
            
            if(user == null)
            {
                return Unauthorized("Không tìm thấy tài khoản");
            }

            using var hmac = new HMACSHA512(user.PasswordSalt);

            var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(loginDto.Password));

            for (int i = 0; i < computedHash.Length; i++)
            {
                if (computedHash[i] != user.PasswordHard[i])
                {
                    return Unauthorized("Mật khẩu không chính xác");
                }
            }
            return new UserDto
            {
                Username = user.UserName,
                Token = tokenService.CreateToken(user)
            };
        }

        private async Task<bool> UserExist(string username)
        {
            return await context.Users.AnyAsync(x => x.UserName.ToLower() == username.ToLower());
        }
    }
}
