using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MovieTickets_API.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "movieDetails",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MovieName = table.Column<string>(nullable: true),
                    ScreenNumber = table.Column<int>(nullable: false),
                    ShowTime = table.Column<DateTime>(nullable: false),
                    MovieType = table.Column<string>(nullable: true),
                    TicketPrice = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_movieDetails", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "movieDetails",
                columns: new[] { "Id", "MovieName", "MovieType", "ScreenNumber", "ShowTime", "TicketPrice" },
                values: new object[,]
                {
                    { 1001, "Bhediya", "3D", 2, new DateTime(2023, 1, 10, 8, 30, 0, 0, DateTimeKind.Unspecified), 350.0 },
                    { 1002, "Avatar: The Way of Water", "4D", 3, new DateTime(2023, 1, 10, 10, 45, 0, 0, DateTimeKind.Unspecified), 480.0 },
                    { 1003, "Ved", "3D", 1, new DateTime(2023, 1, 10, 9, 0, 0, 0, DateTimeKind.Unspecified), 275.0 },
                    { 1004, "Cirkus", "2D", 3, new DateTime(2023, 1, 10, 2, 30, 0, 0, DateTimeKind.Unspecified), 300.0 },
                    { 1005, "Drishyam 2", "2D", 1, new DateTime(2023, 1, 10, 1, 30, 0, 0, DateTimeKind.Unspecified), 350.0 },
                    { 1006, "Vikram", "2D", 2, new DateTime(2023, 1, 10, 3, 30, 0, 0, DateTimeKind.Unspecified), 400.0 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "movieDetails");
        }
    }
}
