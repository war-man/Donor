using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Donor.Migrations
{
    public partial class dbchanges : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Donor",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Phone = table.Column<string>(nullable: false),
                    Email = table.Column<string>(nullable: true),
                    HidePhone = table.Column<bool>(nullable: false),
                    District = table.Column<string>(nullable: true),
                    Thana = table.Column<string>(nullable: true),
                    ZipCode = table.Column<string>(nullable: true),
                    Address = table.Column<string>(nullable: true),
                    DonateType = table.Column<string>(nullable: true),
                    PreviewesHealthProblem = table.Column<string>(nullable: true),
                    BoodGroup = table.Column<string>(nullable: true),
                    RecentDrag = table.Column<string>(nullable: true),
                    Others = table.Column<string>(nullable: true),
                    Approved = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Donor", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Request",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Phone = table.Column<string>(nullable: true),
                    District = table.Column<string>(nullable: true),
                    Thana = table.Column<string>(nullable: true),
                    Address = table.Column<string>(nullable: true),
                    RecipientType = table.Column<string>(nullable: true),
                    PreviewesHealthProblem = table.Column<string>(nullable: true),
                    BoodGroup = table.Column<string>(nullable: true),
                    RecentDrag = table.Column<string>(nullable: true),
                    Others = table.Column<string>(nullable: true),
                    Approved = table.Column<string>(nullable: true),
                    RequestDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Request", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Donor");

            migrationBuilder.DropTable(
                name: "Request");
        }
    }
}
