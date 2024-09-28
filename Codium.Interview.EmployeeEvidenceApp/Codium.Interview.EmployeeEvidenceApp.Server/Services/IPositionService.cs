using Codium.Interview.EmployeeEvidenceApp.Shared.Models.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace Codium.Interview.EmployeeEvidenceApp.Server.Services
{
    public interface IPositionService
    {
        Task<List<PositionDTO>> GetAllPositions();
    }
}
