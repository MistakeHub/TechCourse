using Microsoft.EntityFrameworkCore.Migrations;

namespace BackEnd.Migrations
{
    public partial class update4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Breaks_Requests_RequestForFixId",
                table: "Breaks");

            migrationBuilder.DropForeignKey(
                name: "FK_Requests_Autos_IdAutoId",
                table: "Requests");

            migrationBuilder.DropForeignKey(
                name: "FK_Requests_Clients_IdClientId",
                table: "Requests");

            migrationBuilder.DropForeignKey(
                name: "FK_Requests_Enrollers_IdEnrollerId",
                table: "Requests");

            migrationBuilder.DropIndex(
                name: "IX_Requests_IdAutoId",
                table: "Requests");

            migrationBuilder.DropIndex(
                name: "IX_Requests_IdClientId",
                table: "Requests");

            migrationBuilder.DropIndex(
                name: "IX_Requests_IdEnrollerId",
                table: "Requests");

            migrationBuilder.DropIndex(
                name: "IX_Breaks_RequestForFixId",
                table: "Breaks");

            migrationBuilder.DropColumn(
                name: "IdAutoId",
                table: "Requests");

            migrationBuilder.DropColumn(
                name: "IdClientId",
                table: "Requests");

            migrationBuilder.DropColumn(
                name: "IdEnrollerId",
                table: "Requests");

            migrationBuilder.DropColumn(
                name: "RequestForFixId",
                table: "Breaks");

            migrationBuilder.AddColumn<int>(
                name: "IdAuto",
                table: "Requests",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "IdClient",
                table: "Requests",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "IdEnroller",
                table: "Requests",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "IdBreak",
                table: "Autos",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IdAuto",
                table: "Requests");

            migrationBuilder.DropColumn(
                name: "IdClient",
                table: "Requests");

            migrationBuilder.DropColumn(
                name: "IdEnroller",
                table: "Requests");

            migrationBuilder.DropColumn(
                name: "IdBreak",
                table: "Autos");

            migrationBuilder.AddColumn<int>(
                name: "IdAutoId",
                table: "Requests",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "IdClientId",
                table: "Requests",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "IdEnrollerId",
                table: "Requests",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RequestForFixId",
                table: "Breaks",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Requests_IdAutoId",
                table: "Requests",
                column: "IdAutoId");

            migrationBuilder.CreateIndex(
                name: "IX_Requests_IdClientId",
                table: "Requests",
                column: "IdClientId");

            migrationBuilder.CreateIndex(
                name: "IX_Requests_IdEnrollerId",
                table: "Requests",
                column: "IdEnrollerId");

            migrationBuilder.CreateIndex(
                name: "IX_Breaks_RequestForFixId",
                table: "Breaks",
                column: "RequestForFixId");

            migrationBuilder.AddForeignKey(
                name: "FK_Breaks_Requests_RequestForFixId",
                table: "Breaks",
                column: "RequestForFixId",
                principalTable: "Requests",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Requests_Autos_IdAutoId",
                table: "Requests",
                column: "IdAutoId",
                principalTable: "Autos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Requests_Clients_IdClientId",
                table: "Requests",
                column: "IdClientId",
                principalTable: "Clients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Requests_Enrollers_IdEnrollerId",
                table: "Requests",
                column: "IdEnrollerId",
                principalTable: "Enrollers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
