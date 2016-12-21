using System;
namespace mbedCloudSDK.Exceptions
{
    /// <summary>
    /// Cloud API exception. Common exception thrown when ApiException is raised by sending wrong values to the request
    /// </summary>
    public class ValueException : Exception
    {
        /// <summary>
        /// Gets or sets the error code.
        /// </summary>
        /// <value>The error code.</value>
        public int ErrorCode { get; set; }

        /// <summary>
        /// Gets the content of the error.
        /// </summary>
        /// <value>The content of the error.</value>
        public dynamic ErrorContent { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:mbedCloudSDK.Exceptions.ValueException"/> class.
        /// </summary>
        public ValueException() { }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:mbedCloudSDK.Exceptions.ValueException"/> class.
        /// </summary>
        /// <param name="message">Message.</param>
        public ValueException(string message) : base(message)
        {
            this.ErrorCode = 1;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:mbedCloudSDK.Exceptions.ValueException"/> class.
        /// </summary>
        /// <param name="errorCode">Error code.</param>
        /// <param name="message">Message.</param>
        public ValueException(int errorCode, string message) : base(message)
        {
            this.ErrorCode = errorCode;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:mbedCloudSDK.Exceptions.ValueException"/> class.
        /// </summary>
        /// <param name="errorCode">Error code.</param>
        /// <param name="message">Message.</param>
        /// <param name="errorContent">Error content.</param>
        public ValueException(int errorCode, string message, dynamic errorContent = null) : base(message)
        {
            this.ErrorCode = errorCode;
            this.ErrorContent = errorContent;
        }
    }
}
