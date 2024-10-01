using AutoMapper;
using Codium.Interview.EmployeeEvidenceApp.Server.Data;
using Codium.Interview.EmployeeEvidenceApp.Shared.Models.DTOs;
using Codium.Interview.EmployeeEvidenceApp.Shared.Models.Entities;
using Codium.Interview.EmployeeEvidenceApp.Shared.Models.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace Codium.Interview.EmployeeEvidenceApp.Server.Repositories
{
    public class PositionRepository : IPositionRepository
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IMapper _mapper;

        public PositionRepository(ApplicationDbContext context, IMapper mapper)
        {
            this._dbContext = context;
            this._mapper = mapper;
        }

        public async Task<PositionDTO> AddPositionAsync(PositionDTO position)
        {
            var entity = _mapper.Map<Position>(position);
            var result = await _dbContext.Positions.AddAsync(entity);
            await _dbContext.SaveChangesAsync();

            return _mapper.Map<PositionDTO>(result.Entity);

        }

        public async Task DeletePositionAsync(PositionDTO position)
        {
            var existingEntity = await _dbContext.Positions.FindAsync(position.PositionID);

            _dbContext.Positions.Remove(existingEntity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<List<PositionDTO>> GetAllPositions()
        {
            var entities = await _dbContext.Positions.ToListAsync();
            return _mapper.Map<List<PositionDTO>>(entities);
        }

        public async Task<PositionDTO> GetPositionByIdAsync(int id)
        {
            var entity = await _dbContext.Positions.FirstOrDefaultAsync(e => e.PositionID == id);
            return _mapper.Map<PositionDTO>(entity);
        }

        public async Task<PositionDTO> GetPositionByNameAsync(string name)
        {
            var entity = await _dbContext.Positions.FirstOrDefaultAsync(e => e.PositionName == name);
            return _mapper.Map<PositionDTO>(entity);
        }

        public async Task<int?> GetPositionIdByNameAsync(string name)
        {
            var entity = await _dbContext.Positions.FirstOrDefaultAsync(e => e.PositionName == name);
            return entity is null ? null : entity.PositionID;
        }


        public async Task<PositionDTO> UpdatePositionAsync(PositionDTO position)
        {
            var entity = await _dbContext.Positions.FirstOrDefaultAsync(e => e.PositionID == position.PositionID);

            entity.PositionName = position.PositionName;

            var result = _dbContext.Positions.Update(entity);
            await _dbContext.SaveChangesAsync();
            return _mapper.Map<PositionDTO>(result.Entity);
        }

    }
}
