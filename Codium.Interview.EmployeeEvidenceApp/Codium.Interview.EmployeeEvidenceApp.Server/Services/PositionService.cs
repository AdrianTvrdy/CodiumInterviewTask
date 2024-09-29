using AutoMapper;
using Codium.Interview.EmployeeEvidenceApp.Server.Data;
using Codium.Interview.EmployeeEvidenceApp.Server.Repositories;
using Codium.Interview.EmployeeEvidenceApp.Shared.Models.DTOs;
using Codium.Interview.EmployeeEvidenceApp.Shared.Models.Entities;
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
            // errors
            return await _positionRepository.GetAllPositions();
        }

        public async Task<PositionDTO> GetPositionByIdAsync(int id)
        {
            return await _positionRepository.GetPositionByIdAsync(id);
        }
    }
}
