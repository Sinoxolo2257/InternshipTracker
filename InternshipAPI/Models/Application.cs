using System.ComponentModel.DataAnnotations;

namespace InternshipAPI.Models
{
    public class Application
    {
        [Key]
        public int ApplicationID { get; set; }

        public DateTime? SubmittedDate { get; set; }

        [MaxLength(500)]
        public string? PortalLink { get; set; }

        public string? Notes { get; set; }

        public DateTime UpdatedAt { get; set; }

        public int UserID { get; set; }
        public User? User { get; set; }

        public int ListingID { get; set; }
        public Listing? Listing { get; set; }

        public int StatusID { get; set; }
        public ApplicationStatus? ApplicationStatus { get; set; }

        public int? VersionID { get; set; }
        public CVDoc? CVDoc { get; set; }
    }
}