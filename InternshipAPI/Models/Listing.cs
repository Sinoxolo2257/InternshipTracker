using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InternshipAPI.Models
{
    public class Listing
    {
        [Key]
        public int ListingID { get; set; }

        [Required, MaxLength(200)]
        public string Title { get; set; } = string.Empty;

        public ListingType Type { get; set; }  // Job, Internship, Bursary, VacWork

        [MaxLength(200)]
        public string? Location { get; set; }

        public DateTime? DatePosted { get; set; }
        public DateTime ClosingDate { get; set; }

        [Required]
        public string Requirements { get; set; } = string.Empty;
        public string? Description { get; set; }
        [MaxLength(500)]
        public string? ApplicationLink { get; set; }

        public int CompanyID { get; set; }
        public Company? Company { get; set; }

        public int UserID { get; set; }
        public User? User { get; set; }

        public List<Application> Applications { get; set; } = new();
    }

}
