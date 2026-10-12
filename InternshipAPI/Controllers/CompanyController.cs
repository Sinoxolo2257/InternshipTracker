using Microsoft.EntityFrameworkCore;
using InternshipAPI.Repositories;
using Microsoft.AspNetCore.Mvc;
using InternshipAPI.Models;
using InternshipAPI.DTOs;

namespace InternshipAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CompanyController: ControllerBase
    {
        private readonly IApplicationRepository _repository;

        public CompanyController(IApplicationRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Company>>> GetAllCompanies()
        {
            return Ok(await _repository.GetAllCompanies());
        }

        [HttpGet("id")]
        public async Task<ActionResult<Company?>> GetCompanyById(int id)
        {
            var company = await _repository.GetCompanyById(id);
            if (company == null) return NotFound();
            return Ok(company);
        }

        [HttpPost]
        public async Task<ActionResult<Company>> AddCompany(CompanyDto dto)
        {
            var company = new Company
            {
                CompanyName = dto.CompanyName,
                Industry = dto.Industry,
                CompanyDescription = dto.CompanyDescription,
                Location = dto.Location,
                IsWishlisted = dto.IsWishlisted
            };

            var newCompany = await _repository.AddCompany(company);
            return CreatedAtAction(nameof(GetCompanyById), new { id = newCompany.CompanyID }, newCompany);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCompany(int id, CompanyDto dto)
        {
            var company = new Company
            {
                CompanyID = id,
                CompanyName = dto.CompanyName,
                Industry = dto.Industry,
                CompanyDescription = dto.CompanyDescription,
                Location = dto.Location,
                IsWishlisted = dto.IsWishlisted
            };

            if (id != company.CompanyID) return BadRequest();
            var updateCompany = await _repository.UpdateCompany(company);
            if (updateCompany == null) return NotFound();
            return Ok(updateCompany);
        }
    }
}
