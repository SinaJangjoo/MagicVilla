using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MagicVillaAPI.Migrations
{
    /// <inheritdoc />
    public partial class addVillaNumberToDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "VillaNumbers",
                columns: table => new
                {
                    VillaNo = table.Column<int>(type: "int", nullable: false),
                    SpecialDetails = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VillaNumbers", x => x.VillaNo);
                });

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "VillaNumbers");

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "id",
                keyValue: 1,
                column: "createDate",
                value: new DateTime(2023, 7, 26, 16, 31, 49, 996, DateTimeKind.Local).AddTicks(7503));

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "id",
                keyValue: 2,
                column: "createDate",
                value: new DateTime(2023, 7, 26, 16, 31, 49, 996, DateTimeKind.Local).AddTicks(7516));

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "id",
                keyValue: 3,
                column: "createDate",
                value: new DateTime(2023, 7, 26, 16, 31, 49, 996, DateTimeKind.Local).AddTicks(7517));

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "id",
                keyValue: 4,
                column: "createDate",
                value: new DateTime(2023, 7, 26, 16, 31, 49, 996, DateTimeKind.Local).AddTicks(7519));

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "id",
                keyValue: 5,
                column: "createDate",
                value: new DateTime(2023, 7, 26, 16, 31, 49, 996, DateTimeKind.Local).AddTicks(7520));
        }
    }
}
