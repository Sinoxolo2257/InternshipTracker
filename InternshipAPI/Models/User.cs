using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InternshipAPI.Models
{
    public class User
    {
        [Key]
        public int UserID { get; set; }
        public string Name { get; set; }= string.Empty;
        public string Surname { get; set; } = string.Empty;
        public string EmailAddress { get; set; } = string.Empty;
        public string PasswordHash { get; set;  } = string.Empty;
        
        [NotMapped]
        public string Password { get; set; } = string.Empty;
        public string AcademicRecordURL { get; set; } = string.Empty;

        public List<Application>? Applications { get; set; }
    }
}
