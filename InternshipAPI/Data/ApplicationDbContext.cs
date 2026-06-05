using Microsoft.EntityFrameworkCore;
using InternshipAPI.Models;

namespace InternshipAPI.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options){}

        public DbSet<User> Users { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<Application> Applications { get; set; }
        public DbSet<ApplicationStatus> ApplicationStatuses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Application>()
                .HasOne(a=> a.User)
                .WithMany(u => u.Applications)
                .HasForeignKey(a => a.UserID);

            modelBuilder.Entity<Application>()
                .HasOne(a => a.ApplicationStatus)
                .WithMany(s => s.Applications)
                .HasForeignKey(a => a.StatusID);

             modelBuilder.Entity<Application>()
                .HasOne(a => a.Company)
                .WithMany(c => c.Applications)
                .HasForeignKey(a => a.CompanyID);
        }
    }
}