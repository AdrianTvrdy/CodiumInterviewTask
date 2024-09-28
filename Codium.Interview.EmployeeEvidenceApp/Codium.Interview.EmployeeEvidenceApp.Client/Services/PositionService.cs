using Codium.Interview.EmployeeEvidenceApp.Client.Repositories;
using Codium.Interview.EmployeeEvidenceApp.Shared.Models.DTOs;
using System.Net.Http.Json;

namespace Codium.Interview.EmployeeEvidenceApp.Client.Services
{
    public class PositionService : IPositionService
    {
        public readonly IPositionRepository _positionRepository;

        public PositionService(IPositionRepository positionRepository)
        {
            _positionRepository = positionRepository;
        }
        public async Task<List<PositionDTO>> GetAllPositions()
        {
            return await _positionRepository.GetAllPositions();
        }
        
    }
}
