using Codium.Interview.EmployeeEvidenceApp.Client.Repositories;
using Codium.Interview.EmployeeEvidenceApp.Shared.Models.DTOs;
using Microsoft.AspNetCore.Components.Forms;
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

        public async Task<EmployeeDTO> AddEmployeeAsync(EmployeeDTO employee)
        {
            return await _employeeRepository.AddEmployeeAsync(employee);
        }

        public async Task DeleteEmployeeAsync(int id)
        {
            await _employeeRepository.DeleteEmployeeAsync(id);
        }

        public async Task<List<EmployeeListDTO>> GetAllEmployees()
        {
            return await _employeeRepository.GetAllEmployees();
        }

        public async Task<EmployeeDTO> GetEmployeeByIdAsync(int id)
        {
            return await _employeeRepository.GetEmployeeByIdAsync(id);
        }

        public Task<EmployeeDTO> UpdateEmployeeAsync(EmployeeDTO employee)
        {
            return _employeeRepository.UpdateEmployeeAsync(employee);
        }

        public async Task UploadEmployeesFile(IBrowserFile employeesFile)
        {
            using (var stream = employeesFile.OpenReadStream())
            {
                var employees = await JsonSerializer.DeserializeAsync<EmployeeFileDTO>(stream);
            
                await _employeeRepository.UploadEmployeesFile(employees);

            }
        }
    }

}
