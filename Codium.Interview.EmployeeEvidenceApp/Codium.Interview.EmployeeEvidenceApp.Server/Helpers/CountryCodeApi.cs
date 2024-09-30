using Codium.Interview.EmployeeEvidenceApp.Shared.Models.Exceptions;
using System.Text.Json;

namespace Codium.Interview.EmployeeEvidenceApp.Server.Helpers
{
    public static class CountryCodeApi
    {
        public static async Task<string> GetCountryCodeFromIP(string ip)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://api.country.is/");
            var response = await client.GetAsync(ip);

            if (!response.IsSuccessStatusCode)
            {
                throw new ExternalAPINotWorkingException();
            }

            var apiCallContent = await response.Content.ReadAsStringAsync();
            var jsonDocument = JsonDocument.Parse(apiCallContent);

            // Extract the "country" property
            string countryCode = jsonDocument.RootElement.GetProperty("country").GetString();

            return countryCode;
        }
    }
}
