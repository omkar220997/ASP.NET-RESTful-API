using KlingelnbergHRM.API.Entities;
using System.Collections;
using System.Collections.Generic;
using System;

namespace KlingelnbergHRM.API.Services
{
    
    
        public interface IklingelnbergRepository
        {
            IEnumerable<Department> GetDepartments(int employeeId);
            Department GetDepartments(int employeeId, int departmentId);
            void AddDepartment(int employeeId, Department department);
            void UpdateDepartment(Department department);
            void DeleteDepartment(Department department);

            IEnumerable<Employee> GetEmployees();
            Employee GetEmployee(int employeeId);
            IEnumerable<Employee> GetEmployees(IEnumerable<int> employeeIds);
            void AddEmployee(Employee employee);
            void DeleteEmployee(Employee employee);
            void UpdateEmployee(Employee employee);
            bool EmployeeExists(int employeeId);
            bool Save();

        }
    
}
