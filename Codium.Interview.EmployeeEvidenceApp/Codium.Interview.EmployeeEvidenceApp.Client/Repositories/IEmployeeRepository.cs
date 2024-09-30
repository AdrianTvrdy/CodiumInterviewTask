using Codium.Interview.EmployeeEvidenceApp.Shared.Models.DTOs;
using System.Net.Http;
using System.Text.Json;

namespace Codium.Interview.EmployeeEvidenceApp.Client.Repositories
{
    public interface IEmployeeRepository
    {

        Task<EmployeeDTO> AddEmployeeAsync(EmployeeDTO entity);
        Task DeleteEmployeeAsync(int id);
        Task<List<EmployeeListDTO>> GetAllEmployees();
        Task<EmployeeDTO> GetEmployeeByIdAsync(int id);
        Task<EmployeeDTO> UpdateEmployeeAsync(EmployeeDTO entity);
        
    }
}
