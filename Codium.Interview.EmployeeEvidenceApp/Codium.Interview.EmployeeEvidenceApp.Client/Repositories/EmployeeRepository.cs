﻿using Codium.Interview.EmployeeEvidenceApp.Shared.Models.DTOs;
using Codium.Interview.EmployeeEvidenceApp.Shared.Models.Exceptions;
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

        public async Task UploadEmployeesAsync(EmployeeFileDTO employee)
        {
            var response = await _httpClient.PostAsJsonAsync("/api/Employee/UploadFile", employee);

            if (!response.IsSuccessStatusCode)
            {
                throw new HttpResponseExeption(await response.Content.ReadAsStringAsync(), response.StatusCode);
            }
        }



        public async Task<EmployeeDTO> AddEmployeeAsync(EmployeeDTO employee)
        {
            var response = await _httpClient.PostAsJsonAsync("/api/Employee/AddEmployee", employee);

            if (!response.IsSuccessStatusCode)
            {
                throw new HttpResponseExeption(await response.Content.ReadAsStringAsync(), response.StatusCode); 
            }



            var responseContent = await response.Content.ReadAsStringAsync();
            var options = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            };

            var result = JsonSerializer.Deserialize<EmployeeDTO>(responseContent, options);
            return result;
        }

        public async Task DeleteEmployeeAsync(int id)
        {
            var response = await _httpClient.DeleteAsync($"/api/Employee/DeleteEmployee/{id}");
            if (!response.IsSuccessStatusCode)
            {
                throw new HttpResponseExeption(await response.Content.ReadAsStringAsync(), response.StatusCode);
            }

        }

        public async Task<List<EmployeeListDTO>> GetAllEmployees()
        {
            var response = await _httpClient.GetAsync("/api/Employee/Employees");
            if (!response.IsSuccessStatusCode)
            {
                throw new HttpResponseExeption(await response.Content.ReadAsStringAsync(), response.StatusCode);
            }
            var responseContent = await response.Content.ReadAsStringAsync();
            var options = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            };

            var result = JsonSerializer.Deserialize<List<EmployeeListDTO>>(responseContent, options);
            return result;

        }
        public async Task<EmployeeDTO> GetEmployeeByIdAsync(int id)
        {
            var response = await _httpClient.GetAsync($"/api/Employee/Employee/{id}");
            response.EnsureSuccessStatusCode();

            var responseContent = await response.Content.ReadAsStringAsync();
            var options = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            };

            var result = JsonSerializer.Deserialize<EmployeeDTO>(responseContent, options);
            return result;
        }

        public async Task<EmployeeDTO> UpdateEmployeeAsync(EmployeeDTO employee)    
        {
            var response = await _httpClient.PutAsJsonAsync("/api/Employee/UpdateEmployee", employee);
            if (!response.IsSuccessStatusCode)
            {
                throw new HttpResponseExeption(await response.Content.ReadAsStringAsync(), response.StatusCode);
            }
            var responseContent = await response.Content.ReadAsStringAsync();
            var options = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            };

            var result = JsonSerializer.Deserialize<EmployeeDTO>(responseContent, options);
            return result;


        }

        public async Task UploadEmployeesFile(EmployeeFileDTO employees)
        {

            var response = await _httpClient.PostAsJsonAsync("/api/Employee/Employees/UploadFile", employees);
            if (!response.IsSuccessStatusCode)
            {
                throw new HttpResponseExeption(await response.Content.ReadAsStringAsync(), response.StatusCode);
            }
            

        }
    }
}
