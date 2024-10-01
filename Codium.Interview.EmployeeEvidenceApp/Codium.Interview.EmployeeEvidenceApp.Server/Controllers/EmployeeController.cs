using Codium.Interview.EmployeeEvidenceApp.Server.Services;
using Codium.Interview.EmployeeEvidenceApp.Shared.Models.DTOs;
using Codium.Interview.EmployeeEvidenceApp.Shared.Models.Exceptions;
using Microsoft.AspNetCore.Mvc;

namespace Codium.Interview.EmployeeEvidenceApp.Server.Controllers
{
    /// <summary>
    /// A Controller for managing employees
    /// </summary>
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
            try
            {
                return Ok(await _employeeService.GetAllEmployees());
            }
            catch (EmployeeRepositoryException ex)
            {
                //log
                return StatusCode(500, "Internal server error");
            }
            catch (Exception ex)
            {
                //log
                return StatusCode(500, "Internal server error");
            }

        }

        [HttpGet("Employee/{id}")]
        public async Task<ActionResult<EmployeeDTO>> GetEmployeeById(int id)
        {
            try
            {
                EmployeeDTO employee = await _employeeService.GetEmployeeByIdAsync(id);

                return Ok(employee);
            }
            catch (EmployeeNotFoundException ex)
            {
                //log
                return NotFound("Employee not found!");
            }
            catch (Exception ex)
            {
                //log
                return StatusCode(500, "Internal server error!");
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
            catch (EmployeeExisitsException ex)
            {
                //log
                return BadRequest("Employee already exists!");
            }
            catch (ExternalAPINotWorkingException ex )
            {
                //log
                return StatusCode(500, "External API not working!");
            }
            catch (Exception ex)
            {
                //log
                return StatusCode(500, "Internal server error!");
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
            catch (EmployeeNotFoundException ex)
            {
                //log
                return NotFound("Employee not found!");
            }
            catch (Exception ex)
            {
                //log
                return StatusCode(500, "Internal server error!");
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
            catch (EmployeeNotFoundException ex)
            {
                return NotFound("Employee not found!");
            }
            catch (ExternalAPINotWorkingException ex)
            {
                return StatusCode(500, "External API not working");
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error!");
            }
        }


        [HttpPost("Employees/UploadFile")]
        public async Task<ActionResult> UploadEmployees([FromBody] EmployeeFileDTO employees)
        {
            try
            {
                await _employeeService.UploadEmployeesAsync(employees);
                return Ok();
            }
            catch(ExternalAPINotWorkingException ex )
            {
                return StatusCode(500, "External API not working");
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error");
            }

        }

    }
}
