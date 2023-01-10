using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Ecommerce.Api.Migrations
{
    public partial class SeedingData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CreatedDate", "DisplayOrder", "Title" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 1, 9, 17, 10, 8, 215, DateTimeKind.Local).AddTicks(9116), 1, "Samsung" },
                    { 2, new DateTime(2023, 1, 9, 17, 10, 8, 218, DateTimeKind.Local).AddTicks(943), 2, "Apple" },
                    { 3, new DateTime(2023, 1, 9, 17, 10, 8, 218, DateTimeKind.Local).AddTicks(983), 3, "Motorola" },
                    { 4, new DateTime(2023, 1, 9, 17, 10, 8, 218, DateTimeKind.Local).AddTicks(985), 4, "Nokia" },
                    { 5, new DateTime(2023, 1, 9, 17, 10, 8, 218, DateTimeKind.Local).AddTicks(986), 5, "RealMe" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 5);
        }
    }
}
