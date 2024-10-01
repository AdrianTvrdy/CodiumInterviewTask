using Codium.Interview.EmployeeEvidenceApp.Shared.Models.DTOs;
using Codium.Interview.EmployeeEvidenceApp.Shared.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace Codium.Interview.EmployeeEvidenceApp.Server.Repositories
{
    public interface IPositionRepository
    {
        Task<PositionDTO> AddPositionAsync(PositionDTO entity);
        Task DeletePositionAsync(PositionDTO entity);
        Task<List<PositionDTO>> GetAllPositions();
        Task<PositionDTO> GetPositionByIdAsync(int id);
        Task<PositionDTO> GetPositionByNameAsync(string name);
        Task<int?> GetPositionIdByNameAsync(string name);
        Task<PositionDTO> UpdatePositionAsync(PositionDTO entity);
        
    }
}
