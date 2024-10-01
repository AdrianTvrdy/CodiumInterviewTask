using Codium.Interview.EmployeeEvidenceApp.Shared.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Codium.Interview.EmployeeEvidenceApp.Shared.Models.DTOs
{
    public class PositionFileDTO
    {
        [JsonPropertyName("positions")]
        public List<string> Positions { get; set; }
    }
}
