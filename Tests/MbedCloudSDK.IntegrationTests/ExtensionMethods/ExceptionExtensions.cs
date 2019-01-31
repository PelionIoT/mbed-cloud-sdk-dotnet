using System;
using MbedCloudSDK.Exceptions;
using MbedCloudSDK.IntegrationTests.Exceptions;
using MbedCloudSDK.IntegrationTests.Models.Responses;

namespace MbedCloudSDK.IntegrationTests.ExtensionMethods
{
    public static class ExceptionExtensions
    {
        public static ErrorResponse ToJson(this Exception exception)
        {
            return new ErrorResponse
            {
                Message = exception.Message,
                Traceback = exception.StackTrace,
            };
        }

        public static ErrorResponse ToJson(this CloudApiException exception)
        {
            return new ErrorResponse
            {
                Message = exception.Message,
                Traceback = exception.InnerException != null ? exception.InnerException.StackTrace : exception.StackTrace,
            };
        }
    }
}