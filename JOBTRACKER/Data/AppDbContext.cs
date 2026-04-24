using JOBTRACKER.Models;
using JOBTRACKER.Models.Enums;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;

namespace JOBTRACKER.Data
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        
        protected override void OnModelCreating(ModelBuilder modelbuilder)
        {
            modelbuilder.Entity<JobApplication>(e =>
            {
                e.HasKey(x => x.Id);
                e.Property(x => x.CompanyName).IsRequired().HasMaxLength(50);
                e.Property(x => x.RoleName).IsRequired().HasMaxLength(100);
                e.Property(x => x.Status).HasConversion<string>();
            });

        }
        public DbSet<JobApplication> JobApplications { get; set; }
        public DbSet<AuditLog> AuditLogs { get; set; }

    }
}
