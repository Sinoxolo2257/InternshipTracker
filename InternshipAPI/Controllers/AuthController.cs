using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using InternshipAPI.Models;
using InternshipAPI.Data;
using InternshipAPI.Repositories;
using InternshipAPI.DTOs;

namespace InternshipAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController: ControllerBase
    {
        private readonly IConfiguration _config;
        private readonly IApplicationRepository _repo;

        public AuthController(IConfiguration config, IApplicationRepository repo)
        {
            _config = config;
            _repo = repo;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDto dto)
        {

            var login = await _repo.GetUserByEmail(dto.EmailAddress);

            if (login == null) return Unauthorized();
            
            if (BCrypt.Net.BCrypt.Verify(dto.Password, login.PasswordHash))
            {
                var token = GenerateToken(dto.EmailAddress);
                return Ok(new {token});
            }
            else
            {
                return Unauthorized("Invalid email or password");
            }

            

        }

        private string GenerateToken( string email)
        {
            var claims = new[]
            {
                new Claim(ClaimTypes.Email, email)
            };

            var key = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(_config["Jwt:Key"]!)
            );

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: _config["Jwt:Issuer"],
                audience: _config["Jwt:Audience"],
                claims: claims,
                expires: DateTime.Now.AddMinutes(30),
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
