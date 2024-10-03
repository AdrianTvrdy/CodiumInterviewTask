using Codium.Interview.EmployeeEvidenceApp.Server.Services;
using Codium.Interview.EmployeeEvidenceApp.Shared.Models.DTOs;
using Codium.Interview.EmployeeEvidenceApp.Shared.Models.Exceptions;
using Microsoft.AspNetCore.Mvc;

namespace Codium.Interview.EmployeeEvidenceApp.Server.Controllers
{
    /// <summary>
    /// A controller for the Position entity
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class PositionController : ControllerBase
    {
        private readonly IPositionService _positionService;
        private readonly ILogger<PositionController> _logger;

        public PositionController(IPositionService positionService, ILogger<PositionController> logger)
        {
            _positionService = positionService;
            _logger = logger;
        }

        [HttpGet("Positions")]
        public async Task<ActionResult<List<PositionDTO>>> GetPositions()
        {
            using var logContext = _logger.BeginScope("User GetPositions Request");
            try
            {
                var result = await _positionService.GetAllPositions();
                _logger.LogInformation("Positions retrieved successfully.");
                return Ok(result);
            }
            catch(PositionRepositoryExeption ex)
            {
                _logger.LogError(ex, "An error occurred while retrieving positions.");
                return StatusCode(500, "Internal server error");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An unexpected error happened while retrieving all positions.");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet("Position/{id}")]
        public async Task<ActionResult<PositionDTO>> GetPositionById(int id)
        {
            using var logContext = _logger.BeginScope("User GetPositionById Request: {PositionId}", id);
            try
            {
                var result = await _positionService.GetPositionByIdAsync(id);
                _logger.LogInformation("Position retrieved successfully.");
                return Ok(result);

            }
            catch (PositionNotFoundExeption ex)
            {
                _logger.LogWarning(ex, "Position not found.");
                return NotFound($"A position with ID {id} does not exist");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An unexpected error occurred while retrieving position.");
                return StatusCode(500, "Internal server error");
            }

        }

        [HttpPost("Positions/UploadFile")]
        public async Task<ActionResult> UploadPositions([FromBody] PositionFileDTO positions)
        {
            try
            {
                var result = await _positionService.UploadPositionsAsync(positions);

                if (result.Skipped > 0)
                {
                    foreach (var reason in result.Reasons)
                    {
                        _logger.LogWarning(reason);
                    }
                }
                else
                {
                    _logger.LogInformation("Positions uploaded successfully.");
                }

                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while uploading positions.");
                return StatusCode(500, "Internal server error");
            }
        }


    }
}
