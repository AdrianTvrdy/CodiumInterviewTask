using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Codium.Interview.EmployeeEvidenceApp.Shared.Models.Other
{
    /// <summary>
    /// Class that passes error information to the client error page
    /// </summary>
    public class ErrorInfo
    {
        public int ErrorCode { get; set; }
        public string ErrorMessage { get; set; }
    }
}
