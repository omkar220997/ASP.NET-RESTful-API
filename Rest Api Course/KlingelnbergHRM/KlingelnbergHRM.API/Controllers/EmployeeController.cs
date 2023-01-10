using KlingelnbergHRM.API.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;

namespace KlingelnbergHRM.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IklingelnbergRepository _klingelnbergRepository;

        public EmployeeController(IklingelnbergRepository kligelnberRepository)
        {
            _klingelnbergRepository = kligelnberRepository ??
                throw new ArgumentNullException(nameof(kligelnberRepository));
        }
        [HttpGet()]
        public IActionResult GetEmployees()
        {
            var employeesFromRepository = _klingelnbergRepository.GetEmployees();
            return Ok(employeesFromRepository);
        }
        [HttpGet("{employeeId}")]
        public IActionResult GetEmployee(int employeeId)
        {
            var employeesfromRepository = _klingelnbergRepository.GetEmployee(employeeId);
            if (employeesfromRepository == null)
            {
                return NotFound();
            }
            return Ok(employeesfromRepository);
        }
        
    }
}
