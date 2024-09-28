using Codium.Interview.EmployeeEvidenceApp.Shared.Models.DTOs;
using Codium.Interview.EmployeeEvidenceApp.Shared.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace Codium.Interview.EmployeeEvidenceApp.Server.Repositories
{
    public interface IEmployeeRepository
    {
        Task<Employee> AddEmployeeAsync(EmployeeDTO entity);
        Task DeleteEmployeeAsync(EmployeeDTO entity);
        Task<List<EmployeeDTO>> GetAllEmployees();
        Task<EmployeeDTO> GetEmployeeByIdAsync(int id);
        Task UpdateEmployeeAsync(EmployeeDTO entity);
    }
}
