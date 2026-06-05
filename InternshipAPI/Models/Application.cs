namespace InternshipAPI.Models
{
    public class Application
    {
        public int ApplicationID { get; set; }
        public DateTime ApplicationDate { get; set; }
        public string PositionTitle { get; set; } = string.Empty;
        public string PortalLink { get; set; } = string.Empty;
        public int UserID { get; set; }
        public User? User { get; set; }
        public int StatusID { get; set; }
        public ApplicationStatus? ApplicationStatus { get; set; }
        public int CompanyID { get; set; }
        public Company? Company { get; set; }   
    }
}
