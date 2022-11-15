using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CarBookingData.Migrations
{
    /// <inheritdoc />
    public partial class DataSeeding : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Makes",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "Name", "UpdatedBy", "UpdatedDate" },
                values: new object[,]
                {
                    { 4, "Sajesh", new DateTime(2022, 11, 14, 20, 39, 24, 491, DateTimeKind.Local).AddTicks(1264), "Honda", "Sajesh", new DateTime(2022, 11, 14, 20, 39, 24, 491, DateTimeKind.Local).AddTicks(1314) },
                    { 5, "Sajesh", new DateTime(2022, 11, 14, 20, 39, 24, 491, DateTimeKind.Local).AddTicks(1320), "Mercides", "Sajesh", new DateTime(2022, 11, 14, 20, 39, 24, 491, DateTimeKind.Local).AddTicks(1322) }
                });

            migrationBuilder.InsertData(
                table: "CarModels",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "MakeId", "Name", "UpdatedBy", "UpdatedDate" },
                values: new object[,]
                {
                    { 6, "Sajesh", new DateTime(2022, 11, 14, 20, 39, 24, 491, DateTimeKind.Local).AddTicks(1422), 4, "Jazz", "Sajesh", new DateTime(2022, 11, 14, 20, 39, 24, 491, DateTimeKind.Local).AddTicks(1424) },
                    { 7, "Sajesh", new DateTime(2022, 11, 14, 20, 39, 24, 491, DateTimeKind.Local).AddTicks(1427), 5, "RX400", "Sajesh", new DateTime(2022, 11, 14, 20, 39, 24, 491, DateTimeKind.Local).AddTicks(1429) }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "CarModels",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "CarModels",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Makes",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Makes",
                keyColumn: "Id",
                keyValue: 5);
        }
    }
}
