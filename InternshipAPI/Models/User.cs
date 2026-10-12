using System.ComponentModel.DataAnnotations;

namespace InternshipAPI.Models
{
    public class User
    {
        [Key]
        public int UserID { get; set; }

        [Required, MaxLength(100)]
        public string Name { get; set; } = string.Empty;

        [Required, MaxLength(100)]
        public string Surname { get; set; } = string.Empty;

        [Required, EmailAddress, MaxLength(254)]
        public string EmailAddress { get; set; } = string.Empty;

        [Required]
        public string PasswordHash { get; set; } = string.Empty;

        [MaxLength(500)]
        public string? AcademicRecordURL { get; set; }

        public List<Company> Companies { get; set; } = new();
        public List<Listing> Listings { get; set; } = new();
        public List<CVDoc> CVDocs { get; set; } = new();
        public List<Application> Applications { get; set; } = new();
    }
}