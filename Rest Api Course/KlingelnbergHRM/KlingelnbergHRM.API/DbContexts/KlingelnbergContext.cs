using KlingelnbergHRM.API.Entities;
using Microsoft.EntityFrameworkCore;

namespace KlingelnbergHRM.API.DbContexts
{
    public class KlingelnbergContext : DbContext
    {
        public KlingelnbergContext(DbContextOptions<KlingelnbergContext>options):base(options)
        {

        }
        public DbSet<Employee>Employees { get; set; }
        public DbSet<Department> Departments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>().HasData(
                new Employee()
                {
                    EmployeeId = 1,
                    EmployeeName = "Kapil Bhudhia",
                    EmployeeDescription = "IT Department Head"
                },
                new Employee()
                {
                    EmployeeId = 2,
                    EmployeeName = "Sagar Shende",
                    EmployeeDescription = "Product Lead Industry 4.0"
                },
                new Employee()
                {
                    EmployeeId = 3,
                    EmployeeName = "Amit Tilekar",
                    EmployeeDescription = "Product Lead Industry 4.0"
                },
                 new Employee()
                 {
                     EmployeeId = 4,
                     EmployeeName = "Prashant Deshmukh",
                     EmployeeDescription = "Senior Software Engineer"
                 },
                  new Employee()
                  {
                      EmployeeId = 5,
                      EmployeeName = "Omkar Kadam",
                      EmployeeDescription = "Junior Software Engineer"
                  }
                );
            modelBuilder.Entity<Department>().HasData(
                new Department()
                {
                    DepartmentId = 1,
                    DepartmentName = "IT",
                    DepartmentDescription = "Software team working on smart tooling."
                },
                new Department()
                {
                    DepartmentId = 2,
                    DepartmentName = "Design",
                    DepartmentDescription = "Making Designs of products according to customer requirment."
                },
                new Department()
                {
                    DepartmentId = 3,
                    DepartmentName = "Service",
                    DepartmentDescription = "Field working at client place to resolve machine problems."
                },
                new Department()
                {
                    DepartmentId = 4,
                    DepartmentName = "Sales",
                    DepartmentDescription = "Bringing clients to purchase the product."
                },
                new Department()
                {
                    DepartmentId = 5,
                    DepartmentName = "Managment",
                    DepartmentDescription = "Office work."
                }
                );
            base.OnModelCreating(modelBuilder);
        }
    }
}
