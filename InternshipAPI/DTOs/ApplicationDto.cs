using InternshipAPI.Models;

namespace InternshipAPI.DTOs
{
    
    public class ApplicationDto
    {
        public DateTime ApplicationDate { get; set; }
        public string PositionTitle { get; set; } = string.Empty;
        public ApplicationType ApplicationType { get; set; }
        public string? ApplicationLink { get; set; }
        public string PortalLink { get; set; } = string.Empty;
        public string Notes { get; set; } = string.Empty;
        public DateTime OpenDate { get; set; }
        public DateTime CloseDate { get; set; }
        public DateTime UpdatedAt { get; set; }
        public int UserID { get; set; }
        public int StatusID { get; set; }
        public int CompanyID { get; set; }
    }
}
