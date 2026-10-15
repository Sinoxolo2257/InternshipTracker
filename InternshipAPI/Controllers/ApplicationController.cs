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
    [Authorize]
    public class ApplicationController : ControllerBase
    {
        private const int SavedStatusId = 1;
        private readonly IApplicationRepository _repository;

        public ApplicationController(IApplicationRepository repository) => _repository = repository;

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ApplicationResponseDto>>> GetAllApplications()
        {
            var apps = await _repository.GetAllApplications(User.GetUserId());
            return Ok(apps.Select(ApplicationResponseDto.From));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ApplicationResponseDto>> GetApplicationById(int id)
        {
            var app = await _repository.GetApplicationById(id, User.GetUserId());
            if (app == null) return NotFound();
            return Ok(ApplicationResponseDto.From(app));
        }

        [HttpGet("company/{companyId}")]
        public async Task<ActionResult<IEnumerable<ApplicationResponseDto>>> GetApplicationsByCompany(int companyId)
        {
            var apps = await _repository.GetApplicationsByCompany(companyId, User.GetUserId());
            return Ok(apps.Select(ApplicationResponseDto.From));
        }

        [HttpGet("status/{statusId}")]
        public async Task<ActionResult<IEnumerable<ApplicationResponseDto>>> GetApplicationsByStatus(int statusId)
        {
            if (await _repository.GetStatusById(statusId) == null)
                return BadRequest("Invalid status.");

            var apps = await _repository.GetApplicationsByStatus(statusId, User.GetUserId());
            return Ok(apps.Select(ApplicationResponseDto.From));
        }

        [HttpPost]
        public async Task<ActionResult<ApplicationResponseDto>> AddApplication(ApplicationDto dto)
        {
            var userId = User.GetUserId();

            if (await _repository.GetListingById(dto.ListingID, userId) == null)
                return BadRequest("Listing not found.");
            if (await _repository.ApplicationExists(dto.ListingID, userId))
                return Conflict("You already have an application for this listing.");
            if (await _repository.GetStatusById(dto.StatusID) == null)
                return BadRequest("Invalid status.");

            var cvError = await ValidateCv(dto, userId);
            if (cvError != null) return cvError;

            var application = new Application
            {
                UserID = userId,
                ListingID = dto.ListingID,
                VersionID = dto.VersionID,
                StatusID = dto.StatusID,
                SubmittedDate = dto.SubmittedDate,
                PortalLink = dto.PortalLink,
                Notes = dto.Notes,
                UpdatedAt = DateTime.UtcNow
            };

            var created = await _repository.AddApplication(application);
            return CreatedAtAction(nameof(GetApplicationById), new { id = created.ApplicationID },
                ApplicationResponseDto.From(created));
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<ApplicationResponseDto>> UpdateApplication(int id, ApplicationDto dto)
        {
            var userId = User.GetUserId();

            if (await _repository.GetStatusById(dto.StatusID) == null)
                return BadRequest("Invalid status.");

            var cvError = await ValidateCv(dto, userId);
            if (cvError != null) return cvError;

            var updated = await _repository.UpdateApplication(new Application
            {
                ApplicationID = id,
                UserID = userId,
                VersionID = dto.VersionID,
                StatusID = dto.StatusID,
                SubmittedDate = dto.SubmittedDate,
                PortalLink = dto.PortalLink,
                Notes = dto.Notes
            });

            if (updated == null) return NotFound();
            return Ok(ApplicationResponseDto.From(updated));
        }

        // A CV must belong to the user, and is required once past "Saved"
        private async Task<ActionResult?> ValidateCv(ApplicationDto dto, int userId)
        {
            if (dto.VersionID == null)
                return dto.StatusID == SavedStatusId ? null
                    : BadRequest("Attach a CV before marking the application as applied.");

            if (await _repository.GetCVById(dto.VersionID.Value, userId) == null)
                return BadRequest("CV not found.");
            return null;
        }
    }
}