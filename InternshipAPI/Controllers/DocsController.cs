using Microsoft.AspNetCore.Mvc;
using InternshipAPI.Models;
using InternshipAPI.Repositories;

namespace InternshipAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DocsController : ControllerBase
    {
        private readonly IApplicationRepository _repository;

        public DocsController(IApplicationRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CVDoc>>> GetAllCvs()
        {
            return Ok(await _repository.GetAllCVs());
        }

        [HttpGet ("{id}")]
        public async Task<ActionResult<CVDoc>> GetCVById(int id)
        { 
            var cv = await _repository.GetCVById(id);
            if (cv==null) return NotFound();
            return Ok(cv);
        }

        [HttpPost]
        public async Task<ActionResult<CVDoc>> AddCVDoc(CVDoc cvDoc)
        {
            var newDoc = await _repository.AddCVDoc(cvDoc);
            return CreatedAtAction(nameof(GetCVById), new { id = newDoc.VersionID }, newDoc);
        }

        [HttpPatch("{id}/archive")]
        public async Task<IActionResult> ArchiveDoc(int id)
        {
            var archiveDoc = await _repository.ArchiveDoc(id);
            if (archiveDoc == null) return NotFound();
            return Ok(archiveDoc);
        }
    }
}
