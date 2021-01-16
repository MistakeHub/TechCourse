using Microsoft.EntityFrameworkCore.Migrations;

namespace BackEnd.Migrations
{
    public partial class Update7 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Breaks",
                table: "Autos");

            migrationBuilder.AddColumn<int>(
                name: "AutoId",
                table: "Breaks",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Breaks_AutoId",
                table: "Breaks",
                column: "AutoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Breaks_Autos_AutoId",
                table: "Breaks",
                column: "AutoId",
                principalTable: "Autos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Breaks_Autos_AutoId",
                table: "Breaks");

            migrationBuilder.DropIndex(
                name: "IX_Breaks_AutoId",
                table: "Breaks");

            migrationBuilder.DropColumn(
                name: "AutoId",
                table: "Breaks");

            migrationBuilder.AddColumn<string>(
                name: "Breaks",
                table: "Autos",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
