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
    public class CompanyController : ControllerBase
    {
        private readonly IApplicationRepository _repository;

        public CompanyController(IApplicationRepository repository) => _repository = repository;

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CompanyResponseDto>>> GetAllCompanies()
        {
            var companies = await _repository.GetAllCompanies(User.GetUserId());
            return Ok(companies.Select(CompanyResponseDto.From));
        }
        
        [HttpGet("{id}")]
        public async Task<ActionResult<CompanyResponseDto>> GetCompanyById(int id)
        {
            var company = await _repository.GetCompanyById(id, User.GetUserId());
            if (company == null) return NotFound();
            return Ok(CompanyResponseDto.From(company));
        }

        [HttpPost]
        public async Task<ActionResult<CompanyResponseDto>> AddCompany(CompanyDto dto)
        {
            var userId = User.GetUserId();
            var name = dto.CompanyName.Trim();

            if (string.IsNullOrWhiteSpace(name)) return BadRequest("Company name is required.");
            if (await _repository.CompanyExists(name, userId))
                return Conflict("You already have a company with this name.");

            var created = await _repository.AddCompany(new Company
            {
                UserID = userId,
                CompanyName = name,
                Industry = dto.Industry,
                CompanyDescription = dto.CompanyDescription,
                IsWishlisted = dto.IsWishlisted
            });
            return CreatedAtAction(nameof(GetCompanyById), new { id = created.CompanyID },
                CompanyResponseDto.From(created));
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<CompanyResponseDto>> UpdateCompany(int id, CompanyDto dto)
        {
            var updated = await _repository.UpdateCompany(new Company
            {
                CompanyID = id,
                UserID = User.GetUserId(),
                CompanyName = dto.CompanyName.Trim(),
                Industry = dto.Industry,
                CompanyDescription = dto.CompanyDescription,
                IsWishlisted = dto.IsWishlisted
            });
            if (updated == null) return NotFound();
            return Ok(CompanyResponseDto.From(updated));
        }
    }
}