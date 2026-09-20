using JobApplication.Application.DTOs.JobDtos;
using JobApplication.Application.Services;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace JobApplication.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class JobsController : Controller
    {
        private readonly JobService jobService;

        public JobsController(JobService jobService)
        {
            this.jobService = jobService;
        }

        [HttpPost]
        public IActionResult CreateJob([FromBody]CreateJobDto dto)
        {
            var userId = Guid.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);

            var response = jobService.CreateJobAsync(dto, userId);

            return Ok(response);
        }

        [HttpDelete("{jobId:guid}")]
        public IActionResult CloseJob([FromRoute] Guid jobId)
        {
            var userId = Guid.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);

            var response = jobService.CloseJob(jobId, userId);

            return Ok(response);
        }
    }
}
