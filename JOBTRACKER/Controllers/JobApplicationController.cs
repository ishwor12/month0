using JOBTRACKER.Models;
using JOBTRACKER.Services.Interface;
using Microsoft.AspNetCore.Mvc;

namespace JOBTRACKER.Controllers
{
    [ApiController]
    [Route("api/jobs")]

    public class JobApplicationController : ControllerBase
    {
        private readonly IJobService _jobService;

        public JobApplicationController(IJobService jobService)
        {
            _jobService = jobService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
             => Ok(await _jobService.GetAllAsync());

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var job = await _jobService.GetByIdAsync(id);
            return job == null ? NotFound() : Ok(job);
        }

        [HttpPost]
        public async Task<IActionResult> Create(JobApplication job)
        {

            var created = await _jobService.CreateAsync(job);
            return CreatedAtAction(nameof(GetById), new { id = created.Id },created);

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var (success, message) = await _jobService.DeleteAsync(id);
            return success ? NoContent() : NotFound(message);
        }
    }
}
