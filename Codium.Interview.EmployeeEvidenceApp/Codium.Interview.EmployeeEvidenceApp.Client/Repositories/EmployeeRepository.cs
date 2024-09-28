using Codium.Interview.EmployeeEvidenceApp.Shared.Models.DTOs;
using System.Text.Json;

namespace Codium.Interview.EmployeeEvidenceApp.Client.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly HttpClient _httpClient;

        public EmployeeRepository(HttpClient httpClient)

        {
            _httpClient = httpClient;
        }

        public async Task<EmployeeDTO> AddEmployeeAsync(EmployeeDTO entity)
        {
            throw new NotImplementedException();
        }

        public async Task DeleteEmployeeAsync(EmployeeDTO entity)
        {
            throw new NotImplementedException();
        }

        public async Task<List<EmployeeDTO>> GetAllEmployees()
        {
            var response = await _httpClient.GetAsync("/api/Employee/Employees");
            response.EnsureSuccessStatusCode(); // Check for HTTP errors

            var responseContent = await response.Content.ReadAsStringAsync();
            var options = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            };

            var result = JsonSerializer.Deserialize<List<EmployeeDTO>>(responseContent, options);
            return result ?? new List<EmployeeDTO>();

        }
        public async Task<EmployeeDTO> GetEmployeeByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task UpdateEmployeeAsync(EmployeeDTO entity)
        {
            throw new NotImplementedException();
        }
    }
}
