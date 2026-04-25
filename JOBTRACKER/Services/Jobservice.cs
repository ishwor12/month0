using JOBTRACKER.Models;
using JOBTRACKER.Models.Enums;
using JOBTRACKER.Repositories;
using JOBTRACKER.Services.Interface;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace JOBTRACKER.Services
{
    public class Jobservice: IJobService
    {
        private readonly IJobRepository _jobRepository;
       // private readonly INotificationService _notificationService;
        private readonly IAuditLogService _auditLogService;
        public Jobservice(IJobRepository jobRepository , IAuditLogService auditLogService)
        {
            _jobRepository = jobRepository;
           // _notificationService = notificationService;
            _auditLogService = auditLogService;
        }

        public  async Task<JobApplication> CreateAsync(JobApplication job)
        {
            var created = await _jobRepository.AddAsync(job);
            await _auditLogService.AddAsync(new AuditLog
            {
                JobApplicationId = created.Id,
                Action = "Created",
                Details = $"Applied to {job.RoleName} at {job.CompanyName}",
                Timestamp = DateTime.UtcNow
            });

            return created;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var deleted = await _jobRepository.DeleteAsync(id);
            if (deleted)
            {
                // Only log if something was actually deleted
                await _auditLogService.AddAsync(new AuditLog
                {
                    JobApplicationId = id,
                    Action = "Deleted",
                    Details = $"Job application {id} was deleted",
                    Timestamp = DateTime.UtcNow
                });
            }

            return deleted;


        }

        public async Task<IEnumerable<JobApplication>> GetAllAsync() => await _jobRepository.GetAllAsync();

        public async Task<JobApplication?> GetByIdAsync(int id) => await _jobRepository.GetByIdAsync(id);

        public async Task<JobApplication?> UpdateStatusAsync(int id, JobApplication job)
        {
            var existing = await _jobRepository.GetByIdAsync(id);
            if (existing == null)
            return null;
            job.Id = id;
            var updated = await _jobRepository.UpdateAsync(job);

            await _auditLogService.AddAsync(new AuditLog
            {
                JobApplicationId = id,
                Action = "Updated",
                Details = $"Updated {job.RoleName} at {job.CompanyName}",
                Timestamp = DateTime.UtcNow
            });

            return updated;
        }

    }
}
