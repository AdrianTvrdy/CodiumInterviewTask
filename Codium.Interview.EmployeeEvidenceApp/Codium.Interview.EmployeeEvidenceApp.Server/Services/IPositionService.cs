using Codium.Interview.EmployeeEvidenceApp.Shared.Models.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace Codium.Interview.EmployeeEvidenceApp.Server.Services
{
    /// <summary>
    /// Interface for the Position Service
    /// </summary>
    public interface IPositionService
    {
        /// <summary>
        /// Method on the service layer to get all positions
        /// </summary>
        /// <returns>List of PositionDTO objects</returns>
        Task<List<PositionDTO>> GetAllPositions();

        /// <summary>
        /// Method on the service layer to get a position by ID
        /// </summary>
        /// <param name="id">The ID of the position</param>
        /// <returns>PositionDTO of the position with coresponding ID</returns>
        Task<PositionDTO> GetPositionByIdAsync(int id);

        /// <summary>
        /// Method on the service layer that uploads positions from a file
        /// </summary>
        /// <param name="positions">Data mapped to object PositionFileDTO from the JSON file</param>
        /// <returns></returns>
        Task UploadPositionsAsync(PositionFileDTO positions);

    }
}
