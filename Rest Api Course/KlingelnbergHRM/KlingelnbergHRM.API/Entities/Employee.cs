using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace KlingelnbergHRM.API.Entities
{
    public class Employee
    {
        [Key]
        public int EmployeeId { get; set; }
        [Required]
        public string EmployeeName { get; set; }
        [MaxLength(100)]
        public string EmployeeDescription { get; set; }
        public ICollection<Department> Departments { get; set; }= new List<Department>();
    }
}
