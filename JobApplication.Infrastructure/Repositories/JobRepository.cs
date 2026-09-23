using JobApplication.Application.Interfaces;
using JobApplication.Domain.Entities;
using JobApplication.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata.Ecma335;

namespace JobApplication.Infrastructure.Repositories
{
    public class JobRepository : IJobRepository
    {
        private readonly ApplicationDbContext context;

        public JobRepository(ApplicationDbContext context)
        {
            this.context = context;
        }

        public async Task AddJobAsync(Job job)
        {
            await context.Jobs.AddAsync(job);
            await context.SaveChangesAsync();
        }

        public async Task<Job?> GetJobByIdAsync(Guid jobId)
        {
            return await context.Jobs.SingleOrDefaultAsync(j => j.Id == jobId);
        }

        public async Task<IEnumerable<Job>> GetAllJobsAsync()
        {
            return await context.Jobs.ToListAsync();
        }

        public async Task UpdateJobAsync(Job job)
        {
            context.Jobs.Update(job);
            await context.SaveChangesAsync();
        }

        public async Task<Job> CloseJob(Job job)
        {

            job.IsClosed = true;
            job.ClosedAt = DateTime.UtcNow;
            await context.SaveChangesAsync();

            return job;
        }

        public async Task DeleteJobAsync(int jobId)
        {
            var job = await context.Jobs.FindAsync(jobId);
            if (job != null)
            {
                context.Jobs.Remove(job);
                await context.SaveChangesAsync();
            }
        }
    }
}
