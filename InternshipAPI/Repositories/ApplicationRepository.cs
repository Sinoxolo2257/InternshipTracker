using InternshipAPI.Data;
using InternshipAPI.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using BCrypt.Net;

namespace InternshipAPI.Repositories
{
    public class ApplicationRepository : IApplicationRepository
    {
        private readonly ApplicationDbContext _context;

        public ApplicationRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        //Application CRUD operations
        public async Task<IEnumerable<Application>> GetAllApplications()
        {
            return await _context.Applications.ToListAsync();
        }

        public async Task<Application?> GetApplicationById(int id)
        {
            return await _context.Applications.FindAsync(id);
        }

        public async Task<Application?> GetApplicationByCompanyId(int companyId)
        {
            return await _context.Applications.FirstOrDefaultAsync(a => a.CompanyID == companyId);
        }

        public async Task<Application?> UpdateApplication(Application application)
        {
            var existingApplication = await _context.Applications.FindAsync(application.ApplicationID);
            if (existingApplication == null) return null;

            existingApplication.StatusID = application.StatusID;
            existingApplication.Notes = application.Notes;
            existingApplication.ApplicationLink = application.ApplicationLink;
            await _context.SaveChangesAsync();
            return existingApplication;
        }

        public async Task<Application> AddApplication(Application application)
        {
            _context.Applications.Add(application);
            await _context.SaveChangesAsync();
            return application;
        }

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
        public async Task<IEnumerable<Company>> GetAllCompanies()
        {
            return await _context.Companies.ToListAsync();
        }

        public async Task<Company> AddCompany(Company company)
        {
            _context.Companies.Add(company);
            await _context.SaveChangesAsync();
            return company;
        }

        public async Task<Company?> GetCompanyById(int companyId)
        {
            return await _context.Companies.FindAsync(companyId);
        }

        public async Task<Company?> UpdateCompany(Company company)
        {
            var existingCompany = await _context.Companies.FindAsync(company.CompanyID);
            if (existingCompany == null)
            {
                return null;
            }

            existingCompany.CompanyName = company.CompanyName;
            existingCompany.Industry = company.Industry;
            existingCompany.CompanyDescription = company.CompanyDescription;
            await _context.SaveChangesAsync();
            return existingCompany;
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

        public async Task<User> AddUser(User user)
        {
            user.PasswordHash= BCrypt.Net.BCrypt.HashPassword(user.Password);
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
        public async Task<IEnumerable<CVDoc>> GetAllCVs()
        {
            return await _context.CVDocs.ToListAsync();
        }

        public async Task<CVDoc?> GetCVById(int versionId)
        {
            return await _context.CVDocs.FindAsync(versionId);
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
