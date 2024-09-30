using Codium.Interview.EmployeeEvidenceApp.Shared.Models.Other;

namespace Codium.Interview.EmployeeEvidenceApp.Client.Services
{

    public class ErrorService
    {
        public event Action<ErrorInfo> OnError;
        public ErrorInfo LastError { get; private set; } // Store the last error

        public void ReportError(int errorCode, string errorMessage)
        {
            LastError = new ErrorInfo { ErrorCode = errorCode, ErrorMessage = errorMessage };
            OnError?.Invoke(LastError);
        }
    }
    
}
