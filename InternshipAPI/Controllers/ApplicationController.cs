using Microsoft.AspNetCore.Mvc;
using InternshipAPI.Models;
using InternshipAPI.Repositories;
using Microsoft.AspNetCore.Authorization;
using InternshipAPI.DTOs;

namespace InternshipAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class ApplicationController: ControllerBase
    {
        private readonly IApplicationRepository _repository;

        public ApplicationController (IApplicationRepository repository)
        {
            _repository = repository;
        }

        // Application CRUD operations
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Application>>> GetAllApplications()
        {
            var applications = await _repository.GetAllApplications();
            return Ok(applications);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Application>> GetApplicationById(int id)
        {
            var application = await _repository.GetApplicationById(id);
            if (application == null) return NotFound();
            return Ok(application);
        }

        [HttpGet("company/{companyId}")]
        public async Task<ActionResult<Application>> GetApplicationByCompanyId(int companyId)
        {
            var companyApplication = await _repository.GetApplicationByCompanyId(companyId);
            if (companyApplication == null) return NotFound();
            return Ok(companyApplication);
        }

        [HttpPost]
        public async Task<ActionResult<Application>> AddApplication(ApplicationDto dto)
        {
            var application = new Application
            {
                ApplicationType = dto.ApplicationType,
                PositionTitle = dto.PositionTitle,
                ApplicationDate= dto.ApplicationDate,
                PortalLink=dto.PortalLink,
                OpenDate=dto.OpenDate,
                CloseDate=dto.CloseDate,
                UpdatedAt=dto.UpdatedAt,
                Notes=dto.Notes,
                UserID=dto.UserID,
                CompanyID=dto.CompanyID,
                StatusID=dto.StatusID
            };

            var newApplication = await _repository.AddApplication(application);

            return CreatedAtAction(nameof(GetApplicationById), new { id = newApplication.ApplicationID }, newApplication);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateApplication (int id, ApplicationDto dto)
        {
            var application = new Application
            {
                ApplicationType = dto.ApplicationType,
                PositionTitle = dto.PositionTitle,
                ApplicationDate= dto.ApplicationDate,
                PortalLink=dto.PortalLink,
                OpenDate=dto.OpenDate,
                CloseDate=dto.CloseDate,
                UpdatedAt=dto.UpdatedAt,
                Notes=dto.Notes
            };
            if (id != application.ApplicationID) return BadRequest();

            var updateApplication = await _repository.UpdateApplication(application);

            if (application == null) return NotFound();

            return Ok(updateApplication);

        }
    }
}
