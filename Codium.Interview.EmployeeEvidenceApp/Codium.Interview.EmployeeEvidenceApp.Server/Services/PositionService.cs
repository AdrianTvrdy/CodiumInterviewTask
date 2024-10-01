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
    public class PositionService : IPositionService
    {
        private readonly IPositionRepository _positionRepository;

        public PositionService(IPositionRepository employeeRepository)
        {
            _positionRepository = employeeRepository;
        }

        public async Task<List<PositionDTO>> GetAllPositions()
        {
            var res = await _positionRepository.GetAllPositions();

            if (res is null)
            {
                throw new Exception();
            }

            return res;                
        }

        public async Task<PositionDTO> GetPositionByIdAsync(int id)
        {

            var res = await _positionRepository.GetPositionByIdAsync(id);

            if (res is null)
            {
                throw new PositionNotFoundExeption();
            }

            return res;
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
