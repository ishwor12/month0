using JOBTRACKER.Models.Enums;

namespace JOBTRACKER.Models
{
    public class JobApplication
    {
        public int Id { get; set; }
        public string CompanyName { get; set; } = null!;
        public string RoleName { get; set; } = null!;
        public string? JobUrl { get; set; }
        public ApplicationStatus Status { get; set; } = ApplicationStatus.TechnicalTest;
        public DateTime AppliedDate { get; set; } = DateTime.UtcNow;
        public DateTime? LastUpdated { get; set; }
        public string? Notes { get; set; }
    }
}

