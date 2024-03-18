using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MagicVillaAPI.Migrations
{
    /// <inheritdoc />
    public partial class addNullablesToVilla : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "ImageUrl",
                table: "Villas",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Amenity",
                table: "Villas",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "ImageUrl",
                table: "Villas",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Amenity",
                table: "Villas",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "id",
                keyValue: 1,
                column: "createDate",
                value: new DateTime(2023, 8, 3, 20, 19, 12, 50, DateTimeKind.Local).AddTicks(1166));

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "id",
                keyValue: 2,
                column: "createDate",
                value: new DateTime(2023, 8, 3, 20, 19, 12, 50, DateTimeKind.Local).AddTicks(1178));

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "id",
                keyValue: 3,
                column: "createDate",
                value: new DateTime(2023, 8, 3, 20, 19, 12, 50, DateTimeKind.Local).AddTicks(1179));

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "id",
                keyValue: 4,
                column: "createDate",
                value: new DateTime(2023, 8, 3, 20, 19, 12, 50, DateTimeKind.Local).AddTicks(1181));

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "id",
                keyValue: 5,
                column: "createDate",
                value: new DateTime(2023, 8, 3, 20, 19, 12, 50, DateTimeKind.Local).AddTicks(1183));
        }
    }
}
