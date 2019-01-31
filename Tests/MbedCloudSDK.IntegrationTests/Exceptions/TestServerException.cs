using System;

namespace MbedCloudSDK.IntegrationTests.Exceptions
{
    public class TestServerException : Exception
    {
        public int ErrorCode { get; }
        public TestServerException(string message, int errorCode = 500) : base(message)
        {
            ErrorCode = errorCode;
        }

        public object ToJson()
        {
            return new
            {
                message = Message,
                traceback = string.Empty,
            };
        }
    }
}