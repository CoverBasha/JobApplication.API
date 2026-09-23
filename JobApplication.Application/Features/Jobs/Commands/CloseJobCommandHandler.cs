using JobApplication.Application.DTOs.JobDtos;
using JobApplication.Application.Interfaces;
using JobApplication.Application.Services;
using MediatR;
using System.Net;

namespace JobApplication.Application.Features.Jobs.Commands
{
    public class CloseJobCommandHandler : IRequestHandler<CloseJobCommand, ServiceResponse<JobDto>>
    {
        private readonly IJobRepository jobRepository;

        public CloseJobCommandHandler(IJobRepository jobRepository)
        {
            this.jobRepository = jobRepository;
        }

        public async Task<ServiceResponse<JobDto>> Handle(CloseJobCommand request, CancellationToken cancellationToken)
        {
            var jobInDb = await jobRepository.GetJobByIdAsync(request.JobId);

            if (jobInDb == null)
                return new()
                {
                    Status = Status.NotFound,
                    Message = "Job not found.",
                };
            if (jobInDb.RecruiterId != request.UserId)
                return new()
                {
                    Status = Status.Unauthorized,
                    Message = "You are not authorized to close this job.",
                };
            if (jobInDb.IsClosed)
                return new()
                {
                    Status = Status.Error,
                    Message = "Job is already closed.",
                };

            var job = await jobRepository.CloseJob(jobInDb);

            return new()
            {
                Status = Status.Success,
                Message = "Job closed successfully.",
                Result = new JobDto
                {
                    Id = job.Id,
                    Title = job.Title,
                    Description = job.Description,
                    IsClosed = job.IsClosed,
                    ClosedAt = job.ClosedAt
                }
            };
        }
    }
}
