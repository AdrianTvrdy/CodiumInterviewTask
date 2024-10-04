using Codium.Interview.EmployeeEvidenceApp.Shared.Models.DTOs;
using Codium.Interview.EmployeeEvidenceApp.Shared.Models.Exceptions;
using System.Net.Http;

namespace Codium.Interview.EmployeeEvidenceApp.Client.Repositories
{
    /// <summary>
    /// Repository for interacting with the position API endpoints
    /// This repository handles the HTTP communication for managing position data
    /// </summary>
    public interface IPositionRepository
    {

        /// <summary>
        /// Sends an HTTP GET request to retrieve a list of all positions.
        /// </summary>
        /// <returns>A list of PositionDTO objects</returns>
        Task<List<PositionDTO>> GetAllPositions();

        /// <summary>
        /// Sends an HTTP GET request to retrieve a specific position by its ID
        /// </summary>
        /// <param name="id">The ID of the position to retrieve</param>
        /// <returns>A PositionDTO object representing the position</returns>
        Task<PositionDTO> GetPositionByIdAsync(int id);


        /// <summary>
        /// Sends an HTTP POST request to upload a position data file
        /// </summary>
        /// <param name="positionsFile">The PositionFileDTO object containing the position data</param>
        /// <returns></returns>
        Task UploadPositionsAsync(PositionFileDTO positionsFile);
    }
}
