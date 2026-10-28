using Microsoft.AspNetCore.Mvc;
using InternshipAPI.Repositories;
using InternshipAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace InternshipAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StatusController : ControllerBase
    {
        private readonly IApplicationRepository _repository;

        public StatusController(IApplicationRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ApplicationStatus>>> GetAllStatuses()
        {
            var statuses = await _repository.GetAllStatuses();
            return Ok(statuses);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ApplicationStatus>> GetStatusById(int id)
        {
            var status = await _repository.GetStatusById(id);
            if (status == null)
            {
                return NotFound();
            }
            return Ok(status);
        }
    }
}