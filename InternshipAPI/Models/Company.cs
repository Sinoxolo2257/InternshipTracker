using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace InternshipAPI.Models
{
    public class Company
    {
        [Key]
        public int CompanyID { get; set; }

        [Required, MaxLength(200)]
        public string CompanyName { get; set; } = string.Empty;

        [MaxLength(100)]
        public string? Industry { get; set; }

        [MaxLength(2000)]
        public string? CompanyDescription { get; set; }

        public bool IsWishlisted { get; set; }

        // owner
        public int UserID { get; set; }
        public User? User { get; set; }

        public List<Listing> Listings { get; set; } = new();
    }
}