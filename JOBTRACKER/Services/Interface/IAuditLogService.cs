using JOBTRACKER.Models;

namespace JOBTRACKER.Services.Interface
{
    public interface IAuditLogService
    {
        Task LogAsync(int jobId, string action, string details);
        Task<IEnumerable<AuditLog>> GetLogsForJobAsync(int jobId);
    }
}
