using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DocApi.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Role",
                columns: table => new
                {
                    RoleId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Beschreibung = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Role", x => x.RoleId);
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
                    RoleId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_Role_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Role",
                        principalColumn: "RoleId",
                        onDelete: ReferentialAction.Cascade);
                });

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
                    table.ForeignKey(
                        name: "FK_Documents_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Role",
                columns: new[] { "RoleId", "Beschreibung", "RoleName" },
                values: new object[] { 1, "Mitarbeiter", "User" });

            migrationBuilder.InsertData(
                table: "Role",
                columns: new[] { "RoleId", "Beschreibung", "RoleName" },
                values: new object[] { 2, "Administrator der Seite", "Admin" });

            migrationBuilder.InsertData(
                table: "Role",
                columns: new[] { "RoleId", "Beschreibung", "RoleName" },
                values: new object[] { 3, "Externe Benutzer", "Partner" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Anrede", "Email", "Nachname", "Password", "RoleId", "Vorname" },
                values: new object[,]
                {
                    { 1, "Herr", "harald.schmid@test.de", "Schmid", null, 1, "Harald" },
                    { 4, "Herr", "martin.klein@test.de", "Klein", null, 1, "Martin" },
                    { 2, "Herr", "heinz.huber@test.de", "Huber", null, 2, "Heinz" },
                    { 3, "Frau", "heidi.breitner@test.de", "Breitner", null, 2, "Heidi" }
                });

            migrationBuilder.InsertData(
                table: "Documents",
                columns: new[] { "Id", "Größe", "Name", "Typ", "UserId", "ZeitpunktDesHochladens" },
                values: new object[] { 1, 10000, "Vorderrad", "CAD", 1, new DateTime(2021, 1, 4, 11, 20, 40, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "Documents",
                columns: new[] { "Id", "Größe", "Name", "Typ", "UserId", "ZeitpunktDesHochladens" },
                values: new object[] { 2, 10000, "Vorderrad", "CAD", 1, new DateTime(2021, 1, 4, 11, 20, 40, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "Documents",
                columns: new[] { "Id", "Größe", "Name", "Typ", "UserId", "ZeitpunktDesHochladens" },
                values: new object[] { 3, 12000, "Hinterrad", "CAD", 1, new DateTime(2020, 4, 4, 10, 20, 40, 0, DateTimeKind.Unspecified) });

            migrationBuilder.CreateIndex(
                name: "IX_Documents_UserId",
                table: "Documents",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_RoleId",
                table: "Users",
                column: "RoleId");
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
