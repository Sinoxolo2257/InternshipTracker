using InternshipAPI.Models;

namespace InternshipAPI.Repositories
{
    public interface IApplicationRepository
    {
        //Application actions 
        Task<IEnumerable<Application>> GetAllApplications();
        Task<Application?> GetApplicationById(int id);
        Task<Application?> GetApplicationByCompanyId(int companyId);
        Task<Application?> UpdateApplication(Application application);
        Task<Application> AddApplication(Application application);

        //ApplicationStatus actions
        Task<IEnumerable<ApplicationStatus>> GetAllStatuses();
        Task<ApplicationStatus?> GetStatusById(int id);

        //Company actions
        Task<IEnumerable<Company>> GetAllCompanies();
        Task<Company> AddCompany(Company company);
        Task<Company?> GetCompanyById(int companyId);
        Task<Company?> UpdateCompany(Company company);

        //User actions
        Task<User?> GetUserById(int userId); 
        Task<User> AddUser(User user);
        Task<User?> GetUserByEmail(string email);
        Task<User?> DeleteAccount(int userId);

        //CVDoc actions

        Task<IEnumerable<CVDoc>> GetAllCVs();
        Task<CVDoc?> GetCVById(int versionId);
        Task<CVDoc> AddCVDoc (CVDoc cvDoc);
        Task<CVDoc?> ArchiveDoc (int id);
    }
}
