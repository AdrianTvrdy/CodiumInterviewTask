using AutoMapper;
using Codium.Interview.EmployeeEvidenceApp.Server.Data;
using Codium.Interview.EmployeeEvidenceApp.Shared.Models.DTOs;
using Codium.Interview.EmployeeEvidenceApp.Shared.Models.Entities;
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

        public async Task<Position> AddPositionAsync(PositionDTO entity)
        {
            throw new NotImplementedException();
        }

        public async Task DeletePositionAsync(PositionDTO entity)
        {
            throw new NotImplementedException();
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

        public async Task UpdatePositionAsync(PositionDTO entity)
        {
            throw new NotImplementedException();
        }
    }
}
