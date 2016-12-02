using System;
namespace mbedCloudSDK
{
	/// <summary>
	/// Cloud API exception. Common exception thrown when ApiException is raised from backend API
	/// </summary>
	public class CloudApiException: Exception
	{
		/// <summary>
		/// Gets or sets the error code (HTTP status code)
		/// </summary>
		/// <value>The error code (HTTP status code).</value>
		public int ErrorCode { get; set; }

		/// <summary>
		/// Gets the content of the error.
		/// </summary>
		/// <value>The content of the error.</value>
		public dynamic ErrorContent { get; private set; }

		/// <summary>
		/// Initializes a new instance of the <see cref="T:mbedCloudSDK.CloudApiException"/> class.
		/// </summary>
		public CloudApiException() { }

		/// <summary>
		/// Initializes a new instance of the <see cref="T:mbedCloudSDK.CloudApiException"/> class.
		/// </summary>
		/// <param name="errorCode">Error code.</param>
		/// <param name="message">Message.</param>
		public CloudApiException(int errorCode, string message) : base(message)
        {
			this.ErrorCode = errorCode;
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="T:mbedCloudSDK.CloudApiException"/> class.
		/// </summary>
		/// <param name="errorCode">Error code.</param>
		/// <param name="message">Message.</param>
		/// <param name="errorContent">Error content.</param>
		public CloudApiException(int errorCode, string message, dynamic errorContent = null) : base(message)
        {
			this.ErrorCode = errorCode;
			this.ErrorContent = errorContent;
		}
	}
}
