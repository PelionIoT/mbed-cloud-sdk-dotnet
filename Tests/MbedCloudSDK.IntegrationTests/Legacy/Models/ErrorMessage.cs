using System;
using MbedCloudSDK.Exceptions;

namespace MbedCloudSDK.IntegrationTests.Models
{
    public class ErrorMessage
    {
        public string Message { get; set; }
        public string Traceback { get; set; }

        public static ErrorMessage Map(Exception exception)
        {
            if (exception.InnerException != null)
            {
                if (exception.InnerException.GetType() == typeof(CloudApiException))
                {
                    var innerException = exception.InnerException as CloudApiException;
                    return new ErrorMessage { Message = $"{innerException.ErrorCode} - {exception.InnerException.Message}", Traceback = exception.InnerException.StackTrace };
                }

                return new ErrorMessage { Message = $"{exception.InnerException.Message}", Traceback = exception.InnerException.StackTrace };
            }

            return new ErrorMessage { Message = exception.Message, Traceback = exception.StackTrace };
        }
    }
}