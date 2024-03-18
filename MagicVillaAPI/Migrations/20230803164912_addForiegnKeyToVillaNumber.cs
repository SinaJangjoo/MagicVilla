using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MagicVillaAPI.Migrations
{
    /// <inheritdoc />
    public partial class addForiegnKeyToVillaNumber : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "VillaId",
                table: "VillaNumbers",
                type: "int",
                nullable: false,
                defaultValue: 0);

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

            migrationBuilder.CreateIndex(
                name: "IX_VillaNumbers_VillaId",
                table: "VillaNumbers",
                column: "VillaId");

            migrationBuilder.AddForeignKey(
                name: "FK_VillaNumbers_Villas_VillaId",
                table: "VillaNumbers",
                column: "VillaId",
                principalTable: "Villas",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_VillaNumbers_Villas_VillaId",
                table: "VillaNumbers");

            migrationBuilder.DropIndex(
                name: "IX_VillaNumbers_VillaId",
                table: "VillaNumbers");

            migrationBuilder.DropColumn(
                name: "VillaId",
                table: "VillaNumbers");

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "id",
                keyValue: 1,
                column: "createDate",
                value: new DateTime(2023, 7, 31, 17, 44, 39, 131, DateTimeKind.Local).AddTicks(8947));

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "id",
                keyValue: 2,
                column: "createDate",
                value: new DateTime(2023, 7, 31, 17, 44, 39, 131, DateTimeKind.Local).AddTicks(8956));

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "id",
                keyValue: 3,
                column: "createDate",
                value: new DateTime(2023, 7, 31, 17, 44, 39, 131, DateTimeKind.Local).AddTicks(8957));

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "id",
                keyValue: 4,
                column: "createDate",
                value: new DateTime(2023, 7, 31, 17, 44, 39, 131, DateTimeKind.Local).AddTicks(8959));

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "id",
                keyValue: 5,
                column: "createDate",
                value: new DateTime(2023, 7, 31, 17, 44, 39, 131, DateTimeKind.Local).AddTicks(8961));
        }
    }
}
