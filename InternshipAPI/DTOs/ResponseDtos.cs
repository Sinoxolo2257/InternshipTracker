using InternshipAPI.Models;

namespace InternshipAPI.DTOs
{
    public class ResponseDtos
    {
        public record CompanyResponseDto(
        int CompanyID, string CompanyName, string? Industry,
        string? CompanyDescription, bool IsWishlisted)
        {
            public static CompanyResponseDto From(Company c) =>
                new(c.CompanyID, c.CompanyName, c.Industry, c.CompanyDescription, c.IsWishlisted);
        }

        public record ListingResponseDto(
            int ListingID, int CompanyID, string CompanyName, string Title,
            ListingType Type, string? Location, DateTime? OpenDate, DateTime CloseDate,
            string Requirements, string? Description, string? ApplicationLink)
        {
            public static ListingResponseDto From(Listing l) =>
                new(l.ListingID, l.CompanyID, l.Company!.CompanyName, l.Title, l.Type,
                    l.Location, l.DatePosted, l.ClosingDate, l.Requirements, l.Description,
                    l.ApplicationLink);
        }

        public record ApplicationResponseDto(
        int ApplicationID, int ListingID, string Title, int CompanyID, string CompanyName,
        string? Location, ListingType Type, DateTime? OpenDate, DateTime CloseDate,
        int StatusID, string Status, DateTime? SubmittedDate, string? PortalLink,
        string? Notes, int? VersionID, DateTime UpdatedAt)
        {
            public static ApplicationResponseDto From(Application a) =>
                new(a.ApplicationID, a.ListingID, a.Listing!.Title, a.Listing.CompanyID,
                    a.Listing.Company!.CompanyName, a.Listing.Location, a.Listing.Type,
                    a.Listing.DatePosted, a.Listing.ClosingDate, a.StatusID,
                    a.ApplicationStatus!.StatusDescription, a.SubmittedDate, a.PortalLink,
                    a.Notes, a.VersionID, a.UpdatedAt);
        }
    }
}
