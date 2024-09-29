using AutoMapper;
using Codium.Interview.EmployeeEvidenceApp.Client.Services;
using Codium.Interview.EmployeeEvidenceApp.Server.Data;
using Codium.Interview.EmployeeEvidenceApp.Server.Repositories;
using Codium.Interview.EmployeeEvidenceApp.Shared.Models.DTOs;
using Codium.Interview.EmployeeEvidenceApp.Shared.Models.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;

namespace Codium.Interview.EmployeeEvidenceApp.Server.Services
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
            int count = _employeeRepository.GetEmployeeCountByIdCompositeKey(entity.Name, entity.Surname, entity.BirthDate).Result;

            if (count > 0)
            {
                // exemption 
                return null;    
            }
            else
            {
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri("https://api.country.is/");
                var response = await client.GetAsync(entity.IPaddress);

                if (!response.IsSuccessStatusCode)
                {
                    // exemption
                    return null;
                }

                var apiCallContent = await response.Content.ReadAsStringAsync();
                var jsonDocument = JsonDocument.Parse(apiCallContent);

                // Extract the "country" property
                string countryCode = jsonDocument.RootElement.GetProperty("country").GetString();

                entity.IPCountryCode = countryCode;
            }

            return await _employeeRepository.AddEmployeeAsync(entity);
        }

        public async Task<List<EmployeeListDTO>> GetAllEmployees()
        {
            // errors
            return await _employeeRepository.GetAllEmployees();
        }

        public async Task<EmployeeDTO> GetEmployeeByIdAsync(int id)
        {
            return await _employeeRepository.GetEmployeeByIdAsync(id);
        }
    }
}
