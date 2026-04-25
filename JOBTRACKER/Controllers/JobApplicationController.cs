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
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, JobApplication job)
        {
            var updated = await _jobService.UpdateStatusAsync(id, job);

            // Service returns null when job wasn't found
            if (updated == null)
                return NotFound(); // 404

            return Ok(updated); // 200 + updated job
        }

        [HttpDelete("{id}")]
        public async Task<bool> Delete(int id)
        {
          return await _jobService.DeleteAsync(id);
        }
    }
}
