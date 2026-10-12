using Microsoft.AspNetCore.Mvc;
using InternshipAPI.Repositories;
using InternshipAPI.Models;
using InternshipAPI.DTOs;

namespace InternshipAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IApplicationRepository _repository;

        public UserController(IApplicationRepository repository)
        {
            _repository = repository;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUserById(int id)
        {
            var user = await _repository.GetUserById(id);
            if (user == null) return NotFound();
            return Ok(user);
        }

        [HttpPost("register")]
        public async Task<ActionResult<User>> AddUser(RegisterDto dto)
        {
            var user= new User
            {
                Name = dto.Name,
                Surname = dto.Surname,
                EmailAddress = dto.EmailAddress,
                PasswordHash = BCrypt.Net.BCrypt.HashPassword(dto.Password)
            };

            var newUser = await _repository.AddUser(user);
            return CreatedAtAction(nameof(GetUserById), new { id = newUser.UserID }, newUser);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAccount(int id)
        {
            var deletedUser = await _repository.DeleteAccount(id);
            if (deletedUser == null) return NotFound();
            return NoContent();
        }
    }
}
