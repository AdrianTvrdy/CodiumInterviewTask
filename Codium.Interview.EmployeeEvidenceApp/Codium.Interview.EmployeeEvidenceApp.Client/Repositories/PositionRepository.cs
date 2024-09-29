using Codium.Interview.EmployeeEvidenceApp.Shared.Models.DTOs;
using System.Net.Http.Json;
using System.Text.Json;

namespace Codium.Interview.EmployeeEvidenceApp.Client.Repositories
{
    public class PositionRepository : IPositionRepository
    {
        private readonly HttpClient _httpClient;

        public PositionRepository(HttpClient httpClient)

        {
            _httpClient = httpClient;
        }

        public async Task<PositionDTO> AddPositionAsync(PositionDTO entity)
        {
            throw new NotImplementedException();
        }

        public async Task DeletePositionAsync(PositionDTO entity)
        {
            throw new NotImplementedException();
        }

        public async Task<List<PositionDTO>> GetAllPositions()
        {


            var response = await _httpClient.GetAsync("/api/Position/Positions");
            response.EnsureSuccessStatusCode(); // Check for HTTP errors

            var responseContent = await response.Content.ReadAsStringAsync();
            var options = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            };

            var result = JsonSerializer.Deserialize<List<PositionDTO>>(responseContent, options);
            return result ?? new List<PositionDTO>();
        }

        public async Task<PositionDTO> GetPositionByIdAsync(int id)
        {
            var response = await _httpClient.GetAsync($"/api/Position/Position/{id}");
            response.EnsureSuccessStatusCode(); // Check for HTTP errors

            var responseContent = await response.Content.ReadAsStringAsync();
            var options = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            };

            var result = JsonSerializer.Deserialize<PositionDTO>(responseContent, options);
            return result ?? new PositionDTO();
        }

        public async Task UpdatePositionAsync(PositionDTO entity)
        {
            throw new NotImplementedException();
        }
    }
}
