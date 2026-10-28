using System.ComponentModel.DataAnnotations;

namespace InternshipAPI.Models
{
    public class CVDoc
    {
        [Key]
        public int VersionID { get; set; }

        [Required, MaxLength(100)]
        public string VersionName { get; set; } = string.Empty;   // the label the user types

        [Required, MaxLength(260)]
        public string OriginalFileName { get; set; } = string.Empty;

        [Required, MaxLength(100)]
        public string StoredFileName { get; set; } = string.Empty; // GUID + extension on disk

        public DateTime UploadedAt { get; set; }

        public bool DocIsActive { get; set; } = true;

        public int UserID { get; set; }
        public User? User { get; set; }

        public List<Application> Applications { get; set; } = new();
    }
}