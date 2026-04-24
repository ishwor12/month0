using JOBTRACKER.Models;
using JOBTRACKER.Models.Enums;

namespace JOBTRACKER.Repositories
{
    public interface IJobRepository
    {
        Task<IEnumerable<JobApplication>> GetAllAsync();
        Task<JobApplication?> GetByIdAsync(int id);
        Task<JobApplication> AddAsync(JobApplication job);
        Task<JobApplication> UpdateAsync(JobApplication job);
        Task<bool> DeleteAsync(int id);
        Task<IEnumerable<JobApplication>> GetByStatusAsync(ApplicationStatus status);
    }
}
