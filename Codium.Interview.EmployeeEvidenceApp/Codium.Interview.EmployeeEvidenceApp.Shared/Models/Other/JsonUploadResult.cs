using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Codium.Interview.EmployeeEvidenceApp.Shared.Models.Other
{
    /// <summary>
    /// Class representing the result of the JSON upload
    /// </summary>
    public class JsonUploadResult
    {
        public int Skipped { get; set; }
        public List<string> Reasons { get; set; } = new List<string>();
    }
}
