using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MagicVilla_API.Migrations
{
    /// <inheritdoc />
    public partial class updated_Villa_Table : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Sqft",
                table: "Villas",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "Villas",
                columns: new[] { "Id", "Amenity", "Details", "ImageUrl", "Name", "Occupancy", "Rate", "Sqft", "UpdatedDate", "createdDate" },
                values: new object[,]
                {
                    { 1, "", "Fusce 11 tincidunt maximus leo, sed scelerisque massa auctor sit amet. Donec ex mauris, hendrerit quis nibh ac, efficitur fringilla enim.", "https://dotnetmastery.com/bluevillaimages/villa3.jpg", "Royal Villa", 4, 200.0, 550, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 7, 15, 12, 50, 19, 398, DateTimeKind.Local).AddTicks(2614) },
                    { 2, "", "Fusce 11 tincidunt maximus leo, sed scelerisque massa auctor sit amet. Donec ex mauris, hendrerit quis nibh ac, efficitur fringilla enim.", "https://dotnetmastery.com/bluevillaimages/villa1.jpg", "Premium Pool Villa", 4, 300.0, 550, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 7, 15, 12, 50, 19, 398, DateTimeKind.Local).AddTicks(2632) },
                    { 3, "", "Fusce 11 tincidunt maximus leo, sed scelerisque massa auctor sit amet. Donec ex mauris, hendrerit quis nibh ac, efficitur fringilla enim.", "https://dotnetmastery.com/bluevillaimages/villa4.jpg", "Luxury Pool Villa", 4, 400.0, 750, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 7, 15, 12, 50, 19, 398, DateTimeKind.Local).AddTicks(2634) },
                    { 4, "", "Fusce 11 tincidunt maximus leo, sed scelerisque massa auctor sit amet. Donec ex mauris, hendrerit quis nibh ac, efficitur fringilla enim.", "https://dotnetmastery.com/bluevillaimages/villa5.jpg", "Diamond Villa", 4, 550.0, 900, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 7, 15, 12, 50, 19, 398, DateTimeKind.Local).AddTicks(2636) },
                    { 5, "", "Fusce 11 tincidunt maximus leo, sed scelerisque massa auctor sit amet. Donec ex mauris, hendrerit quis nibh ac, efficitur fringilla enim.", "https://dotnetmastery.com/bluevillaimages/villa2.jpg", "Diamond Pool Villa", 4, 600.0, 1100, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 7, 15, 12, 50, 19, 398, DateTimeKind.Local).AddTicks(2639) }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DropColumn(
                name: "Sqft",
                table: "Villas");
        }
    }
}
