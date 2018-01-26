using System;

namespace MbedCloudSDK.IntegrationTests.Models
{
    public class ErrorMessage
    {
        public string Message { get; set; }
        public string Traceback { get; set; }

        public static ErrorMessage Map(Exception exception)
        {
            return new ErrorMessage { Message = exception.Message, Traceback = exception.StackTrace };
        }
    }
}