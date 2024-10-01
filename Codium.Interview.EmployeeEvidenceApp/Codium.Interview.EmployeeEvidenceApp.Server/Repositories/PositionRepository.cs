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

        public async Task<PositionDTO> AddPositionAsync(PositionDTO entity)
        {
            var position = _mapper.Map<Position>(entity);
            var result = await _dbContext.Positions.AddAsync(position);
            await _dbContext.SaveChangesAsync();

            return _mapper.Map<PositionDTO>(result.Entity);

        }

        public async Task DeletePositionAsync(PositionDTO entity)
        {
            var existingPosition = await _dbContext.Positions.FindAsync(entity.PositionID);

            _dbContext.Positions.Remove(existingPosition);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<List<PositionDTO>> GetAllPositions()
        {
            var positions = await _dbContext.Positions.ToListAsync();
            return _mapper.Map<List<PositionDTO>>(positions);
        }

        public async Task<PositionDTO> GetPositionByIdAsync(int id)
        {
            var position = await _dbContext.Positions.FirstOrDefaultAsync(e => e.PositionID == id);
            return _mapper.Map<PositionDTO>(position);
        }

        public async Task<PositionDTO> GetPositionByNameAsync(string name)
        {
            var position = await _dbContext.Positions.FirstOrDefaultAsync(e => e.PositionName == name);
            return _mapper.Map<PositionDTO>(position);
        }

        public async Task<int?> GetPositionIdByNameAsync(string name)
        {
            var position = await _dbContext.Positions.FirstOrDefaultAsync(e => e.PositionName == name);
            return position is null ? null : position.PositionID;
        }


        public async Task<PositionDTO> UpdatePositionAsync(PositionDTO entity)
        {
            var position = await _dbContext.Positions.FirstOrDefaultAsync(e => e.PositionID == entity.PositionID);

            position.PositionName = entity.PositionName;

            var result = _dbContext.Positions.Update(position);
            await _dbContext.SaveChangesAsync();
            return _mapper.Map<PositionDTO>(result.Entity);
        }

    }
}
