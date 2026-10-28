using InternshipAPI.Models;
using System.Globalization;

namespace InternshipAPI.Repositories
{
    public interface IApplicationRepository
    {
        //Application actions 
        Task<IEnumerable<Application>> GetAllApplications(int userId);
        Task<Application?> GetApplicationById(int id, int userId);
        Task<IEnumerable<Application>> GetApplicationsByCompany(int companyId, int userId);
        Task<IEnumerable<Application>> GetApplicationsByStatus(int statusId, int userId);
        Task<Application?> UpdateApplication(Application application);
        Task<Application> AddApplication(Application application);
        Task<bool> ApplicationExists(int listingId, int userId);
        Task<IEnumerable<Application>> GetClosingSoon(int userId, int days);
        Task<IEnumerable<Application>> GetOverdue(int userId);


        //ApplicationStatus actions
        Task<IEnumerable<ApplicationStatus>> GetAllStatuses();
        Task<ApplicationStatus?> GetStatusById(int id);

        //Company actions
        Task<IEnumerable<Company>> GetAllCompanies(int userId);
        Task<Company> AddCompany(Company company);
        Task<Company?> GetCompanyById(int companyId, int userId);
        Task<Company?> UpdateCompany(Company company);
        Task<bool> CompanyExists(string name, int userId);


        //User actions
        Task<User?> GetUserById(int userId); 
        Task<User> AddUser(User user, string password);
        Task<User?> GetUserByEmail(string email);
        Task<User?> DeleteAccount(int userId);

        //CVDoc actions

        Task<IEnumerable<CVDoc>> GetAllCVs(int userId);
        Task<CVDoc?> GetCVById(int versionId, int userId);
        Task<CVDoc> AddCVDoc (CVDoc cvDoc);
        Task<CVDoc?> ArchiveDoc (int id);

        //Listing actions
        Task<IEnumerable<Listing>> GetAllListings(int userId);
        Task<Listing?> GetListingById(int listingId, int userId);
        Task<Listing> AddListing(Listing listing);
        Task<Listing?> UpdateListing(Listing listing);
    }
}
