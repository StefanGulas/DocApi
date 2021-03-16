using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DocApi.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Documents",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Größe = table.Column<int>(type: "int", nullable: false),
                    Typ = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ZeitpunktDesHochladens = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Documents", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Role",
                columns: table => new
                {
                    RoleName = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Beschreibung = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Role", x => x.RoleName);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Anrede = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Vorname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Nachname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RoleName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RoleName1 = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_Role_RoleName1",
                        column: x => x.RoleName1,
                        principalTable: "Role",
                        principalColumn: "RoleName",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Documents",
                columns: new[] { "Id", "Größe", "Name", "Typ", "UserId", "ZeitpunktDesHochladens" },
                values: new object[,]
                {
                    { 1, 10000, "Vorderrad", "CAD", 1, new DateTime(2021, 1, 4, 11, 20, 40, 0, DateTimeKind.Unspecified) },
                    { 2, 10000, "Vorderrad", "CAD", 1, new DateTime(2021, 1, 4, 11, 20, 40, 0, DateTimeKind.Unspecified) },
                    { 3, 12000, "Hinterrad", "CAD", 1, new DateTime(2020, 4, 4, 10, 20, 40, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "Role",
                columns: new[] { "RoleName", "Beschreibung" },
                values: new object[,]
                {
                    { "User", "Mitarbeiter" },
                    { "Admin", "Administrator der Seite" },
                    { "Partner", "Externe Benutzer" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Anrede", "Email", "Nachname", "Password", "RoleName", "RoleName1", "Vorname" },
                values: new object[,]
                {
                    { 1, "Herr", "harald.schmid@test.de", "Schmid", null, "User", null, "Harald" },
                    { 2, "Herr", "heinz.huber@test.de", "Huber", null, "Admin", null, "Heinz" },
                    { 3, "Frau", "heidi.breitner@test.de", "Breitner", null, "Admin", null, "Heidi" },
                    { 4, "Herr", "martin.klein@test.de", "Klein", null, "User", null, "Martin" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Users_RoleName1",
                table: "Users",
                column: "RoleName1");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Documents");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Role");
        }
    }
}
