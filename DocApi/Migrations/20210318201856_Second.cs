using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DocApi.Migrations
{
    public partial class Second : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "RoleId", "Beschreibung", "RoleName" },
                values: new object[] { 1, "Mitarbeiter", "User" });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "RoleId", "Beschreibung", "RoleName" },
                values: new object[] { 2, "Administrator der Seite", "Admin" });

            migrationBuilder.InsertData(
                table: "Roles",
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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Documents",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Documents",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Documents",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: 1);
        }
    }
}
