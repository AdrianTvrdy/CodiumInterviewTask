using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Codium.Interview.EmployeeEvidenceApp.Shared.Models.DTOs
{
    /// <summary>
    /// Class representing a single the JSON object in file that is sent to the client
    /// </summary>
    public class JsonFileEmployeeDTO
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Position { get; set; }
        public string BirthDate { get; set; }
        [JsonPropertyName("IpAddress")]
        public string IPaddress { get; set; }
    }
}
