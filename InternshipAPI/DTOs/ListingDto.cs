using InternshipAPI.Models;

namespace InternshipAPI.DTOs
{
    public class ListingDto
    {
        public int CompanyID { get; set; }
        public string Title { get; set; } = string.Empty;
        public ListingType Type { get; set; }
        public string? Location { get; set; }
        public DateTime? OpenDate { get; set; }
        public DateTime CloseDate { get; set; }
        public string Requirements { get; set; } = string.Empty;
        public string? Description { get; set; }
        public string? ApplicationLink { get; set; }
    }

}