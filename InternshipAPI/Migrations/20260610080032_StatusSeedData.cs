using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace InternshipAPI.Migrations
{
    /// <inheritdoc />
    public partial class StatusSeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "ApplicationStatuses",
                columns: new[] { "StatusID", "StatusDescription" },
                values: new object[,]
                {
                    { 1, "Applied" },
                    { 2, "In Review" },
                    { 3, "Interview Scheduled" },
                    { 4, "Offered" },
                    { 5, "Rejected" },
                    { 6, "Withdrawn" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ApplicationStatuses",
                keyColumn: "StatusID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "ApplicationStatuses",
                keyColumn: "StatusID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "ApplicationStatuses",
                keyColumn: "StatusID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "ApplicationStatuses",
                keyColumn: "StatusID",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "ApplicationStatuses",
                keyColumn: "StatusID",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "ApplicationStatuses",
                keyColumn: "StatusID",
                keyValue: 6);
        }
    }
}
