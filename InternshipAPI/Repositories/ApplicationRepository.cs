using InternshipAPI.Data;
using InternshipAPI.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using BCrypt.Net;

namespace InternshipAPI.Repositories
{
    public class ApplicationRepository : IApplicationRepository
    {
        private const int SavedStatusId = 1;   // "Saved" in the seed data
        private readonly ApplicationDbContext _context;

        public ApplicationRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        //reusable query to get applications for a specific user, including related entities
        private IQueryable<Application> ApplicationsFor(int userId) =>
            _context.Applications
                .Include(a => a.Listing).ThenInclude(l => l!.Company)
                .Include(a => a.ApplicationStatus)
                .Where(a => a.UserID == userId);

        //Application CRUD operations
        public async Task<IEnumerable<Application>> GetAllApplications(int userId)
        {
            return await ApplicationsFor(userId).OrderBy(a => a.Listing!.ClosingDate).ToListAsync();
        }

        public async Task<IEnumerable<Application>> GetApplicationsByStatus(int statusId, int userId) 
        { 
            return await ApplicationsFor(userId)
            .Where(a => a.StatusID == statusId)
            .OrderBy(a => a.Listing!.ClosingDate)
            .ToListAsync();
        }

        public async Task<Application?> GetApplicationById(int id, int userId)
        {
            return await ApplicationsFor(userId).FirstOrDefaultAsync(a => a.ApplicationID == id);
        }

        public async Task<IEnumerable<Application>> GetApplicationsByCompany(int companyId, int userId) =>
            await ApplicationsFor(userId)
                .Where(a => a.Listing!.CompanyID == companyId)
                .ToListAsync();

        public async Task<bool> ApplicationExists(int listingId, int userId) 
        { 
            return await _context.Applications.AnyAsync(a => a.ListingID == listingId && a.UserID == userId); 
        }

        public async Task<Application?> UpdateApplication(Application application)
        {
            var existingApplication = await _context.Applications.FirstOrDefaultAsync(a =>
                 a.ApplicationID == application.ApplicationID && a.UserID == application.UserID);
            if (existingApplication == null) return null;

            existingApplication.StatusID = application.StatusID;
            existingApplication.VersionID = application.VersionID;
            existingApplication.SubmittedDate = application.SubmittedDate;
            existingApplication.PortalLink = application.PortalLink;
            existingApplication.Notes = application.Notes;
            existingApplication.UpdatedAt = application.UpdatedAt;
            await _context.SaveChangesAsync();
            return await GetApplicationById(existingApplication.ApplicationID, existingApplication.UserID);
        }

        public async Task<Application> AddApplication(Application application)
        {
            _context.Applications.Add(application);
            await _context.SaveChangesAsync();
            return (await GetApplicationById(application.ApplicationID, application.UserID))!;
        }

        public async Task<IEnumerable<Application>> GetClosingSoon(int userId, int days)
        {
            var today = DateTime.Today;
            var until = today.AddDays(days);
            return await ApplicationsFor(userId)
                .Where(a => a.StatusID == SavedStatusId
                         && a.Listing!.ClosingDate >= today && a.Listing.ClosingDate <= until)
                .OrderBy(a => a.Listing!.ClosingDate)
                .ToListAsync();
        }

        public async Task<IEnumerable<Application>> GetOverdue(int userId) =>
            await ApplicationsFor(userId)
                .Where(a => a.StatusID == SavedStatusId && a.Listing!.ClosingDate < DateTime.Today)
                .OrderBy(a => a.Listing!.ClosingDate)
                .ToListAsync();


        //ApplicationStatus CRUD operations
        public async Task<IEnumerable<ApplicationStatus>> GetAllStatuses()
        {
            return await _context.ApplicationStatuses.ToListAsync();
        }

        public async Task<ApplicationStatus?> GetStatusById(int statusId)
        {
            return await _context.ApplicationStatuses.FindAsync(statusId);
        }


        //Company CRUD operations
        public async Task<IEnumerable<Company>> GetAllCompanies(int userId)
        {
            return await _context.Companies.Where(c => c.UserID == userId)
                .OrderBy(c => c.CompanyName).ToListAsync();
        }

