using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using LeadMSAPP.Models;

namespace LeadMSAPP.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<LeadMSAPP.Models.Batch> Batch { get; set; } = default!;
        public DbSet<LeadMSAPP.Models.Course> Course { get; set; } = default!;
        public DbSet<LeadMSAPP.Models.Enroll> Enroll { get; set; } = default!;
        public DbSet<LeadMSAPP.Models.EntityStatus> EntityStatus { get; set; } = default!;
        public DbSet<LeadMSAPP.Models.LeadStatus> LeadStatus { get; set; } = default!;
        public DbSet<LeadMSAPP.Models.PaymentHistory> PaymentHistory { get; set; } = default!;
        public DbSet<LeadMSAPP.Models.Student> Student { get; set; } = default!;
    }
}
