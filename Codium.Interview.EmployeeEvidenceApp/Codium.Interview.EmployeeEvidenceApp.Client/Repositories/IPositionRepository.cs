using Codium.Interview.EmployeeEvidenceApp.Shared.Models.DTOs;
using Codium.Interview.EmployeeEvidenceApp.Shared.Models.Exceptions;
using System.Net.Http;

namespace Codium.Interview.EmployeeEvidenceApp.Client.Repositories
{
    public interface IPositionRepository
    {

        Task<PositionDTO> AddPositionAsync(PositionDTO entity);
        Task DeletePositionAsync(PositionDTO entity);
        Task<List<PositionDTO>> GetAllPositions();
        Task<PositionDTO> GetPositionByIdAsync(int id);
        Task UpdatePositionAsync(PositionDTO entity);

        Task UploadPositionsAsync(PositionFileDTO entity);

    }
}
