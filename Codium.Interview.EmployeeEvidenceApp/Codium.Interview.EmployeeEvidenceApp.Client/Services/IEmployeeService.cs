using Codium.Interview.EmployeeEvidenceApp.Shared.Models.DTOs;

namespace Codium.Interview.EmployeeEvidenceApp.Client.Services
{
    public interface IEmployeeService
    {
        Task<List<EmployeeListDTO>> GetAllEmployees();
        Task<EmployeeDTO> GetEmployeeByIdAsync(int id);
        Task<EmployeeDTO> AddEmployeeAsync(EmployeeDTO entity);
    }
}
