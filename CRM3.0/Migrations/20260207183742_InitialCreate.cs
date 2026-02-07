using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CRM.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Unternehmen",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Firmenname = table.Column<string>(type: "TEXT", nullable: true),
                    Rechtsform = table.Column<string>(type: "TEXT", nullable: true),
                    Branche = table.Column<string>(type: "TEXT", nullable: true),
                    Email = table.Column<string>(type: "TEXT", nullable: true),
                    Telefon = table.Column<string>(type: "TEXT", nullable: true),
                    Fax = table.Column<string>(type: "TEXT", nullable: true),
                    Website = table.Column<string>(type: "TEXT", nullable: true),
                    Straße = table.Column<string>(type: "TEXT", nullable: true),
                    PLZ = table.Column<string>(type: "TEXT", nullable: true),
                    Ort = table.Column<string>(type: "TEXT", nullable: true),
                    Land = table.Column<string>(type: "TEXT", nullable: true),
                    Handelsregisternummer = table.Column<string>(type: "TEXT", nullable: true),
                    Steuernummer = table.Column<string>(type: "TEXT", nullable: true),
                    UStIdNr = table.Column<string>(type: "TEXT", nullable: true),
                    AnsprechpartnerName = table.Column<string>(type: "TEXT", nullable: true),
                    AnsprechpartnerPosition = table.Column<string>(type: "TEXT", nullable: true),
                    ErstelltAm = table.Column<DateTime>(type: "TEXT", nullable: false),
                    GeändertAm = table.Column<DateTime>(type: "TEXT", nullable: true),
                    Notizen = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Unternehmen", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Versicherte",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Vorname = table.Column<string>(type: "TEXT", nullable: true),
                    Nachname = table.Column<string>(type: "TEXT", nullable: true),
                    Firma = table.Column<string>(type: "TEXT", nullable: true),
                    Email = table.Column<string>(type: "TEXT", nullable: true),
                    Telefon = table.Column<string>(type: "TEXT", nullable: true),
                    Mobil = table.Column<string>(type: "TEXT", nullable: true),
                    Straße = table.Column<string>(type: "TEXT", nullable: true),
                    PLZ = table.Column<string>(type: "TEXT", nullable: true),
                    Ort = table.Column<string>(type: "TEXT", nullable: true),
                    Land = table.Column<string>(type: "TEXT", nullable: true),
                    ErstelltAm = table.Column<DateTime>(type: "TEXT", nullable: false),
                    GeändertAm = table.Column<DateTime>(type: "TEXT", nullable: true),
                    Notizen = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Versicherte", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Unternehmen");

            migrationBuilder.DropTable(
                name: "Versicherte");
        }
    }
}
