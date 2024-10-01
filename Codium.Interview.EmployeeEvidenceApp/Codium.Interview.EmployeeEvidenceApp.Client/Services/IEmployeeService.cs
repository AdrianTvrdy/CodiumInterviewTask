using Codium.Interview.EmployeeEvidenceApp.Shared.Models.DTOs;
using Microsoft.AspNetCore.Components.Forms;

namespace Codium.Interview.EmployeeEvidenceApp.Client.Services
{
    public interface IEmployeeService
    {
        Task<List<EmployeeListDTO>> GetAllEmployees();
        Task<EmployeeDTO> GetEmployeeByIdAsync(int id);
        Task<EmployeeDTO> AddEmployeeAsync(EmployeeDTO entity);
        Task DeleteEmployeeAsync(int id);
        Task<EmployeeDTO> UpdateEmployeeAsync(EmployeeDTO entity);
        Task UploadEmployeesFile(IBrowserFile employeesFile);

    }
}
