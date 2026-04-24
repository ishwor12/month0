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
            await _auditLogService.LogAsync(
           created.Id,"Created",$"Application for {job.RoleName} at {job.CompanyName}");
            return created;
        }

        public Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<JobApplication>> GetAllAsync() => await _jobRepository.GetAllAsync();


        public async Task<JobApplication?> GetByIdAsync(int id) => await _jobRepository.GetByIdAsync(id);

        public Task UpdateStatusAsync(int id, ApplicationStatus status)
        {
            throw new NotImplementedException();
        }

       
    }
}
