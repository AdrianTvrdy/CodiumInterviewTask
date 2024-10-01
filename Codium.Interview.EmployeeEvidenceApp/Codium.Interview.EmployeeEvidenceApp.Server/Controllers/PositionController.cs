﻿using Codium.Interview.EmployeeEvidenceApp.Server.Services;
using Codium.Interview.EmployeeEvidenceApp.Shared.Models.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace Codium.Interview.EmployeeEvidenceApp.Server.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class PositionController : ControllerBase
    {
        private readonly IPositionService _positionService;

        public PositionController(IPositionService positionService)
        {
            _positionService = positionService;
        }

        [HttpGet("Positions")]
        public async Task<ActionResult<List<PositionDTO>>> GetPositions()
        {
            try
            {
                return Ok(await _positionService.GetAllPositions());
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet("Position/{id}")]
        public async Task<ActionResult<PositionDTO>> GetPositionById(int id)
        {

            try
            {
                return Ok(await _positionService.GetPositionByIdAsync(id));

            }
            catch (Exception ex)
            {

                return StatusCode(500, "Internal server error");
            }

        }

        [HttpPost("Positions/UploadFile")]
        public async Task<ActionResult> UploadPositions([FromBody] PositionFileDTO positions)
        {
            try
            {
                await _positionService.UploadPositionsAsync(positions);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error");
            }
        }


    }
}
