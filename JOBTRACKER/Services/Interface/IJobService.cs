using JOBTRACKER.Models;
using JOBTRACKER.Models.Enums;

namespace JOBTRACKER.Services.Interface
{
    public interface IJobService
    {
        Task<IEnumerable<JobApplication>> GetAllAsync();
        Task<JobApplication?> GetByIdAsync(int id);
        Task<JobApplication> CreateAsync(JobApplication job);
        Task UpdateStatusAsync(int id, ApplicationStatus status);
        Task DeleteAsync(int id);
    }
}