        public async Task<Company> AddCompany(Company company)
        {
            _context.Companies.Add(company);
            await _context.SaveChangesAsync();
            return company;
        }

        public async Task<Company?> GetCompanyById(int companyId, int userId)
        {
            return await _context.Companies.FirstOrDefaultAsync(c => c.CompanyID == companyId && c.UserID == userId); ;
        }

        public async Task<bool> CompanyExists(string name, int userId) =>
            await _context.Companies.AnyAsync(c => c.UserID == userId && c.CompanyName == name);

        public async Task<Company?> UpdateCompany(Company company)
        {
            var existingCompany = await GetCompanyById(company.CompanyID, company.UserID);
            if (existingCompany == null)
            {
                return null;
            }

            existingCompany.CompanyName = company.CompanyName;
            existingCompany.Industry = company.Industry;
            existingCompany.CompanyDescription = company.CompanyDescription;
            existingCompany.IsWishlisted = company.IsWishlisted;
            await _context.SaveChangesAsync();
            return existingCompany;
        }

        //Listing CRUD operations
        public async Task<IEnumerable<Listing>> GetAllListings(int userId)
        {
            return await _context.Listings.Include(l => l.Company)
                .Where(l => l.UserID == userId)
                .OrderBy(l => l.ClosingDate).ToListAsync();
        }

        public async Task<Listing?> GetListingById(int listingId, int userId)
        {
            return await _context.Listings.Include(l => l.Company)
                .FirstOrDefaultAsync(l => l.ListingID == listingId && l.UserID == userId);
        }

        public async Task<Listing> AddListing(Listing listing)
        {
            _context.Listings.Add(listing);
            await _context.SaveChangesAsync();
            return (await GetListingById(listing.ListingID, listing.UserID))!;
        }

        public async Task<Listing?> UpdateListing(Listing listing)
        {
            var existing = await GetListingById(listing.ListingID, listing.UserID);
            if (existing == null) return null;

            existing.CompanyID = listing.CompanyID;
            existing.Title = listing.Title;
            existing.Type = listing.Type;
            existing.Location = listing.Location;
            existing.DatePosted = listing.DatePosted;
            existing.ClosingDate = listing.ClosingDate;
            existing.Requirements = listing.Requirements;
            existing.Description = listing.Description;
            existing.ApplicationLink = listing.ApplicationLink;
            await _context.SaveChangesAsync();
            return await GetListingById(existing.ListingID, existing.UserID);
        }


        //User CRUD operations
        public async Task<User?> GetUserById(int userId)
        {
            return await _context.Users.FindAsync(userId);
        }

        public async Task<User?> GetUserByEmail(string email)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.EmailAddress == email);

        }

        public async Task<User> AddUser(User user, string password)
        {
            user.PasswordHash = BCrypt.Net.BCrypt.HashPassword(password);
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return user;
        }

        public async Task<User?> DeleteAccount(int userId)
        {
            var user = await _context.Users.FindAsync(userId);
            if (user == null) return null;
            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
            return user;
        }

        //CvDoc CRUD operations
        public async Task<IEnumerable<CVDoc>> GetAllCVs(int userId)
        {
            return await _context.CVDocs.Where(v => v.UserID == userId && v.DocIsActive).ToListAsync();
        }

        public async Task<CVDoc?> GetCVById(int versionId, int userId)
        {
            return await _context.CVDocs.FirstOrDefaultAsync(v => v.VersionID == versionId && v.UserID == userId);
        }

        public async Task<CVDoc> AddCVDoc(CVDoc cvDoc)
        {
            _context.CVDocs.Add(cvDoc);
            await _context.SaveChangesAsync();
            return cvDoc;
        }

        public async Task<CVDoc?> ArchiveDoc(int id)
        {
            var doc = await _context.CVDocs.FindAsync(id);
            if (doc == null) return null;

            doc.DocIsActive = false;
            await _context.SaveChangesAsync();
            return doc;
        }
    }
}
