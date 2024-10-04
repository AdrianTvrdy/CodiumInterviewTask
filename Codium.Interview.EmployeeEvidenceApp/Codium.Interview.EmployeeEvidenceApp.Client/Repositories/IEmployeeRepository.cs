using Codium.Interview.EmployeeEvidenceApp.Shared.Models.DTOs;
using Microsoft.AspNetCore.Components.Forms;
using System.Net.Http;
using System.Text.Json;

namespace Codium.Interview.EmployeeEvidenceApp.Client.Repositories
{
    /// <summary>
    /// Repository for interacting with the employee API endpoints
    /// This repository handles the HTTP communication for managing employee data
    /// </summary>
    public interface IEmployeeRepository
    {

        /// <summary>
        /// Sends an HTTP POST request to add a new employee
        /// </summary>
        /// <param name="employee">The EmployeeDTO object representing the employee to add</param>
        /// <returns>An EmployeeDTO object representing the added employee</returns>
        Task<EmployeeDTO> AddEmployeeAsync(EmployeeDTO employee);

        /// <summary>
        /// Sends an HTTP DELETE request to delete an employee by their ID
        /// </summary>
        /// <param name="id">The ID of the employee to delete</param>
        /// <returns></returns>
        Task DeleteEmployeeAsync(int id);

        /// <summary>
        /// Sends an HTTP GET request to retrieve a list of all employees
        /// </summary>
        /// <returns>A list of EmployeeListDTO objects</returns>
        Task<List<EmployeeListDTO>> GetAllEmployees();

        /// <summary>
        /// Sends an HTTP GET request to retrieve a specific employee by their ID
        /// </summary>
        /// <param name="id">The ID of the employee to retrieve</param>
        /// <returns>An EmployeeDTO object representing the employee</returns>
        Task<EmployeeDTO> GetEmployeeByIdAsync(int id);

        /// <summary>
        /// Sends an HTTP PUT request to update an existing employee
        /// </summary>
        /// <param name="employee">The EmployeeDTO object with updated employee data</param>
        /// <returns>An EmployeeDTO object representing the updated employee</returns>
        Task<EmployeeDTO> UpdateEmployeeAsync(EmployeeDTO employee);

        /// <summary>
        /// Sends an HTTP POST request to upload an employee data file
        /// </summary>
        /// <param name="employeesFile">The EmployeeFileDTO object containing the employee data</param>
        /// <returns></returns>
        Task UploadEmployeesFile(EmployeeFileDTO employeesFile);
    }
}
