using AutoMapper;
using Codium.Interview.EmployeeEvidenceApp.Client.Pages;
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

        public async Task<EmployeeDTO> AddEmployeeAsync(EmployeeDTO employee)
        {
            var entity = _mapper.Map<Employee>(employee);
            var result = await _dbContext.Employees.AddAsync(entity);
            await _dbContext.SaveChangesAsync();
           
            return _mapper.Map<EmployeeDTO>(result.Entity);
        }

        public async Task DeleteEmployeeByIdAsync(int id)
        {
            var existingEntity = await _dbContext.Employees.FindAsync(id);
            _dbContext.Employees.Remove(existingEntity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<List<EmployeeListDTO>> GetAllEmployees()
        {
            var entities = await _dbContext.Employees.ToListAsync();
            return _mapper.Map<List<EmployeeListDTO>>(entities);
        }

        public async Task<EmployeeDTO> GetEmployeeByIdAsync(int id)
        {
            var entity = await _dbContext.Employees.FirstOrDefaultAsync(e => e.EployeeID == id);
            return _mapper.Map<EmployeeDTO>(entity);
        }



        public Task<int> GetEmployeeCountByIdCompositeKey(string name, string surename, DateTime birthdate)
        {
            return _dbContext.Employees.CountAsync(x =>
                x.Name == name &&
                x.Surname == surename &&
                DateTime.Compare(x.BirthDate.Date, birthdate.Date) == 0);
        }

        public async Task<EmployeeDTO> UpdateEmployeeAsync(EmployeeDTO employee)
        {
            var entity = await _dbContext.Employees.FirstOrDefaultAsync(e => e.EployeeID == employee.EployeeID);

            entity.Name = employee.Name;
            entity.Surname = employee.Surname;
            entity.BirthDate = employee.BirthDate;
            entity.IPaddress = employee.IPaddress;
            entity.IPCountryCode = employee.IPCountryCode;
            entity.PositionID = employee.PositionID;

            var result = _dbContext.Employees.Update(entity);
            await _dbContext.SaveChangesAsync();

            return _mapper.Map<EmployeeDTO>(result.Entity);
        }

    }
}
