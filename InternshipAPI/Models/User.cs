namespace InternshipAPI.Models
{
    public class User
    {
        public int UserID { get; set; }
        public string Name { get; set; }= string.Empty;
        public string Surname { get; set; } = string.Empty;
        public string EmailAddress { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string AcademicRecordURL { get; set; } = string.Empty;

        public List<Application>? Applications { get; set; }
    }
}
