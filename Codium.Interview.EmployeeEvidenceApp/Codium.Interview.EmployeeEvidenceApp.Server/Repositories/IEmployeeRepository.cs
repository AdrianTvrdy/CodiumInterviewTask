using Codium.Interview.EmployeeEvidenceApp.Shared.Models.DTOs;
using Codium.Interview.EmployeeEvidenceApp.Shared.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace Codium.Interview.EmployeeEvidenceApp.Server.Repositories
{
    public interface IEmployeeRepository
    {
        /// <summary>
        /// Method to add an employee to the database asynchronously
        /// </summary>
        /// <param name="employee">The EmployeeDTO object representing the employee to add</param>
        /// <returns>EmployeeDTO object of the inserted Employee</returns>
        Task<EmployeeDTO> AddEmployeeAsync(EmployeeDTO employee);

        /// <summary>
        /// Method to delete an employee from the database asynchronously
        /// </summary>
        /// <param name="id">The ID of the employee to delete</param>
        /// <returns></returns>
        Task DeleteEmployeeByIdAsync(int id);

        /// <summary>
        /// Method to get all employees from the database asynchronously
        /// </summary>
        /// <returns>List of EmployeeListDTO objects, each representing an employee with minimal external information</returns>
        Task<List<EmployeeListDTO>> GetAllEmployees();

        /// <summary>
        /// Method to get an employee by ID from the database asynchronously
        /// </summary>
        /// <param name="id">The ID of the employee</param>
        /// <returns>EmployeeDTO object of the employee with coresponding ID</returns>
        Task<EmployeeDTO> GetEmployeeByIdAsync(int id);

        /// <summary>
        /// Method to update an employee in the database asynchronously
        /// </summary>
        /// <param name="employee">EmployeeDTO with updated values</param>
        /// <returns>Updated entity from database mapped to EmployeeDTO</returns>
        Task<EmployeeDTO> UpdateEmployeeAsync(EmployeeDTO employee);

        /// <summary>
        /// Method to get the count of employees with the same name, surname and birthdate
        /// </summary>
        /// <param name="name">The name of the employee</param>
        /// <param name="surename">The surename of the employee</param>
        /// <param name="birthdate">The birthdate of the employee</param>
        /// <returns>The number of employees matching the provided name, surname, and birthdate</returns>
        Task<int> GetEmployeeCountByIdCompositeKey(string name, string surename, DateTime birthdate);
    }
}
