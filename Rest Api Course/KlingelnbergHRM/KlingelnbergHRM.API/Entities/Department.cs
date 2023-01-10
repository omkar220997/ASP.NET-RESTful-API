using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KlingelnbergHRM.API.Entities
{
    public class Department
    {
        [Key]
        public int DepartmentId { get; set; }
        [Required]
        public string DepartmentName { get; set; }
        [MaxLength(250)]
        public string DepartmentDescription { get; set; }
        [ForeignKey("EmployeesId")]
        public Employee Employee { get; set; }

        public int EmployeesId { get; set; }

    }
}
