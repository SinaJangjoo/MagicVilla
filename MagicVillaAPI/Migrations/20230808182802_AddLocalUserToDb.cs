using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MagicVillaAPI.Migrations
{
    /// <inheritdoc />
    public partial class AddLocalUserToDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "LocalUsers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Role = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LocalUsers", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "id",
                keyValue: 1,
                column: "createDate",
                value: new DateTime(2023, 8, 8, 21, 58, 2, 449, DateTimeKind.Local).AddTicks(5120));

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "id",
                keyValue: 2,
                column: "createDate",
                value: new DateTime(2023, 8, 8, 21, 58, 2, 449, DateTimeKind.Local).AddTicks(5139));

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "id",
                keyValue: 3,
                column: "createDate",
                value: new DateTime(2023, 8, 8, 21, 58, 2, 449, DateTimeKind.Local).AddTicks(5141));

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "id",
                keyValue: 4,
                column: "createDate",
                value: new DateTime(2023, 8, 8, 21, 58, 2, 449, DateTimeKind.Local).AddTicks(5143));

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "id",
                keyValue: 5,
                column: "createDate",
                value: new DateTime(2023, 8, 8, 21, 58, 2, 449, DateTimeKind.Local).AddTicks(5144));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LocalUsers");

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "id",
                keyValue: 1,
                column: "createDate",
                value: new DateTime(2023, 8, 5, 23, 58, 56, 207, DateTimeKind.Local).AddTicks(7152));

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "id",
                keyValue: 2,
                column: "createDate",
                value: new DateTime(2023, 8, 5, 23, 58, 56, 207, DateTimeKind.Local).AddTicks(7163));

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "id",
                keyValue: 3,
                column: "createDate",
                value: new DateTime(2023, 8, 5, 23, 58, 56, 207, DateTimeKind.Local).AddTicks(7165));

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "id",
                keyValue: 4,
                column: "createDate",
                value: new DateTime(2023, 8, 5, 23, 58, 56, 207, DateTimeKind.Local).AddTicks(7166));

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "id",
                keyValue: 5,
                column: "createDate",
                value: new DateTime(2023, 8, 5, 23, 58, 56, 207, DateTimeKind.Local).AddTicks(7168));
        }
    }
}
