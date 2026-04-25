using JOBTRACKER.Models;
using JOBTRACKER.Models.Enums;

namespace JOBTRACKER.Services.Interface
{
    public interface IJobService
    {
        Task<IEnumerable<JobApplication>> GetAllAsync();
        Task<JobApplication?> GetByIdAsync(int id);
        Task<JobApplication> CreateAsync(JobApplication job);
        Task<JobApplication?> UpdateStatusAsync(int id, JobApplication job);
       // Task<JobApplication?> UpdateStatusAsync(int id, ApplicationStatus newStatus);
        Task <bool> DeleteAsync(int id);
    }
}
