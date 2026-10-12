using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InternshipAPI.Models
{
    public class Application
    {
        [Key]
        public int ApplicationID { get; set; }
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
        public User? User { get; set; }
        public int StatusID { get; set; }
        public ApplicationStatus? ApplicationStatus { get; set; }
        public int CompanyID { get; set; }
        public Company? Company { get; set; }   
        public int VersionID { get; set; }
        public CVDoc? CVDoc { get; set; }
    }
}
