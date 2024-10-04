using Codium.Interview.EmployeeEvidenceApp.Client.Repositories;
using Codium.Interview.EmployeeEvidenceApp.Shared.Models.DTOs;
using Microsoft.AspNetCore.Components.Forms;
using System.Net.Http.Json;
using System.Text.Json;

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

        public async Task<PositionDTO> GetPositionByIdAsync(int id)
        {
            return await _positionRepository.GetPositionByIdAsync(id);
        }

        public async Task UploadPositionsAsync(IBrowserFile positionsFile)
        {
            using (var stream = positionsFile.OpenReadStream())
            {
                var positions = await JsonSerializer.DeserializeAsync<PositionFileDTO>(stream);

                await _positionRepository.UploadPositionsAsync(positions);
            }

        }
    }
}
