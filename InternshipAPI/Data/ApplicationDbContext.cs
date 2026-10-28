using Microsoft.EntityFrameworkCore;
using InternshipAPI.Models;

namespace InternshipAPI.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<Listing> Listings { get; set; }
        public DbSet<Application> Applications { get; set; }
        public DbSet<ApplicationStatus> ApplicationStatuses { get; set; }
        public DbSet<CVDoc> CVDocs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Application
            modelBuilder.Entity<Application>()
                .HasOne(a => a.User).WithMany(u => u.Applications)
                .HasForeignKey(a => a.UserID)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Application>()
                .HasOne(a => a.Listing).WithMany(l => l.Applications)
                .HasForeignKey(a => a.ListingID)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Application>()
                .HasOne(a => a.ApplicationStatus).WithMany(s => s.Applications)
                .HasForeignKey(a => a.StatusID)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Application>()
                .HasOne(a => a.CVDoc).WithMany(v => v.Applications)
                .HasForeignKey(a => a.VersionID)
                .OnDelete(DeleteBehavior.Restrict);

            // one application per user per listing
            modelBuilder.Entity<Application>()
                .HasIndex(a => new { a.UserID, a.ListingID }).IsUnique();

            //Listing 
            modelBuilder.Entity<Listing>()
                .HasOne(l => l.Company).WithMany(c => c.Listings)
                .HasForeignKey(l => l.CompanyID)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Listing>()
                .HasOne(l => l.User).WithMany(u => u.Listings)
                .HasForeignKey(l => l.UserID)
                .OnDelete(DeleteBehavior.Restrict);

            //Company
            modelBuilder.Entity<Company>()
                .HasOne(c => c.User).WithMany(u => u.Companies)
                .HasForeignKey(c => c.UserID)
                .OnDelete(DeleteBehavior.Restrict);

            // a user can't have two companies with the same name
            modelBuilder.Entity<Company>()
                .HasIndex(c => new { c.UserID, c.CompanyName }).IsUnique();

            //CVDoc
            modelBuilder.Entity<CVDoc>()
                .HasOne(v => v.User).WithMany(u => u.CVDocs)
                .HasForeignKey(v => v.UserID)
                .OnDelete(DeleteBehavior.Restrict);

            //User
            modelBuilder.Entity<User>()
                .HasIndex(u => u.EmailAddress).IsUnique();

            //Seed
            modelBuilder.Entity<ApplicationStatus>().HasData(
                new ApplicationStatus { StatusID = 1, StatusDescription = "Saved" },
                new ApplicationStatus { StatusID = 2, StatusDescription = "Applied" },
                new ApplicationStatus { StatusID = 3, StatusDescription = "In Review" },
                new ApplicationStatus { StatusID = 4, StatusDescription = "Interview Scheduled" },
                new ApplicationStatus { StatusID = 5, StatusDescription = "Offered" },
                new ApplicationStatus { StatusID = 6, StatusDescription = "Rejected" },
                new ApplicationStatus { StatusID = 7, StatusDescription = "Withdrawn" }
            );
        }
    }
}