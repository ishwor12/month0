using JOBTRACKER.Data;
using JOBTRACKER.Models;
using JOBTRACKER.Services.Interface;
using Microsoft.EntityFrameworkCore;

namespace JOBTRACKER.Services
{
    public class AuditLogService : IAuditLogService
    {
        private readonly AppDbContext _context;
        public AuditLogService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<AuditLog>> GetLogsForJobAsync(int jobId)
        => await _context.AuditLogs
                .Where(l => l.JobApplicationId == jobId)
                .OrderByDescending(l => l.Timestamp)
                .ToListAsync();
        

        public async Task AddAsync(AuditLog log)
        {
            _context.AuditLogs.Add(new AuditLog
            {
                JobApplicationId = log.Id,
                Action = log.Action,
                Details = log.Details
            });
            await _context.SaveChangesAsync();
        }
        public async Task LogAsync(int jobId, string action, string details)
        {
            _context.AuditLogs.Add(new AuditLog
            {
                JobApplicationId = jobId,
                Action = action,
                Details = details
            });
            await _context.SaveChangesAsync();
        }

       
    }
}
