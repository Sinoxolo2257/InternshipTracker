using InternshipAPI.DTOs;
using InternshipAPI.Extensions;
using InternshipAPI.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static InternshipAPI.DTOs.ResponseDtos;

namespace InternshipAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class DeadlineController : ControllerBase
    {
        private readonly IApplicationRepository _repository;

        public DeadlineController(IApplicationRepository repository) => _repository = repository;

        [HttpGet("closing-soon")]
        public async Task<ActionResult<IEnumerable<ApplicationResponseDto>>> GetClosingSoon([FromQuery] int days = 7)
        {
            var apps = await _repository.GetClosingSoon(User.GetUserId(), days);
            return Ok(apps.Select(ApplicationResponseDto.From));
        }

        [HttpGet("overdue")]
        public async Task<ActionResult<IEnumerable<ApplicationResponseDto>>> GetOverdue()
        {
            var apps = await _repository.GetOverdue(User.GetUserId());
            return Ok(apps.Select(ApplicationResponseDto.From));
        }
    }
}