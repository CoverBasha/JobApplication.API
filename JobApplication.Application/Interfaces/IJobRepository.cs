using JobApplication.Domain.Entities;

namespace JobApplication.Application.Interfaces
{
    public interface IJobRepository
    {
        Task AddJobAsync(Job job);
        Task<Job?> GetJobByIdAsync(Guid jobId);
        Task<IEnumerable<Job>> GetAllJobsAsync();
        Task UpdateJobAsync(Job job);
        Task<Job> CloseJob(Job job);
        Task DeleteJobAsync(int jobId);
    }
}
