using InternshipAPI.Data;
using InternshipAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace InternshipAPI.Repositories
{
    public class Repository : IRepository
    {
        private readonly ApplicationDbContext _context;

        public Repository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Application>> GetAllApplications()
        {
            return await _context.Applications.ToListAsync();
        }

        public async Task<Application?> GetApplicationById(int id)
        {
            return await _context.Applications.FindAsync(id);
        }
        
        public async Task<Application?> GetApplicationByCompanyID(int companyID)
        {
            return await _context.Applications.FirstOrDefaultAsync(a=> a.CompanyID== companyID);
        }

        public async Task<Application?> UpdateApplication(Application application)
        {
            _context.Applications.Update(application);
            await _context.SaveChangesAsync();
            return application;
        }

        public async Task<Application?> AddApplication(Application application)
        {
            _context.Applications.Add(application);
            await _context.SaveChangesAsync();
            return application;
        }

        public async Task<IEnumerable<Company>> GetAllCompanies()
        {
            return await _context.Companies.ToListAsync();
        }

        public async Task<Company?> AddCompany(Company company)
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
            _context.Companies.Update(company);
            await _context.SaveChangesAsync();
            return company;
        }

        public async Task<User?> GetUserById(int userId)
        {
            return await _context.Users.FindAsync(userId);
        }

        public async Task<User?> AddUser(User user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return user;
        }
}
