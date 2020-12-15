using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Tech.Migrations
{
    public partial class Initials : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Addresses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Street = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Home = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Apartament = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Addresses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Brands",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TitleBrand = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Model = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Brands", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Persons",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SurnameNP = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Passport = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Persons", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Specialties",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TitleSpec = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Specialties", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Statuses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    status = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Statuses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Autos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdBrandid = table.Column<int>(type: "int", nullable: true),
                    IdPersonId = table.Column<int>(type: "int", nullable: true),
                    RegNumer = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Color = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateStart = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Autos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Autos_Brands_IdBrandid",
                        column: x => x.IdBrandid,
                        principalTable: "Brands",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Autos_Persons_IdPersonId",
                        column: x => x.IdPersonId,
                        principalTable: "Persons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Clients",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdPersonId = table.Column<int>(type: "int", nullable: true),
                    IdAddressId = table.Column<int>(type: "int", nullable: true),
                    DateBirth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clients", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Clients_Addresses_IdAddressId",
                        column: x => x.IdAddressId,
                        principalTable: "Addresses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Clients_Persons_IdPersonId",
                        column: x => x.IdPersonId,
                        principalTable: "Persons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Enrollers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdSpecialtyId = table.Column<int>(type: "int", nullable: true),
                    IdPersonId = table.Column<int>(type: "int", nullable: true),
                    Level = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PeriodWork = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    idStatusId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Enrollers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Enrollers_Persons_IdPersonId",
                        column: x => x.IdPersonId,
                        principalTable: "Persons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Enrollers_Specialties_IdSpecialtyId",
                        column: x => x.IdSpecialtyId,
                        principalTable: "Specialties",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Enrollers_Statuses_idStatusId",
                        column: x => x.idStatusId,
                        principalTable: "Statuses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Requests",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdClientId = table.Column<int>(type: "int", nullable: true),
                    IdEnrollerId = table.Column<int>(type: "int", nullable: true),
                    IdAutoId = table.Column<int>(type: "int", nullable: true),
                    Daterequest = table.Column<DateTime>(type: "datetime2", nullable: false),
                    StatusReady = table.Column<bool>(type: "bit", nullable: false),
                    PriceBreak = table.Column<double>(type: "float", nullable: false),
                    DateEnd = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Requests", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Requests_Autos_IdAutoId",
                        column: x => x.IdAutoId,
                        principalTable: "Autos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Requests_Clients_IdClientId",
                        column: x => x.IdClientId,
                        principalTable: "Clients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Requests_Enrollers_IdEnrollerId",
                        column: x => x.IdEnrollerId,
                        principalTable: "Enrollers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Breaks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BreakName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<double>(type: "float", nullable: false),
                    PeriodBreak = table.Column<int>(type: "int", nullable: false),
                    RequestForFixId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Breaks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Breaks_Requests_RequestForFixId",
                        column: x => x.RequestForFixId,
                        principalTable: "Requests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Autos_IdBrandid",
                table: "Autos",
                column: "IdBrandid");

            migrationBuilder.CreateIndex(
                name: "IX_Autos_IdPersonId",
                table: "Autos",
                column: "IdPersonId");

            migrationBuilder.CreateIndex(
                name: "IX_Breaks_RequestForFixId",
                table: "Breaks",
                column: "RequestForFixId");

            migrationBuilder.CreateIndex(
                name: "IX_Clients_IdAddressId",
                table: "Clients",
                column: "IdAddressId");

            migrationBuilder.CreateIndex(
                name: "IX_Clients_IdPersonId",
                table: "Clients",
                column: "IdPersonId");

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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Breaks");

            migrationBuilder.DropTable(
                name: "Requests");

            migrationBuilder.DropTable(
                name: "Autos");

            migrationBuilder.DropTable(
                name: "Clients");

            migrationBuilder.DropTable(
                name: "Enrollers");

            migrationBuilder.DropTable(
                name: "Brands");

            migrationBuilder.DropTable(
                name: "Addresses");

            migrationBuilder.DropTable(
                name: "Persons");

            migrationBuilder.DropTable(
                name: "Specialties");

            migrationBuilder.DropTable(
                name: "Statuses");
        }
    }
}
