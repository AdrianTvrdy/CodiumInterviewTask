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

        public async Task<EmployeeDTO> AddEmployeeAsync(EmployeeDTO entity)
        {
            return await _employeeRepository.AddEmployeeAsync(entity);
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

        public Task<EmployeeDTO> UpdateEmployeeAsync(EmployeeDTO entity)
        {
            return _employeeRepository.UpdateEmployeeAsync(entity);
        }
    }

}
