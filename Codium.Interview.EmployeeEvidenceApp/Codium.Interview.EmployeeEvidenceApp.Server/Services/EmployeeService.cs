using AutoMapper;
using Codium.Interview.EmployeeEvidenceApp.Client.Services;
using Codium.Interview.EmployeeEvidenceApp.Server.Data;
using Codium.Interview.EmployeeEvidenceApp.Server.Helpers;
using Codium.Interview.EmployeeEvidenceApp.Server.Repositories;
using Codium.Interview.EmployeeEvidenceApp.Shared.Models.DTOs;
using Codium.Interview.EmployeeEvidenceApp.Shared.Models.Entities;
using Codium.Interview.EmployeeEvidenceApp.Shared.Models.Exceptions;
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
                throw new EmployeeExisitsException();
            }
            else
            {
                entity.IPCountryCode = await CountryCodeApi.GetCountryCodeFromIP(entity.IPaddress);
            }

            return await _employeeRepository.AddEmployeeAsync(entity);
        }

        public async Task DeleteEmployeeAsync(int id)
        {
            EmployeeDTO employee = await _employeeRepository.GetEmployeeByIdAsync(id);

            if (employee == null)
            {
                throw new EmployeeNotFoundException();
            }

            await _employeeRepository.DeleteEmployeeByIdAsync(id);

        }

        public async Task<List<EmployeeListDTO>> GetAllEmployees()
        {
            // errors
            return await _employeeRepository.GetAllEmployees();
        }

        public async Task<EmployeeDTO> GetEmployeeByIdAsync(int id)
        {
            EmployeeDTO employee = await _employeeRepository.GetEmployeeByIdAsync(id);

            if (employee == null)
            {
                throw new EmployeeNotFoundException();
            }

            return employee;
        }

        public async Task<EmployeeDTO> UpdateEmployeeAsync(EmployeeDTO entity)
        {
            try
            {
                var entityCheck = await _employeeRepository.GetEmployeeByIdAsync(entity.EployeeID);

                if (entityCheck == null)
                {
                    throw new EmployeeNotFoundException();
                }


                if (entity.IPaddress != entityCheck.IPaddress)
                {
                    entity.IPCountryCode = await CountryCodeApi.GetCountryCodeFromIP(entity.IPaddress);
                }


                return await _employeeRepository.UpdateEmployeeAsync(entity);

            }
            catch (Exception)
            {

                throw;
            }


        }
    }
}
