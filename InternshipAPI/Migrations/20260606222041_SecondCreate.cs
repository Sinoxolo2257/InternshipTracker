using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InternshipAPI.Migrations
{
    /// <inheritdoc />
    public partial class SecondCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsWishlisted",
                table: "Companies",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "ApplicationLink",
                table: "Applications",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CloseDate",
                table: "Applications",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Notes",
                table: "Applications",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "OpenDate",
                table: "Applications",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "VersionID",
                table: "Applications",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "CVDocs",
                columns: table => new
                {
                    VersionID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VersionName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    VersionUrl = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CVDocs", x => x.VersionID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Applications_VersionID",
                table: "Applications",
                column: "VersionID");

            migrationBuilder.AddForeignKey(
                name: "FK_Applications_CVDocs_VersionID",
                table: "Applications",
                column: "VersionID",
                principalTable: "CVDocs",
                principalColumn: "VersionID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Applications_CVDocs_VersionID",
                table: "Applications");

            migrationBuilder.DropTable(
                name: "CVDocs");

            migrationBuilder.DropIndex(
                name: "IX_Applications_VersionID",
                table: "Applications");

            migrationBuilder.DropColumn(
                name: "IsWishlisted",
                table: "Companies");

            migrationBuilder.DropColumn(
                name: "ApplicationLink",
                table: "Applications");

            migrationBuilder.DropColumn(
                name: "CloseDate",
                table: "Applications");

            migrationBuilder.DropColumn(
                name: "Notes",
                table: "Applications");

            migrationBuilder.DropColumn(
                name: "OpenDate",
                table: "Applications");

            migrationBuilder.DropColumn(
                name: "VersionID",
                table: "Applications");
        }
    }
}
