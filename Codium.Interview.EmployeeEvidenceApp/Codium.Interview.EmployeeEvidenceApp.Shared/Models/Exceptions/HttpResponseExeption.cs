using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Codium.Interview.EmployeeEvidenceApp.Shared.Models.Exceptions
{
    public class HttpResponseExeption : Exception
    {
        public HttpStatusCode Status { get; set; } = HttpStatusCode.InternalServerError;

        public HttpResponseExeption(string message, HttpStatusCode status) : base(message)
        {
            Status = status;
        }
    }
}
