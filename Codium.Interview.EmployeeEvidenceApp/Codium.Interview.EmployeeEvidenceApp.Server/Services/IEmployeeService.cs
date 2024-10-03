using Codium.Interview.EmployeeEvidenceApp.Shared.Models.DTOs;
using Codium.Interview.EmployeeEvidenceApp.Shared.Models.Entities;
using Codium.Interview.EmployeeEvidenceApp.Shared.Models.Other;
using Microsoft.AspNetCore.Mvc;

namespace Codium.Interview.EmployeeEvidenceApp.Server.Services
{
    /// <summary>
    /// Interface for the EmployeeService
    /// </summary>
    public interface IEmployeeService
    {
        /// <summary>
        /// Method on the service layer to get all employees
        /// </summary>
        /// <returns>List of EmployeeListDTO objects, each representing an employee with minimal external information</returns>
        Task<List<EmployeeListDTO>> GetAllEmployees();

        /// <summary>
        /// Method on the service layer to get an employee by ID
        /// </summary>
        /// <param name="id">The ID of the employee</param>
        /// <returns>EmployeeDTO of the employee with coresponding ID</returns>
        Task<EmployeeDTO> GetEmployeeByIdAsync(int id);

        /// <summary>
        /// Method on the service layer to add an employee
        /// </summary>
        /// <param name="employee">The EmployeeDTO object representing the employee to add</param>
        /// <returns>EmployeeDTO of the inserted Employee</returns>
        Task<EmployeeDTO> AddEmployeeAsync(EmployeeDTO employee);

        /// <summary>
        /// Method on the service layer to delete an employee
        /// </summary>
        /// <param name="id">The ID of the employee to delete</param>
        /// <returns></returns>
        Task DeleteEmployeeAsync(int id);

        /// <summary>
        /// Method on the service layer to update an employee
        /// </summary>
        /// <param name="employee">EmployeeDTO with updated values</param>
        /// <returns>Updated EmployeeDTO</returns>
        Task<EmployeeDTO> UpdateEmployeeAsync(EmployeeDTO employee);

        /// <summary>
        /// Method on the service layer that uploads employees from a file
        /// </summary>
        /// <param name="employees">Data mapped to object EmployeeFileDTO from the JSON file</param>
        /// <returns>Result with the number of skipped Employees and List of reasons for skips</returns>
        Task<JsonUploadResult> UploadEmployeesAsync(EmployeeFileDTO employees);

    }
}
