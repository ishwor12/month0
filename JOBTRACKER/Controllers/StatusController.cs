using JOBTRACKER.Models.Enums;
using JOBTRACKER.Services.Interface;
using Microsoft.AspNetCore.Mvc;

namespace JOBTRACKER.Controllers
{
    [ApiController]
    [Route("api/jobs/{id}/status")]
    public class StatusController : ControllerBase
    {
        private readonly IJobService _jobService;
        public StatusController(IJobService jobservice)
        {
            _jobService = jobservice;
        }
      
    }
}
