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
    public class ListingController : ControllerBase
    {
        private readonly IApplicationRepository _repository;

        public ListingController(IApplicationRepository repository) => _repository = repository;

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ListingResponseDto>>> GetAllListings()
        {
            var listings = await _repository.GetAllListings(User.GetUserId());
            return Ok(listings.Select(ListingResponseDto.From));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ListingResponseDto>> GetListingById(int id)
        {
            var listing = await _repository.GetListingById(id, User.GetUserId());
            if (listing == null) return NotFound();
            return Ok(ListingResponseDto.From(listing));
        }

        [HttpPost]
        public async Task<ActionResult<ListingResponseDto>> AddListing(ListingDto dto)
        {
            var userId = User.GetUserId();
            if (await _repository.GetCompanyById(dto.CompanyID, userId) == null)
                return BadRequest("Company not found.");
            if (dto.OpenDate != null && dto.OpenDate > dto.CloseDate)
                return BadRequest("Open date can't be after the closing date.");

            var created = await _repository.AddListing(Map(dto, userId));
            return CreatedAtAction(nameof(GetListingById), new { id = created.ListingID },
                ListingResponseDto.From(created));
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<ListingResponseDto>> UpdateListing(int id, ListingDto dto)
        {
            var userId = User.GetUserId();
            if (await _repository.GetCompanyById(dto.CompanyID, userId) == null)
                return BadRequest("Company not found.");
            if (dto.OpenDate != null && dto.OpenDate > dto.CloseDate)
                return BadRequest("Open date can't be after the closing date.");

            var listing = Map(dto, userId);
            listing.ListingID = id;

            var updated = await _repository.UpdateListing(listing);
            if (updated == null) return NotFound();
            return Ok(ListingResponseDto.From(updated));
        }

        private static Listing Map(ListingDto dto, int userId) => new()
        {
            UserID = userId,
            CompanyID = dto.CompanyID,
            Title = dto.Title.Trim(),
            Type = dto.Type,
            Location = dto.Location,
            DatePosted = dto.OpenDate,
            ClosingDate = dto.CloseDate,
            Requirements = dto.Requirements,
            Description = dto.Description,
            ApplicationLink = dto.ApplicationLink
        };
    }
}