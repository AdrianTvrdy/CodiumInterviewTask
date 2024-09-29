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


        public async Task<EmployeeDTO> AddEmployeeAsync(EmployeeDTO entity)
        {
            var employee = _mapper.Map<Employee>(entity);
            var result = await _dbContext.Employees.AddAsync(employee);
            await _dbContext.SaveChangesAsync();
            
            return _mapper.Map<EmployeeDTO>(result.Entity);
        }

        public async Task DeleteEmployeeAsync(EmployeeDTO entity)
        {
            throw new NotImplementedException();
        }

        public async Task<List<EmployeeListDTO>> GetAllEmployees()
        {
            var employees = await _dbContext.Employees.ToListAsync();
            return _mapper.Map<List<EmployeeListDTO>>(employees);
        }

        public async Task<EmployeeDTO> GetEmployeeByIdAsync(int id)
        {
            var employee = await _dbContext.Employees.FirstOrDefaultAsync(e => e.EployeeID == id);
            return _mapper.Map<EmployeeDTO>(employee);
        }

        public Task<int> GetEmployeeCountByIdCompositeKey(string name, string surename, DateTime birthdate)
        {
            return _dbContext.Employees.CountAsync(x =>
                x.Name == name &&
                x.Surname == surename &&
                DateTime.Compare(x.BirthDate, birthdate) == 0);
            // case? 
            // diacritics?
        }

        public async Task UpdateEmployeeAsync(EmployeeDTO entity)
        {
            throw new NotImplementedException();
        }

    }
}
