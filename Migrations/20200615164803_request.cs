using Microsoft.EntityFrameworkCore.Migrations;

namespace Donor.Migrations
{
    public partial class request : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Approved",
                table: "Request");

            migrationBuilder.DropColumn(
                name: "Others",
                table: "Request");

            migrationBuilder.DropColumn(
                name: "PreviewesHealthProblem",
                table: "Request");

            migrationBuilder.DropColumn(
                name: "RecentDrag",
                table: "Request");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Approved",
                table: "Request",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Others",
                table: "Request",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PreviewesHealthProblem",
                table: "Request",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RecentDrag",
                table: "Request",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
