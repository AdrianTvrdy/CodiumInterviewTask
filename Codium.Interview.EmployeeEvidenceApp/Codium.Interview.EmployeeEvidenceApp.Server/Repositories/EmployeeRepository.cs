using AutoMapper;
using Codium.Interview.EmployeeEvidenceApp.Server.Data;
using Codium.Interview.EmployeeEvidenceApp.Shared.Models.DTOs;
using Codium.Interview.EmployeeEvidenceApp.Shared.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace Codium.Interview.EmployeeEvidenceApp.Server.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IMapper _mapper;

        public EmployeeRepository(ApplicationDbContext context, IMapper mapper)
        {
            this._dbContext = context;
            this._mapper = mapper;
        }


        public async Task<Employee> AddEmployeeAsync(EmployeeDTO entity)
        {
            throw new NotImplementedException();
        }

        public async Task DeleteEmployeeAsync(EmployeeDTO entity)
        {
            throw new NotImplementedException();
        }

        public async Task<List<EmployeeDTO>> GetAllEmployees()
        {
            var employees = await _dbContext.Employees.Include(e => e.Position).ToListAsync();
            return _mapper.Map<List<EmployeeDTO>>(employees);
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
