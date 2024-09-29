using Codium.Interview.EmployeeEvidenceApp.Server.Services;
using Codium.Interview.EmployeeEvidenceApp.Shared.Models.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace Codium.Interview.EmployeeEvidenceApp.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;

        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        [HttpGet("Employees")]
        public async Task<ActionResult<List<EmployeeListDTO>>> GetEmployees()
        {
            // errors
            return Ok(await _employeeService.GetAllEmployees());
        }

        [HttpGet("Employee/{id}")]
        public async Task<ActionResult<EmployeeDTO>> GetEmployeeById(int id)
        {
            return Ok(await _employeeService.GetEmployeeByIdAsync(id));
        }

        [HttpPost("AddEmployee")]
        public async Task<ActionResult<EmployeeDTO>> AddEmployee(EmployeeDTO employee)
        {
            var result = await _employeeService.AddEmployeeAsync(employee);
            if (result == null)
            {
                return BadRequest();
            }

            return Ok(result);
        }



    }
}
