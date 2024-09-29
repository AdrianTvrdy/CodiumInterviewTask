using Codium.Interview.EmployeeEvidenceApp.Shared.Models.DTOs;
using System.Net.Http.Json;
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
            var response = await _httpClient.PostAsJsonAsync("/api/Employee/AddEmployee", entity);
            response.EnsureSuccessStatusCode(); // Check for HTTP errors

            var responseContent = await response.Content.ReadAsStringAsync();
            var options = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            };

            var result = JsonSerializer.Deserialize<EmployeeDTO>(responseContent, options);
            return result;
        }

        public async Task DeleteEmployeeAsync(EmployeeDTO entity)
        {
            throw new NotImplementedException();
        }

        public async Task<List<EmployeeListDTO>> GetAllEmployees()
        {
            var response = await _httpClient.GetAsync("/api/Employee/Employees");
            response.EnsureSuccessStatusCode(); // Check for HTTP errors

            var responseContent = await response.Content.ReadAsStringAsync();
            var options = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            };

            var result = JsonSerializer.Deserialize<List<EmployeeListDTO>>(responseContent, options);
            return result ?? new List<EmployeeListDTO>();

        }
        public async Task<EmployeeDTO> GetEmployeeByIdAsync(int id)
        {
            var response = await _httpClient.GetAsync($"/api/Employee/Employee/{id}");
            response.EnsureSuccessStatusCode(); // Check for HTTP errors

            var responseContent = await response.Content.ReadAsStringAsync();
            var options = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            };

            var result = JsonSerializer.Deserialize<EmployeeDTO>(responseContent, options);
            return result;
        }

        public async Task UpdateEmployeeAsync(EmployeeDTO entity)
        {
            throw new NotImplementedException();
        }
    }
}
