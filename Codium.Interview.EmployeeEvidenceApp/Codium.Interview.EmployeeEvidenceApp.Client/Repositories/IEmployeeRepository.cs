using Codium.Interview.EmployeeEvidenceApp.Shared.Models.DTOs;
using System.Net.Http;
using System.Text.Json;

namespace Codium.Interview.EmployeeEvidenceApp.Client.Repositories
{
    public interface IEmployeeRepository
    {

        Task<EmployeeDTO> AddEmployeeAsync(EmployeeDTO entity);
        Task DeleteEmployeeAsync(EmployeeDTO entity);
        Task<List<EmployeeDTO>> GetAllEmployees();
        Task<EmployeeDTO> GetEmployeeByIdAsync(int id);
        Task UpdateEmployeeAsync(EmployeeDTO entity);
        
    }
}
