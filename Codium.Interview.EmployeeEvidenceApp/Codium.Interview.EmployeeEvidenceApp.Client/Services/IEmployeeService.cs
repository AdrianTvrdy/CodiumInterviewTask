using Codium.Interview.EmployeeEvidenceApp.Shared.Models.DTOs;

namespace Codium.Interview.EmployeeEvidenceApp.Client.Services
{
    public interface IEmployeeService
    {
        Task<List<EmployeeDTO>> GetAllEmployees();

    }
}
