using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MagicVillaAPI.Migrations
{
    /// <inheritdoc />
    public partial class seedDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Villas",
                columns: new[] { "id", "Amenity", "ImageUrl", "Occupancy", "Sqft", "createDate", "details", "name", "rate", "updateDate" },
                values: new object[,]
                {
                    { 1, "", "https://dotnetmasteryimages.blob.core.windows.net/bluevillaimages/villa3.jpg", 4, 550, new DateTime(2023, 7, 26, 16, 31, 49, 996, DateTimeKind.Local).AddTicks(7503), "Fusce 11 tincidunt maximus leo, sed scelerisque massa auctor sit amet. Donec ex mauris, hendrerit quis nibh ac, efficitur fringilla enim.", "Royal Villa", 200.0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, "", "https://dotnetmasteryimages.blob.core.windows.net/bluevillaimages/villa1.jpg", 4, 550, new DateTime(2023, 7, 26, 16, 31, 49, 996, DateTimeKind.Local).AddTicks(7516), "Fusce 11 tincidunt maximus leo, sed scelerisque massa auctor sit amet. Donec ex mauris, hendrerit quis nibh ac, efficitur fringilla enim.", "Premium Pool Villa", 300.0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, "", "https://dotnetmasteryimages.blob.core.windows.net/bluevillaimages/villa4.jpg", 4, 750, new DateTime(2023, 7, 26, 16, 31, 49, 996, DateTimeKind.Local).AddTicks(7517), "Fusce 11 tincidunt maximus leo, sed scelerisque massa auctor sit amet. Donec ex mauris, hendrerit quis nibh ac, efficitur fringilla enim.", "Luxury Pool Villa", 400.0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 4, "", "https://dotnetmasteryimages.blob.core.windows.net/bluevillaimages/villa5.jpg", 4, 900, new DateTime(2023, 7, 26, 16, 31, 49, 996, DateTimeKind.Local).AddTicks(7519), "Fusce 11 tincidunt maximus leo, sed scelerisque massa auctor sit amet. Donec ex mauris, hendrerit quis nibh ac, efficitur fringilla enim.", "Diamond Villa", 550.0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 5, "", "https://dotnetmasteryimages.blob.core.windows.net/bluevillaimages/villa2.jpg", 4, 1100, new DateTime(2023, 7, 26, 16, 31, 49, 996, DateTimeKind.Local).AddTicks(7520), "Fusce 11 tincidunt maximus leo, sed scelerisque massa auctor sit amet. Donec ex mauris, hendrerit quis nibh ac, efficitur fringilla enim.", "Diamond Pool Villa", 600.0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Villas",
                keyColumn: "id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Villas",
                keyColumn: "id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Villas",
                keyColumn: "id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Villas",
                keyColumn: "id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Villas",
                keyColumn: "id",
                keyValue: 5);
        }
    }
}
