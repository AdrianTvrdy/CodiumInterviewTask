using Codium.Interview.EmployeeEvidenceApp.Server.Services;
using Codium.Interview.EmployeeEvidenceApp.Shared.Models.DTOs;
using Codium.Interview.EmployeeEvidenceApp.Shared.Models.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Serilog;

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
        private readonly ILogger<EmployeeController> _logger;

        public EmployeeController(IEmployeeService employeeService, ILogger<EmployeeController> logger)
        {
            _employeeService = employeeService;
            _logger = logger;
        }

        [HttpGet("Employees")]
        public async Task<ActionResult<List<EmployeeListDTO>>> GetEmployees()
        {
            using var logContext = _logger.BeginScope("User GetEmployees Request");
            try
            {
                var result = await _employeeService.GetAllEmployees();
                _logger.LogInformation("Employees retrieved successfully.");
                return Ok(result);
            }
            catch (EmployeeRepositoryException ex)
            {
                _logger.LogError(ex, "An error occurred while retrieving employees.");
                return StatusCode(500, "Internal server error");
            }
            catch (Exception ex)
            {
                Log.Error(ex, "An unexpected error happened while retrieving all employees.");
                return StatusCode(500, "Internal server error");
            }

        }

        [HttpGet("Employee/{id}")]
        public async Task<ActionResult<EmployeeDTO>> GetEmployeeById(int id)
        {
            using var logContext = _logger.BeginScope("User GetEmployeeById Request: {EmployeeId}", id);
            try
            {
                EmployeeDTO employee = await _employeeService.GetEmployeeByIdAsync(id);
                _logger.LogInformation("Employee retrieved successfully.");
                return Ok(employee);
            }
            catch (EmployeeNotFoundException ex)
            {
                _logger.LogWarning(ex, "Employee not found.");
                return NotFound("Employee not found!");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An unexpected error occurred while retrieving employee.");
                return StatusCode(500, "Internal server error!");
            }

        }

        [HttpPost("AddEmployee")]
        public async Task<ActionResult<EmployeeDTO>> AddEmployee(EmployeeDTO employee)
        {
            using var logContext = _logger.BeginScope("User AddEmployee Request: {Employee}", employee);
            try
            {
                var result = await _employeeService.AddEmployeeAsync(employee);
                _logger.LogInformation("Employee added successfully.");
                return Ok(result);
            }
            catch (EmployeeExisitsException ex)
            {
                _logger.LogWarning("Employee already exists.");
                return BadRequest("Employee already exists!");
            }
            catch (ExternalAPINotWorkingException ex )
            {
                _logger.LogError(ex, "External API not working.");
                return StatusCode(500, "External API not working!");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while adding employee.");
                return StatusCode(500, "Internal server error!");
            }

        }

        [HttpDelete("DeleteEmployee/{id}")]
        public async Task<ActionResult> DeleteEmployee(int id)
        {
            using var logContext = _logger.BeginScope("User DeleteEmployee Request: {EmployeeId}", id);
            try
            {
                await _employeeService.DeleteEmployeeAsync(id);
                _logger.LogInformation("Employee deleted successfully.");   
                return Ok();
            }
            catch (EmployeeNotFoundException ex)
            {
                _logger.LogWarning(ex, "Employee not found.");
                return NotFound("Employee not found!");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while deleting employee.");
                return StatusCode(500, "Internal server error!");
            }
        }

        [HttpPut("UpdateEmployee")]
        public async Task<ActionResult<EmployeeDTO>> UpdateEmployee(EmployeeDTO employee)
        {
            using var logContext = _logger.BeginScope("User UpdateEmployee Request: {Employee}", employee);
            try
            {
                var result = await _employeeService.UpdateEmployeeAsync(employee);
                _logger.LogInformation("Employee updated successfully.");
                return Ok(result);
            }
            catch (EmployeeNotFoundException ex)
            {
                _logger.LogWarning(ex, "Employee not found.");
                return NotFound("Employee not found!");
            }
            catch (ExternalAPINotWorkingException ex)
            {
                _logger.LogError(ex, "External API not working.");
                return StatusCode(500, "External API not working");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while updating employee.");
                return StatusCode(500, "Internal server error!");
            }
        }


        [HttpPost("Employees/UploadFile")]
        public async Task<ActionResult> UploadEmployees([FromBody] EmployeeFileDTO employees)
        {
            using var logContext = _logger.BeginScope("User UploadEmployees Request: {Employees}", employees);
            try
            {
                var result = await _employeeService.UploadEmployeesAsync(employees);

                if (result.Skipped > 0)
                {
                    foreach (var reason in result.Reasons)
                    {
                        _logger.LogWarning(reason);
                    }

                }
                else
                {
                    _logger.LogInformation("All employees uploaded successfully.");
                }

                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while uploading employees.");
                return StatusCode(500, "Internal server error");
            }

        }

    }
}
