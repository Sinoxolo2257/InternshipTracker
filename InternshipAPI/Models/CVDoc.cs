using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace InternshipAPI.Models
{
    public class CVDoc
    {
        [Key]
        public int VersionID { get; set; }
        public string VersionName { get; set; } = string.Empty;
        public string VersionUrl { get; set; } = string.Empty;
        public bool DocIsActive { get; set; }
        public List<Application>? Applications { get; set; }
    }
}
