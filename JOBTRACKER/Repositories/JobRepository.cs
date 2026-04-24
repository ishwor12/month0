using JOBTRACKER.Data;
using JOBTRACKER.Models;
using JOBTRACKER.Models.Enums;
using Microsoft.EntityFrameworkCore;

namespace JOBTRACKER.Repositories
{
    public class JobRepository : IJobRepository
    {
        private readonly AppDbContext _context;

        public JobRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<JobApplication> AddAsync(JobApplication job)
        {
            _context.JobApplications.Add(job);
            await _context.SaveChangesAsync();
            return job;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var jobx = await GetByIdAsync(id);
            if (jobx == null) 
             return false;
           
            _context.JobApplications.Remove(jobx);

            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<JobApplication>> GetAllAsync()
        {
           return await _context.JobApplications.OrderByDescending(d => d.AppliedDate).ToListAsync();
        }

        public async Task<JobApplication?> GetByIdAsync(int id)
        {
           return await _context.JobApplications.FindAsync(id);
        }

        public async Task<IEnumerable<JobApplication>> GetByStatusAsync(ApplicationStatus status)
            => await _context.JobApplications.Where(x => x.Status == status).ToListAsync();
            
        public async Task<JobApplication> UpdateAsync(JobApplication job)
        {
            _context.JobApplications.Update(job);
            await _context.SaveChangesAsync();
            return job;
        }
    }
}
