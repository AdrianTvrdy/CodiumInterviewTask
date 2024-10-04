using Codium.Interview.EmployeeEvidenceApp.Shared.Models.DTOs;
using Microsoft.AspNetCore.Components.Forms;

namespace Codium.Interview.EmployeeEvidenceApp.Client.Services
{
    /// <summary>
    /// Service for managing position data on the client-side
    /// </summary>
    public interface IPositionService
    {
        /// <summary>
        /// Retrieves a list of all positions
        /// </summary>
        /// <returns>A list of PositionDTO objects</returns>
        Task<List<PositionDTO>> GetAllPositions();

        /// <summary>
        /// Retrieves a specific position by its ID
        /// </summary>
        /// <param name="id">The ID of the position to retrieve</param>
        /// <returns>A PositionDTO object representing the position</returns>
        Task<PositionDTO> GetPositionByIdAsync(int id);

        /// <summary>
        /// Parses a position data file and calls repository method to uplod it to the server
        /// </summary>
        /// <param name="positionsFile">The IBrowserFile representing the position data file</param>
        /// <returns></returns>
        Task UploadPositionsAsync(IBrowserFile positionsFile);
    }
}
