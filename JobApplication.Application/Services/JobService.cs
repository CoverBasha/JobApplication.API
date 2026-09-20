using JobApplication.Application.DTOs.JobDtos;
using JobApplication.Application.Interfaces;
using JobApplication.Domain.Entities;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace JobApplication.Application.Services
{
    public class JobService
    {
        private readonly IJobRepository jobRepository;

        public JobService(IJobRepository jobRepository)
        {
            this.jobRepository = jobRepository;
        }

        public async Task<ServiceResponse<JobDto>> CreateJobAsync(CreateJobDto createJobDto, Guid userId)
        {
            //Validation would be here when identity and roles are implemented.
            //For now, we will assume that the user is authorized to create a job.

            var job = new Job
            {
                Id = Guid.NewGuid(),
                Title = createJobDto.Title,
                Description = createJobDto.Description,
                IsActive = createJobDto.IsActive,
            };

            await jobRepository.AddJobAsync(job);

            var jobdto = new JobDto
            {
                Id = job.Id,
                Title = job.Title,
                Description = job.Description,
                IsActive = job.IsActive,
                IsClosed = job.IsClosed,
                ClosedAt = job.ClosedAt
            };

            return new ServiceResponse<JobDto>
            {
                IsSuccess = true,
                Message = "Job created successfully.",
                Result = jobdto
            };
        }

        public async Task<ServiceResponse<bool>> CloseJob(Guid jobId, Guid userId)
        {
            //Validation would be here when identity and roles are implemented.


            await jobRepository.CloseJob(jobId);

            return new()
            {
                IsSuccess = true,
                Message = "Job closed successfully.",
                Result = true
            };
        }
    }
}
