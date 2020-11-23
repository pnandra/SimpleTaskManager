using System;

namespace SimpleTaskManagerMVC.Models
{
    public class ErrorViewModel
    {
        public ErrorViewModel(Exception exception)
        {
            Exception = exception;
        }

        public ErrorViewModel (string requestId)
        {
            RequestId = requestId;
        }
        public string RequestId { get; set; }

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);

        public Exception Exception { get; private set; }
        
    }
}
