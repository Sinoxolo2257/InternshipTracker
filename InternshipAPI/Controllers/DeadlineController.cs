using Microsoft.AspNetCore.Mvc;
using InternshipAPI.Models;
using InternshipAPI.Data;
using Microsoft.EntityFrameworkCore;

namespace InternshipAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DeadlineController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public DeadlineController (ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet("closing-soon")]
        public async Task<IActionResult> GetClosingSoon()
        {
            var today = DateTime.Today;
            var in7days = today.AddDays(7);

            var closing = await _context.Applications
                .Where(a => a.CloseDate >= today && a.CloseDate <= in7days)
                .OrderBy(a => a.CloseDate)
                .ToListAsync();
            return Ok(closing);
        }

        [HttpGet("overdue")]
        public async Task<IActionResult> GetOverdue()
        {
            var today = DateTime.Today;

            var overdue = await _context.Applications
                .Where(a => a.CloseDate < today)
                .OrderBy(a => a.CloseDate)
                .ToListAsync();
            return Ok(overdue);
        }
    }
}
