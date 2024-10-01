using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Codium.Interview.EmployeeEvidenceApp.Shared.Models.Other
{
    public class EmployeeJsonObject
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Position { get; set; }
        public string BirthDate { get; set; }
        [JsonPropertyName("IpAddress")]
        public string IPaddress { get; set; }
    }
}
