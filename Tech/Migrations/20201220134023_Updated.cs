using Microsoft.EntityFrameworkCore.Migrations;

namespace BackEnd.Migrations
{
    public partial class Updated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Autos_Brands_IdBrandid",
                table: "Autos");

            migrationBuilder.DropForeignKey(
                name: "FK_Autos_Persons_IdPersonId",
                table: "Autos");

            migrationBuilder.DropForeignKey(
                name: "FK_Clients_Addresses_IdAddressId",
                table: "Clients");

            migrationBuilder.DropForeignKey(
                name: "FK_Clients_Persons_IdPersonId",
                table: "Clients");

            migrationBuilder.DropForeignKey(
                name: "FK_Enrollers_Persons_IdPersonId",
                table: "Enrollers");

            migrationBuilder.DropForeignKey(
                name: "FK_Enrollers_Specialties_IdSpecialtyId",
                table: "Enrollers");

            migrationBuilder.DropForeignKey(
                name: "FK_Enrollers_Statuses_idStatusId",
                table: "Enrollers");

            migrationBuilder.DropIndex(
                name: "IX_Enrollers_IdPersonId",
                table: "Enrollers");

            migrationBuilder.DropIndex(
                name: "IX_Enrollers_IdSpecialtyId",
                table: "Enrollers");

            migrationBuilder.DropIndex(
                name: "IX_Enrollers_idStatusId",
                table: "Enrollers");

            migrationBuilder.DropIndex(
                name: "IX_Clients_IdAddressId",
                table: "Clients");

            migrationBuilder.DropIndex(
                name: "IX_Clients_IdPersonId",
                table: "Clients");

            migrationBuilder.DropIndex(
                name: "IX_Autos_IdBrandid",
                table: "Autos");

            migrationBuilder.DropIndex(
                name: "IX_Autos_IdPersonId",
                table: "Autos");

            migrationBuilder.DropColumn(
                name: "IdPersonId",
                table: "Enrollers");

            migrationBuilder.DropColumn(
                name: "IdSpecialtyId",
                table: "Enrollers");

            migrationBuilder.DropColumn(
                name: "idStatusId",
                table: "Enrollers");

            migrationBuilder.DropColumn(
                name: "IdAddressId",
                table: "Clients");

            migrationBuilder.DropColumn(
                name: "IdPersonId",
                table: "Clients");

            migrationBuilder.DropColumn(
                name: "IdBrandid",
                table: "Autos");

            migrationBuilder.DropColumn(
                name: "IdPersonId",
                table: "Autos");

            migrationBuilder.AddColumn<int>(
                name: "IdPerson",
                table: "Enrollers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "IdSpecialty",
                table: "Enrollers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "idStatus",
                table: "Enrollers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "IdAddress",
                table: "Clients",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "IdPerson",
                table: "Clients",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "IdBrand",
                table: "Autos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "IdPerson",
                table: "Autos",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IdPerson",
                table: "Enrollers");

            migrationBuilder.DropColumn(
                name: "IdSpecialty",
                table: "Enrollers");

            migrationBuilder.DropColumn(
                name: "idStatus",
                table: "Enrollers");

            migrationBuilder.DropColumn(
                name: "IdAddress",
                table: "Clients");

            migrationBuilder.DropColumn(
                name: "IdPerson",
                table: "Clients");

            migrationBuilder.DropColumn(
                name: "IdBrand",
                table: "Autos");

            migrationBuilder.DropColumn(
                name: "IdPerson",
                table: "Autos");

            migrationBuilder.AddColumn<int>(
                name: "IdPersonId",
                table: "Enrollers",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "IdSpecialtyId",
                table: "Enrollers",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "idStatusId",
                table: "Enrollers",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "IdAddressId",
                table: "Clients",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "IdPersonId",
                table: "Clients",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "IdBrandid",
                table: "Autos",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "IdPersonId",
                table: "Autos",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Enrollers_IdPersonId",
                table: "Enrollers",
                column: "IdPersonId");

            migrationBuilder.CreateIndex(
                name: "IX_Enrollers_IdSpecialtyId",
                table: "Enrollers",
                column: "IdSpecialtyId");

            migrationBuilder.CreateIndex(
                name: "IX_Enrollers_idStatusId",
                table: "Enrollers",
                column: "idStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Clients_IdAddressId",
                table: "Clients",
                column: "IdAddressId");

            migrationBuilder.CreateIndex(
                name: "IX_Clients_IdPersonId",
                table: "Clients",
                column: "IdPersonId");

            migrationBuilder.CreateIndex(
                name: "IX_Autos_IdBrandid",
                table: "Autos",
                column: "IdBrandid");

            migrationBuilder.CreateIndex(
                name: "IX_Autos_IdPersonId",
                table: "Autos",
                column: "IdPersonId");

            migrationBuilder.AddForeignKey(
                name: "FK_Autos_Brands_IdBrandid",
                table: "Autos",
                column: "IdBrandid",
                principalTable: "Brands",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Autos_Persons_IdPersonId",
                table: "Autos",
                column: "IdPersonId",
                principalTable: "Persons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Clients_Addresses_IdAddressId",
                table: "Clients",
                column: "IdAddressId",
                principalTable: "Addresses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Clients_Persons_IdPersonId",
                table: "Clients",
                column: "IdPersonId",
                principalTable: "Persons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Enrollers_Persons_IdPersonId",
                table: "Enrollers",
                column: "IdPersonId",
                principalTable: "Persons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Enrollers_Specialties_IdSpecialtyId",
                table: "Enrollers",
                column: "IdSpecialtyId",
                principalTable: "Specialties",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Enrollers_Statuses_idStatusId",
                table: "Enrollers",
                column: "idStatusId",
                principalTable: "Statuses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
