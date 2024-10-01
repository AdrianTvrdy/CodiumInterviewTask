using AutoMapper;
using Codium.Interview.EmployeeEvidenceApp.Client.Services;
using Codium.Interview.EmployeeEvidenceApp.Server.Data;
using Codium.Interview.EmployeeEvidenceApp.Server.Helpers;
using Codium.Interview.EmployeeEvidenceApp.Server.Repositories;
using Codium.Interview.EmployeeEvidenceApp.Shared.Models.DTOs;
using Codium.Interview.EmployeeEvidenceApp.Shared.Models.Entities;
using Codium.Interview.EmployeeEvidenceApp.Shared.Models.Exceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;

namespace Codium.Interview.EmployeeEvidenceApp.Server.Services
{
    /// <summary>
    /// Service for managing employees
    /// </summary>
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IPositionRepository _positionRepository;

        public EmployeeService(IEmployeeRepository employeeRepository, IPositionRepository positionRepository)
        {
            _employeeRepository = employeeRepository;
            _positionRepository = positionRepository;
        }

        public async Task<EmployeeDTO> AddEmployeeAsync(EmployeeDTO employee)
        {
            int count = _employeeRepository.GetEmployeeCountByIdCompositeKey(employee.Name, employee.Surname, employee.BirthDate).Result;

            if (count > 0)
            {
                throw new EmployeeExisitsException();
            }
            else
            {
                employee.IPCountryCode = await CountryCodeApi.GetCountryCodeFromIP(employee.IPaddress);
            }

            return await _employeeRepository.AddEmployeeAsync(employee);
        }

        public async Task UploadEmployeesAsync(EmployeeFileDTO employees)
        {
            foreach (var employee in employees.Employees)
            {
                if (await _employeeRepository.GetEmployeeCountByIdCompositeKey(employee.Name, employee.Surname, DateTime.ParseExact(employee.BirthDate, "yyyy/MM/dd", null)) == 0)
                {
                    var newEmployee = new EmployeeDTO
                    {
                        Name = employee.Name,
                        Surname = employee.Surname,
                        BirthDate = DateTime.ParseExact(employee.BirthDate, "yyyy/MM/dd", null),
                        IPaddress = employee.IPaddress
                    };    
                    
                    newEmployee.IPCountryCode = await CountryCodeApi.GetCountryCodeFromIP(newEmployee.IPaddress);

                    if (employee.Position != null)
                    {
                        var positionId = await _positionRepository.GetPositionIdByNameAsync(employee.Position);
                        if (positionId != null)
                        {
                            newEmployee.PositionID = positionId;
                        }
                    }

                    await _employeeRepository.AddEmployeeAsync(newEmployee);
                }
            }
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
            var result = await _employeeRepository.GetAllEmployees();

            if (result is null)
            {
                throw new EmployeeRepositoryException();
            }

            return result;
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
    }
}
