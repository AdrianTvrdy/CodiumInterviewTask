using Codium.Interview.EmployeeEvidenceApp.Shared.Models.DTOs;
using Codium.Interview.EmployeeEvidenceApp.Shared.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace Codium.Interview.EmployeeEvidenceApp.Server.Repositories
{
    public interface IPositionRepository
    {
        /// <summary>
        /// Adds a position to the database
        /// </summary>
        /// <param name="position">PositionDTO representing a new position in the company</param>
        /// <returns>Added PositionDTO mapped from the new Position entity in the database</returns>
        Task<PositionDTO> AddPositionAsync(PositionDTO position);

        /// <summary>
        /// Deletes a position from the database
        /// </summary>
        /// <param name="position">PositionDTO object representing the position to delete</param>
        /// <returns></returns>
        Task DeletePositionAsync(PositionDTO position);

        /// <summary>
        /// Gets all positions from the database
        /// </summary>
        /// <returns>List of PositionDTO objects, each representing a position</returns>
        Task<List<PositionDTO>> GetAllPositions();

        /// <summary>
        /// Gets a position by ID from the database
        /// </summary>
        /// <param name="id">The ID of the position</param>
        /// <returns></returns>
        Task<PositionDTO> GetPositionByIdAsync(int id);

        /// <summary>
        /// Gets a position by name from the database
        /// </summary>
        /// <param name="name"></param>
        /// <returns>PositionDTO object of the position with coresponding ID</returns>
        Task<PositionDTO> GetPositionByNameAsync(string name);

        /// <summary>
        /// Gets the ID of a position with matching name from the database
        /// </summary>
        /// <param name="name"></param>
        /// <returns>The ID of the position if found; otherwise, null</returns>
        Task<int?> GetPositionIdByNameAsync(string name);

        /// <summary>
        /// Updates a position in the database
        /// </summary>
        /// <param name="position">PositionDTO with updated values</param>
        /// <returns>Updated entity from database mapped to PositionDTO</returns>
        Task<PositionDTO> UpdatePositionAsync(PositionDTO position);
        
    }
}
