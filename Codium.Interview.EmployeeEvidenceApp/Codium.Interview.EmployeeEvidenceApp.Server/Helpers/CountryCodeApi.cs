using Codium.Interview.EmployeeEvidenceApp.Shared.Models.Exceptions;
using System.Net;
using System.Text.Json;

namespace Codium.Interview.EmployeeEvidenceApp.Server.Helpers
{
    /// <summary>
    /// Helper static class to get the country code from an IP address
    /// </summary>
    public static class CountryCodeAPI
    {
        /// <summary>
        /// Static method to get the country code from an IP address from the external API
        /// </summary>
        /// <param name="ip">The string with IP address of the employee</param>
        /// <returns>String with the country code</returns>
        /// <exception cref="ExternalAPINotWorkingException"></exception>
        public static async Task<string> GetCountryCodeFromIP(string ip)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://api.country.is/");
            var response = await client.GetAsync(ip);

            if (!response.IsSuccessStatusCode)
            {
                if (response.StatusCode == HttpStatusCode.NotFound)
                {
                    // wrong ip
                    throw new IPLocationNotFoundExeption();
                }
                else
                {
                    // external api not working
                    throw new ExternalAPINotWorkingException();
                }

            }

            var apiCallContent = await response.Content.ReadAsStringAsync();
            var jsonDocument = JsonDocument.Parse(apiCallContent);

            string countryCode = jsonDocument.RootElement.GetProperty("country").GetString()!;

            return countryCode;
        }
    }
}
