using Codium.Interview.EmployeeEvidenceApp.Server.Services;
using Codium.Interview.EmployeeEvidenceApp.Shared.Models.DTOs;
using Codium.Interview.EmployeeEvidenceApp.Shared.Models.Exceptions;
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
            try
            {
                EmployeeDTO employee = await _employeeService.GetEmployeeByIdAsync(id);

                return Ok(employee);
            }
            catch (EmployeeNotFoundException)
            {
                return NotFound("Employee not found!");
            }

        }

        [HttpPost("AddEmployee")]
        public async Task<ActionResult<EmployeeDTO>> AddEmployee(EmployeeDTO employee)
        {
            

            try
            {
                var result = await _employeeService.AddEmployeeAsync(employee);
                return Ok(result);
            }
            catch (EmployeeExisitsException)
            {
                return BadRequest("Employee already exists!");
            }
            catch (ExternalAPINotWorkingException)
            {
                return StatusCode(500, "External API not working!");
            }

        }

        [HttpDelete("DeleteEmployee/{id}")]
        public async Task<ActionResult> DeleteEmployee(int id)
        {
            try
            {
                await _employeeService.DeleteEmployeeAsync(id);
                return Ok();
            }
            catch (EmployeeNotFoundException)
            {
                return NotFound("Employee not found!");
            }
        }

        [HttpPut("UpdateEmployee")]
        public async Task<ActionResult<EmployeeDTO>> UpdateEmployee(EmployeeDTO employee)
        {
            try
            {
                var result = await _employeeService.UpdateEmployeeAsync(employee);
                return Ok(result);
            }
            catch (EmployeeNotFoundException)
            {
                return NotFound("Employee not found!");
            }
            catch (ExternalAPINotWorkingException)
            {
                return StatusCode(500, "External API not working!");
            }
        }



    }
}
