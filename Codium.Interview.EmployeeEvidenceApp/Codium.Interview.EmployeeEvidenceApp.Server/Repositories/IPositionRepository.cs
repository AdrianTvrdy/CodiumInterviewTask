using Codium.Interview.EmployeeEvidenceApp.Shared.Models.DTOs;
using Codium.Interview.EmployeeEvidenceApp.Shared.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace Codium.Interview.EmployeeEvidenceApp.Server.Repositories
{
    public interface IPositionRepository
    {
        Task<Position> AddPositionAsync(PositionDTO entity);
        Task DeletePositionAsync(PositionDTO entity);
        Task<List<PositionDTO>> GetAllPositions();
        Task<PositionDTO> GetPositionByIdAsync(int id);
        Task UpdatePositionAsync(PositionDTO entity);
        
    }
}
