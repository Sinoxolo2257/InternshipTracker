using InternshipAPI.DTOs;
using InternshipAPI.Extensions;
using InternshipAPI.Models;
using InternshipAPI.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static InternshipAPI.DTOs.ResponseDtos;

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

        [HttpGet("me")]
        [Authorize]
        public async Task<ActionResult<UserResponseDto>> GetCurrentUser()
        {
            var user = await _repository.GetUserById(User.GetUserId());
            if (user == null) return NotFound();
            return Ok(UserResponseDto.From(user));
        }

        [HttpPost("register")]
        [AllowAnonymous]
        public async Task<ActionResult<UserResponseDto>> AddUser(RegisterDto dto)
        {
            var email= dto.EmailAddress.Trim();

            if(await _repository.GetUserByEmail(email) != null)
            {
                return Conflict("Email address already in use.");
            }
            var user= new User
            {
                Name = dto.Name,
                Surname = dto.Surname,
                EmailAddress = dto.EmailAddress,
            };

            var newUser = await _repository.AddUser(user, dto.Password);
            return CreatedAtAction(nameof(GetCurrentUser), new { id = newUser.UserID }, UserResponseDto.From(newUser));
        }

        [HttpDelete("me")]
        [Authorize]
        public async Task<IActionResult> DeleteAccount()
        {
            var deletedUser = await _repository.DeleteAccount(User.GetUserId());
            if (deletedUser == null) return NotFound();
            return NoContent();
        }
    }
}
