using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InternshipAPI.Models
{
    public class ApplicationStatus
    {
        [Key]
        public int StatusID { get; set; }
        public string StatusDescription { get; set; } = string.Empty;
        public List<Application>? Applications { get; set; }
    }
}
