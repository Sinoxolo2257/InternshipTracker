namespace InternshipAPI.DTOs
{
    public class CompanyDto
    {
        public string CompanyName { get; set; } = string.Empty;
        public string? Industry { get; set; }
        public string? CompanyDescription { get; set; }
        public bool IsWishlisted { get; set; }
    }
}
