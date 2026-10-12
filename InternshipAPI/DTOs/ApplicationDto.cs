using InternshipAPI.Models;

namespace InternshipAPI.DTOs
{
    public class ApplicationDto
    {
        public int ListingID { get; set; }
        public int? VersionID { get; set; }
        public int StatusID { get; set; }
        public DateTime? SubmittedDate { get; set; }
        public string? PortalLink { get; set; }
        public string? Notes { get; set; }
    }

}
