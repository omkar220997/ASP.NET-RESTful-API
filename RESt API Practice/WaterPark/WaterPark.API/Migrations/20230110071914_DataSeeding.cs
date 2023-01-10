using Microsoft.EntityFrameworkCore.Migrations;

namespace WaterPark.API.Migrations
{
    public partial class DataSeeding : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Rides",
                columns: new[] { "Id", "RideAllowedTo", "RideCost", "RideName" },
                values: new object[,]
                {
                    { 1, "Everyone", 100.0, "Rain Dance" },
                    { 2, "Adult", 150.0, "Dark Slide" },
                    { 3, "Adult", 250.0, "90Degree Slide" },
                    { 4, "Children", 75.0, "Tube Way" },
                    { 5, "Children", 150.0, "Wave Pool" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Rides",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Rides",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Rides",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Rides",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Rides",
                keyColumn: "Id",
                keyValue: 5);
        }
    }
}
