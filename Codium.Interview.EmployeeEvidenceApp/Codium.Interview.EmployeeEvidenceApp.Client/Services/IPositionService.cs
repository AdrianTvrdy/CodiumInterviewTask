using Codium.Interview.EmployeeEvidenceApp.Shared.Models.DTOs;

namespace Codium.Interview.EmployeeEvidenceApp.Client.Services
{
    public interface IPositionService
    {
        Task<List<PositionDTO>> GetAllPositions();

    }
}
