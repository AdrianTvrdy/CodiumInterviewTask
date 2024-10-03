using Codium.Interview.EmployeeEvidenceApp.Shared.Models.Other;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Codium.Interview.EmployeeEvidenceApp.Shared.Models.DTOs
{
    /// <summary>
    /// Data transfer object for the JSON file with employees
    /// </summary>
    public class EmployeeFileDTO
    {
        [JsonPropertyName("employees")]
        public List<JsonFileEmployeeDTO> Employees { get; set; }
    }
}
