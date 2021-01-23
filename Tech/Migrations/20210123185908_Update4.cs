using Microsoft.EntityFrameworkCore.Migrations;

namespace BackEnd.Migrations
{
    public partial class Update4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Auto",
                table: "RequestForFixArchives",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Client",
                table: "RequestForFixArchives",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Enroller",
                table: "RequestForFixArchives",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Auto",
                table: "RequestForFixArchives");

            migrationBuilder.DropColumn(
                name: "Client",
                table: "RequestForFixArchives");

            migrationBuilder.DropColumn(
                name: "Enroller",
                table: "RequestForFixArchives");
        }
    }
}
