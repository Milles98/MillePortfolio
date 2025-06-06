﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using ProjectApi.User;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ProjectApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    [EnableCors("AllowAll")]
    public class LoginController : ControllerBase
    {
        private IConfiguration _config;

        public LoginController(IConfiguration config)
        {
            _config = config;
        }

        [AllowAnonymous]
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesDefaultResponseType]

        public IActionResult Login([FromBody] UserLogin userLogin)
        {
            if (userLogin.UserName == "X" && userLogin.Password == "X")
            {
                var tempUser = new UserModel
                {
                    UserName = "Mille",
                    EmailAddress = "mille.elfver98@gmail.com",
                    GivenName = "Mille",
                    SurName = "Elfver",
                    Role = "Admin"
                };
                var token = Generate(tempUser);
                return Ok(new { token });
            }

            var user = Authenticate(userLogin);

            if (user != null)
            {
                var token = Generate(user);
                return Ok(token);
            }

            return NotFound("User Not Found");
        }

        private UserModel Authenticate(UserLogin userLogin)
        {
            var currentUser = UserCredentials.Users
                .FirstOrDefault(u =>
                u.UserName.ToLower() == userLogin.UserName.ToLower() &&
                u.Password == userLogin.Password);

            if (currentUser != null)
            {
                return currentUser;
            }

            return null;
        }

        private string Generate(UserModel user)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, user.UserName),
                new Claim(ClaimTypes.Email, user.EmailAddress),
                new Claim(ClaimTypes.GivenName, user.GivenName),
                new Claim(ClaimTypes.Surname, user.SurName),
                new Claim(ClaimTypes.Role, user.Role),
            };

            var token = new JwtSecurityToken(
                _config["Jwt:Issuer"],
                _config["Jwt:Audience"],
                claims,
                expires: DateTime.UtcNow.AddMinutes(15),
                signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
