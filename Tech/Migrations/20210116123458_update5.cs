using Microsoft.EntityFrameworkCore.Migrations;

namespace BackEnd.Migrations
{
    public partial class update5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IdBreak",
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

            migrationBuilder.AddColumn<int>(
                name: "IdBreak",
                table: "Autos",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
