using Codium.Interview.EmployeeEvidenceApp.Shared.Models.DTOs;
using Codium.Interview.EmployeeEvidenceApp.Shared.Models.Exceptions;
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

        public async Task<PositionDTO> AddPositionAsync(PositionDTO position)
        {
            var response = _httpClient.PostAsJsonAsync("/api/Position/AddPosition", position);
            if (!response.Result.IsSuccessStatusCode)
            {
                throw new HttpResponseExeption(response.Result.Content.ReadAsStringAsync().Result, response.Result.StatusCode);
            }
            var responseContent = response.Result.Content.ReadAsStringAsync().Result;
            var options = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            };

            var result = JsonSerializer.Deserialize<PositionDTO>(responseContent, options);
            return result;
        }

        public async Task<List<PositionDTO>> GetAllPositions()
        {
            var response = await _httpClient.GetAsync("/api/Position/Positions");
            if (!response.IsSuccessStatusCode)
            {
                throw new HttpResponseExeption(await response.Content.ReadAsStringAsync(), response.StatusCode);
            }
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
            if (!response.IsSuccessStatusCode)
            {
                throw new HttpResponseExeption(await response.Content.ReadAsStringAsync(), response.StatusCode);
            }
            var responseContent = await response.Content.ReadAsStringAsync();
            var options = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            };

            var result = JsonSerializer.Deserialize<PositionDTO>(responseContent, options);
            return result ?? new PositionDTO();
        }

        public async Task UploadPositionsAsync(PositionFileDTO entity)
        {
            var response = await _httpClient.PostAsJsonAsync("/api/Position/Positions/UploadFile", entity);

            if (!response.IsSuccessStatusCode)
            {
                throw new HttpResponseExeption(await response.Content.ReadAsStringAsync(), response.StatusCode);
            }
        }

    }
}
