using Codium.Interview.EmployeeEvidenceApp.Server.Services;
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
            // errors
            return Ok(await _positionService.GetAllPositions());
        }

        [HttpGet("Position/{id}")]
        public async Task<ActionResult<PositionDTO>> GetPositionById(int id)
        {
            return Ok(await _positionService.GetPositionByIdAsync(id));
        }


    }
}
