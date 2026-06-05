using InternshipAPI.Models;

namespace InternshipAPI.Repositories
{
    public interface IRepository
    {
        Task<IEnumerable<Application>> GetAllApplications();
        Task<Application?> GetApplicationById(int id);
        Task<Application?> GetApplicationByCompanyID(int companyId);
        Task<Application?> UpdateApplication(Application application);
        Task<Application?> AddApplication(Application application);

        Task<IEnumerable<Company>> GetAllCompanies();
        Task<Company?> AddCompany(Company company);
        Task<Company?> GetCompanyById(int companyId);
        Task<Company?> UpdateCompany(Company company);

        Task<User?> GetUserById(int userId);
        Task<User?> AddUser(User user);
    }
}
