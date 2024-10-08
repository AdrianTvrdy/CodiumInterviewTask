﻿using AutoMapper;
using Codium.Interview.EmployeeEvidenceApp.Server.Data;
using Codium.Interview.EmployeeEvidenceApp.Server.Repositories;
using Codium.Interview.EmployeeEvidenceApp.Shared.Models.DTOs;
using Codium.Interview.EmployeeEvidenceApp.Shared.Models.Entities;
using Codium.Interview.EmployeeEvidenceApp.Shared.Models.Exceptions;
using Codium.Interview.EmployeeEvidenceApp.Shared.Models.Other;
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

        public async Task<PositionDTO> AddPositionAsync(PositionDTO position)
        {
            if (await _positionRepository.GetPositionByNameAsync(position.PositionName) == null)
            {
                var result = await _positionRepository.AddPositionAsync(position);
                return result;
            }
            else
            {
                throw new PositionAlreadyExistsExeption();
            }
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

        public async Task<JsonUploadResult> UploadPositionsAsync(PositionFileDTO positions)
        {
            var result = new JsonUploadResult();
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
                else
                {
                    result.Skipped++;
                    result.Reasons.Add($"Position {position} upload skipped because it already exists.");
                }
            }
            return result;
        }
    }
}
