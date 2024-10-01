using AutoMapper;
using Codium.Interview.EmployeeEvidenceApp.Server.Data;
using Codium.Interview.EmployeeEvidenceApp.Server.Repositories;
using Codium.Interview.EmployeeEvidenceApp.Shared.Models.DTOs;
using Codium.Interview.EmployeeEvidenceApp.Shared.Models.Entities;
using Codium.Interview.EmployeeEvidenceApp.Shared.Models.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Runtime.CompilerServices;

namespace Codium.Interview.EmployeeEvidenceApp.Server.Services
{
    /// <summary>
    /// Service for managing positions
    /// </summary>
    public class PositionService : IPositionService
    {
        private readonly IPositionRepository _positionRepository;

        public PositionService(IPositionRepository employeeRepository)
        {
            _positionRepository = employeeRepository;
        }

        public async Task<List<PositionDTO>> GetAllPositions()
        {
            var positions = await _positionRepository.GetAllPositions();

            if (positions is null)
            {
                throw new PositionRepositoryExeption();
            }

            return positions;                
        }

        public async Task<PositionDTO> GetPositionByIdAsync(int id)
        {

            var position = await _positionRepository.GetPositionByIdAsync(id);

            if (position is null)
            {
                throw new PositionNotFoundExeption();
            }

            return position;
        }

        public async Task UploadPositionsAsync(PositionFileDTO positions)
        {
            foreach (var position in positions.Positions)
            {
                if (await _positionRepository.GetPositionByNameAsync(position) == null)
                {
                    var newPosition = new PositionDTO
                    {
                        PositionName = position
                    };
                    await _positionRepository.AddPositionAsync(newPosition);
                }
            }
        }
    }
}
