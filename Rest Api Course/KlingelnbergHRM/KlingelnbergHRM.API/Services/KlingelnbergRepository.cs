using KlingelnbergHRM.API.DbContexts;
using KlingelnbergHRM.API.Entities;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace KlingelnbergHRM.API.Services
{
    public class KlingelnbergRepository : IklingelnbergRepository
    {
        private readonly KlingelnbergContext _context;

        public KlingelnbergRepository(KlingelnbergContext context)
        {
            _context = context;
        }
        public void AddDepartment(int employeeId, Department department)
        {
            if(employeeId == 0)
            {
                throw new ArgumentNullException(nameof(employeeId));
            }
            if (department == null)
            {
                throw new ArgumentNullException(nameof(department));
            }
            department.EmployeesId = employeeId;
            _context.Departments.Add(department);

        }
        public void DeleteDepartment(Department department)
        {
            _context.Departments.Remove(department);
        }
        public Department GetDepartments(int employeeId, int departmentId)
        {
            if (employeeId == 0)
            {
                throw new ArgumentNullException(nameof(employeeId));
            }
            if (departmentId == 0)
            {
                throw new ArgumentNullException(nameof(departmentId));
            }
            return _context.Departments.Where(x => x.EmployeesId== employeeId).FirstOrDefault();
        }
        public IEnumerable<Department> GetDepartments(int employeeId)
        {
            if(employeeId == 0)
            {
                throw new ArgumentNullException(nameof(employeeId));
            }
            return _context.Departments.Where(x => x.EmployeesId == employeeId).OrderBy(x => x.DepartmentName).ToList();
        }
        public void UpdateDepartment(Department department)
        {

        }

        public void AddEmployee(Employee employee)
        {
            if(employee == null)
            {
                throw new ArgumentNullException(nameof(employee));
            }
            employee.EmployeeId = new int();
            foreach(var department in employee.Departments)
            {
                department.DepartmentId = new int(); 
            }
            _context.Employees.Add(employee);

        }
        public bool EmployeeExists(int employeeId)
        {
            if(employeeId == 0)
            {
                throw new ArgumentNullException(nameof(employeeId));

            }
            return _context.Employees.Any(x => x.EmployeeId == employeeId);
        }
        public void DeleteEmployee(Employee employee)
        {
            if(employee == null)
            {
                throw new ArgumentNullException(nameof(employee));

            }
            _context.Employees.Remove(employee);
        }
        public Employee GetEmployee(int employeeId)
        {
            if(employeeId == 0)
            {
                throw new ArgumentNullException(nameof(employeeId));

            }
            return _context.Employees.FirstOrDefault(x => x.EmployeeId == employeeId);
        }
        public IEnumerable<Employee> GetEmployees()
        {
            return _context.Employees.ToList<Employee>();
        }
        public IEnumerable<Employee> GetEmployees(IEnumerable<int> employeeIds)
        {
            if(employeeIds == null)
            {
                throw new ArgumentNullException(nameof(employeeIds));

            }
            return _context.Employees.Where(x=>employeeIds.Contains(x.EmployeeId)).
                OrderBy(x=>x.EmployeeName).ToList();
        }
        public void UpdateEmployee(Employee employee)
        {

        }
        public bool Save()
        {
            return (_context.SaveChanges()>=0);
        }

    }
}
