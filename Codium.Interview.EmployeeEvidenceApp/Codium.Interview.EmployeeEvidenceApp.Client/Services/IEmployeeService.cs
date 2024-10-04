using Codium.Interview.EmployeeEvidenceApp.Shared.Models.DTOs;
using Microsoft.AspNetCore.Components.Forms;
using System.Runtime.Intrinsics.X86;

namespace Codium.Interview.EmployeeEvidenceApp.Client.Services
{
    /// <summary>
    /// Service for managing employee data on the client-side.
    /// </summary>
    public interface IEmployeeService
    {
        /// <summary>
        /// Retrieves a list of all employees with minimal information
        /// </summary>
        /// <returns>A list of EmployeeListDTO objects</returns>
        Task<List<EmployeeListDTO>> GetAllEmployees();

        /// <summary>
        /// Retrieves a specific employee by their ID.
        /// </summary>
        /// <param name="id">The ID of the employee to retrieve.</param>
        /// <returns>An EmployeeDTO object representing the employee</returns>
        Task<EmployeeDTO> GetEmployeeByIdAsync(int id);

        /// <summary>
        /// Adds a new employee.
        /// </summary>
        /// <param name="employee">The EmployeeDTO object representing the employee to add</param>
        /// <returns>An EmployeeDTO object representing the added employee</returns>
        Task<EmployeeDTO> AddEmployeeAsync(EmployeeDTO employee);

        /// <summary>
        /// Deletes an employee by their ID
        /// </summary>
        /// <param name="id">The ID of the employee to delete</param>
        /// <returns></returns>
        Task DeleteEmployeeAsync(int id);

        /// <summary>
        /// Updates an existing employee
        /// </summary>
        /// <param name="employee">The EmployeeDTO object with updated employee data</param>
        /// <returns>A EmployeeDTO object with updated employee data</returns>
        Task<EmployeeDTO> UpdateEmployeeAsync(EmployeeDTO employee);

        /// <summary>
        /// Uploads an employee data file to the server.
        /// </summary>
        /// <param name="employeesFile">The IBrowserFile representing the employee data file</param>
        /// <returns></returns>
        Task UploadEmployeesFile(IBrowserFile employeesFile);

    }
}
