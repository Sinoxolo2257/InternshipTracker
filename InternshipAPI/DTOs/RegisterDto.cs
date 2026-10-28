using System.ComponentModel.DataAnnotations;

namespace InternshipAPI.DTOs
{
    public class RegisterDto
    {
        [Required, MaxLength(100)]
        public string Name { get; set; }= string.Empty;

        [Required, MaxLength(100)]
        public string Surname { get; set; }=string.Empty;

        [Required, EmailAddress, MaxLength(254)]
        public string EmailAddress { get; set; }=string.Empty;

        [Required, MinLength(8) ,MaxLength(100)]
        public string Password { get; set; }=string.Empty;
    }
}
