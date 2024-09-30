﻿using Codium.Interview.EmployeeEvidenceApp.Shared.Models.DTOs;
using Codium.Interview.EmployeeEvidenceApp.Shared.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace Codium.Interview.EmployeeEvidenceApp.Server.Repositories
{
    public interface IEmployeeRepository
    {
        Task<EmployeeDTO> AddEmployeeAsync(EmployeeDTO entity);
        Task DeleteEmployeeByIdAsync(int id);
        //Task<List<EmployeeDTO>> GetAllEmployees();
        Task<List<EmployeeListDTO>> GetAllEmployees();
        Task<EmployeeDTO> GetEmployeeByIdAsync(int id);
        Task<EmployeeDTO> UpdateEmployeeAsync(EmployeeDTO entity);
        Task<int> GetEmployeeCountByIdCompositeKey(string name, string surename, DateTime birthdate);
    }
}
