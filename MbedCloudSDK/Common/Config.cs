// <copyright file="Config.cs" company="Arm">
// Copyright (c) Arm. All rights reserved.
// </copyright>

namespace MbedCloudSDK.Common
{
    /// <summary>
    /// Config for cloud API.
    /// </summary>
	public class Config
    {
        private string host = "https://api.us-east-1.mbedcloud.com";
        private string apiKey;
        private string authorizationPrefix = "Bearer";

        /// <summary>
        /// Initializes a new instance of the <see cref="Config"/> class.
        /// </summary>
        /// <param name="apiKey">API key.</param>
        public Config(string apiKey)
        {
            this.apiKey = apiKey;
        }

		/// <summary>
		/// Gets or sets the host.
		/// </summary>
		/// <value>The host.</value>
        public string Host
        {
            get { return host; }
            set { host = value; }
        }

		/// <summary>
		/// Gets the API key.
		/// </summary>
		/// <value>The API key.</value>
        public string ApiKey
        {
            get { return apiKey; }
        }

		/// <summary>
		/// Gets or sets the authorization prefix.
		/// </summary>
		/// <value>The authorization prefix.</value>
        public string AuthorizationPrefix
        {
            get { return authorizationPrefix; }
            set { authorizationPrefix = value; }
        }
    }
}
