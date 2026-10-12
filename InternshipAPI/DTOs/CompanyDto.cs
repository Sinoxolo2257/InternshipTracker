namespace InternshipAPI.DTOs
{
    public class CompanyDto
    {
        public string CompanyName { get; set; } = string.Empty;
        public string Industry { get; set; } = string.Empty;
        public string CompanyDescription { get; set; } = string.Empty;
        public string Location { get; set; } = string.Empty;
        public bool IsWishlisted { get; set; }
    }
}
