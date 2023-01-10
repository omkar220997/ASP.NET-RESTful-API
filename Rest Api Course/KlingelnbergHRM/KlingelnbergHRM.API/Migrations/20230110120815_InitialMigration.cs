using Microsoft.EntityFrameworkCore.Migrations;

namespace KlingelnbergHRM.API.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    EmployeeId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeName = table.Column<string>(nullable: false),
                    EmployeeDescription = table.Column<string>(maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.EmployeeId);
                });

            migrationBuilder.CreateTable(
                name: "Departments",
                columns: table => new
                {
                    DepartmentId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DepartmentName = table.Column<string>(nullable: false),
                    DepartmentDescription = table.Column<string>(maxLength: 250, nullable: true),
                    EmployeesId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departments", x => x.DepartmentId);
                    table.ForeignKey(
                        name: "FK_Departments_Employees_EmployeesId",
                        column: x => x.EmployeesId,
                        principalTable: "Employees",
                        principalColumn: "EmployeeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "DepartmentId", "DepartmentDescription", "DepartmentName", "EmployeesId" },
                values: new object[,]
                {
                    { 1, "Software team working on smart tooling.", "IT", 0 },
                    { 2, "Making Designs of products according to customer requirment.", "Design", 0 },
                    { 3, "Field working at client place to resolve machine problems.", "Service", 0 },
                    { 4, "Bringing clients to purchase the product.", "Sales", 0 },
                    { 5, "Office work.", "Managment", 0 }
                });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "EmployeeId", "EmployeeDescription", "EmployeeName" },
                values: new object[,]
                {
                    { 1, "IT Department Head", "Kapil Bhudhia" },
                    { 2, "Product Lead Industry 4.0", "Sagar Shende" },
                    { 3, "Product Lead Industry 4.0", "Amit Tilekar" },
                    { 4, "Senior Software Engineer", "Prashant Deshmukh" },
                    { 5, "Junior Software Engineer", "Omkar Kadam" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Departments_EmployeesId",
                table: "Departments",
                column: "EmployeesId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Departments");

            migrationBuilder.DropTable(
                name: "Employees");
        }
    }
}
