using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InternshipAPI.Models
{
    public class Company
    {
        [Key]
        public int CompanyID { get; set; }
        public string CompanyName { get; set; } = string.Empty;
        public string Industry { get; set; } = string.Empty;
        public string CompanyDescription { get; set; } = string.Empty;
        public string Location { get; set; } = string.Empty;
        public bool IsWishlisted { get; set; }
        public List<Application>? Applications { get; set; }
    }
}
