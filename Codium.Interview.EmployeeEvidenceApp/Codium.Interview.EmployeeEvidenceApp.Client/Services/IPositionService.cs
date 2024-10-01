using Codium.Interview.EmployeeEvidenceApp.Shared.Models.DTOs;
using Microsoft.AspNetCore.Components.Forms;

namespace Codium.Interview.EmployeeEvidenceApp.Client.Services
{
    public interface IPositionService
    {
        Task<List<PositionDTO>> GetAllPositions();
        Task<PositionDTO> GetPositionByIdAsync(int id);
        Task UploadPositionsAsync(IBrowserFile positionsFile);
    }
}
