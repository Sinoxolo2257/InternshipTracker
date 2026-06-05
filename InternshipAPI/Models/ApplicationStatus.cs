namespace InternshipAPI.Models
{
    public class ApplicationStatus
    {
        public int StatusID { get; set; }
        public string StatusDescription { get; set; } = string.Empty;
        public List<Application>? Applications { get; set; }
    }
}
