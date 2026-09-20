using JobApplication.Domain.Entities;

namespace JobApplication.Application.Interfaces
{
    public interface IJobRepository
    {
        Task AddJobAsync(Job job);
        Task<Job?> GetJobByIdAsync(int jobId);
        Task<IEnumerable<Job>> GetAllJobsAsync();
        Task UpdateJobAsync(Job job);
        Task CloseJob(Guid jobId);
        Task DeleteJobAsync(int jobId);
    }
}
