using JobApplication.Application.DTOs.JobDtos;
using JobApplication.Application.Features.Jobs.Commands;
using JobApplication.Application.Services;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace JobApplication.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class JobsController : Controller
    {


        private readonly JobService jobService;
        private readonly IMediator mediator;

        public JobsController(JobService jobService,IMediator mediator)
        {
            this.jobService = jobService;
            this.mediator = mediator;
        }

        [HttpPost]
        public IActionResult CreateJob([FromBody]CreateJobDto dto)
        {
            var userId = Guid.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);

            var response = jobService.CreateJobAsync(dto, userId);

            return Ok(response);
        }

        [HttpPut("{jobId:guid}")]
        public IActionResult CloseJob([FromRoute] Guid jobId)
        {
            var userId = Guid.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);

            var response = mediator.Send(new CloseJobCommand
            {
                JobId = jobId,
                UserId = userId
            }).Result;

            if (response.Status == Status.NotFound)
                return NotFound(response.Message);
            if(response.Status == Status.Unauthorized)
                return Unauthorized(response.Message);
            if(response.Status == Status.Error)
                return BadRequest(response.Message);

            return Ok(response.Result);
        }
    }
}
