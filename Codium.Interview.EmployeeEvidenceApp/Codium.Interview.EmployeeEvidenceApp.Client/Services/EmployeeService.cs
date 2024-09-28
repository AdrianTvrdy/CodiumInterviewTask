using Codium.Interview.EmployeeEvidenceApp.Client.Repositories;
using Codium.Interview.EmployeeEvidenceApp.Shared.Models.DTOs;
using System.Net.Http.Json;
using System.Text.Json;

namespace Codium.Interview.EmployeeEvidenceApp.Client.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeeService(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public async Task<List<EmployeeDTO>> GetAllEmployees()
        {
            return await _employeeRepository.GetAllEmployees();
        }


    }

}
