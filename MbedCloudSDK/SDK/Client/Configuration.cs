// <copyright file="Configuration.cs" company="Arm">
// Copyright (c) Arm. All rights reserved.
// </copyright>

namespace MbedCloud.SDK.Client
{
    using System;
    using System.Collections.Concurrent;
    using System.Collections.Generic;

    /// <summary>
    /// Represents a set of configuration settings
    /// </summary>
    public class Configuration
    {
        /// <summary>
        /// Identifier for ISO 8601 DateTime Format
        /// </summary>
        /// <remarks>See https://msdn.microsoft.com/en-us/library/az4se3k1(v=vs.110).aspx#Anchor_8 for more information.</remarks>
        // ReSharper disable once InconsistentNaming
        public const string ISO8601_DATETIME_FORMAT = "o";

        /// <summary>
        /// Default creation of exceptions for a given method name and response object
        /// </summary>
        public static readonly ExceptionFactory DefaultExceptionFactory = (methodName, response) =>
        {
            var status = (int)response.StatusCode;
            if (status >= 400)
            {
                return new ApiException(
                    status,
                    $"Error calling {methodName}: {response.Content}",
                    response.Content);
            }

            if (status == 0)
            {
                return new ApiException(
                    status,
                    $"Error calling {methodName}: {response.ErrorMessage}",
                    response.ErrorMessage);
            }

            return null;
        };

        private ApiClient apiClient;

        /// <summary>
        /// Gets or sets the API key based on the authentication name.
        /// </summary>
        /// <value>The API key.</value>
        private IDictionary<string, string> apiKey;

        /// <summary>
        /// Gets or sets the prefix (e.g. Token) of the API key based on the authentication name.
        /// </summary>
        /// <value>The prefix of the API key.</value>
        private IDictionary<string, string> apiKeyPrefix;

        private string basePath;

        private string dateTimeFormat = ISO8601_DATETIME_FORMAT;

        /// <summary>
        /// Initializes a new instance of the <see cref="Configuration" /> class
        /// </summary>
        public Configuration()
        {
            BasePath = "https://api.us-east-1.mbedcloud.com";
            DefaultHeader = new ConcurrentDictionary<string, string>();
            ApiKey = new ConcurrentDictionary<string, string>();
            ApiKeyPrefix = new ConcurrentDictionary<string, string>();
            Timeout = 100000;
        }

        /// <summary>
        /// Gets an instance of an ApiClient for this configuration
        /// </summary>
        public virtual ApiClient ApiClient
        {
            get
            {
                if (apiClient == null)
                {
                    apiClient = CreateApiClient();
                }

                return apiClient;
            }
        }

        /// <summary>
        /// Gets or sets the API key based on the authentication name.
        /// </summary>
        /// <value>The API key.</value>
        public virtual IDictionary<string, string> ApiKey
        {
            get
            {
                return apiKey;
            }

            set
            {
                apiKey = value ?? throw new InvalidOperationException("ApiKey collection may not be null.");
            }
        }

        /// <summary>
        /// Gets or sets the prefix (e.g. Token) of the API key based on the authentication name.
        /// </summary>
        /// <value>The prefix of the API key.</value>
        public virtual IDictionary<string, string> ApiKeyPrefix
        {
            get
            {
                return apiKeyPrefix;
            }

            set
            {
                apiKeyPrefix = value ?? throw new InvalidOperationException("ApiKeyPrefix collection may not be null.");
            }
        }

        /// <summary>
        /// Gets or sets the base path for API access.
        /// </summary>
        public virtual string BasePath
        {
            get
            {
                return basePath;
            }

            set
            {
                basePath = value;
                if (apiClient != null)
                {
                    apiClient.RestClient.BaseUrl = new Uri(basePath);
                }
            }
        }

        /// <summary>
        /// Gets or sets the the date time format used when serializing in the ApiClient
        /// By default, it's set to ISO 8601 - "o", for others see:
        /// https://msdn.microsoft.com/en-us/library/az4se3k1(v=vs.110).aspx
        /// and https://msdn.microsoft.com/en-us/library/8kb3ddd4(v=vs.110).aspx
        /// No validation is done to ensure that the string you're providing is valid
        /// </summary>
        /// <value>The DateTimeFormat string</value>
        public virtual string DateTimeFormat
        {
            get
            {
                return dateTimeFormat;
            }

            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    // Never allow a blank or null string, go back to the default
                    dateTimeFormat = ISO8601_DATETIME_FORMAT;
                    return;
                }

                dateTimeFormat = value;
            }
        }

        /// <summary>
        /// Gets or sets the default header.
        /// </summary>
        public virtual IDictionary<string, string> DefaultHeader { get; set; }

        /// <summary>
        /// Gets or sets the HTTP timeout (milliseconds) of ApiClient. Default to 100000 milliseconds.
        /// </summary>
        public int Timeout { get; set; }

        /// <summary>
        /// Gets or sets the HTTP user agent.
        /// </summary>
        /// <value>Http user agent.</value>
        public virtual string UserAgent { get; set; }

        /// <summary>
        /// Add Api Key Header
        /// </summary>
        /// <param name="key">Api Key name.</param>
        /// <param name="value">Api Key value.</param>
        public void AddApiKey(string key, string value)
        {
            ApiKey[key] = value;
        }

        /// <summary>
        /// Sets the API key prefix.
        /// </summary>
        /// <param name="key">Api Key name.</param>
        /// <param name="value">Api Key value.</param>
        public void AddApiKeyPrefix(string key, string value)
        {
            ApiKeyPrefix[key] = value;
        }

        /// <summary>
        /// Creates a new <see cref="ApiClient" /> based on this <see cref="Configuration" /> instance.
        /// </summary>
        /// <returns>ApiClient</returns>
        public ApiClient CreateApiClient()
        {
            return new ApiClient(BasePath) { Configuration = this };
        }

        /// <summary>
        /// Gets the API key with prefix.
        /// </summary>
        /// <param name="apiKeyIdentifier">API key identifier (authentication scheme).</param>
        /// <returns>API key with prefix.</returns>
        public string GetApiKeyWithPrefix(string apiKeyIdentifier)
        {
            var apiKeyValue = string.Empty;
            ApiKey.TryGetValue(apiKeyIdentifier, out apiKeyValue);
            var apiKeyPrefix = string.Empty;
            return ApiKeyPrefix.TryGetValue(apiKeyIdentifier, out apiKeyPrefix) ? apiKeyPrefix + " " + apiKeyValue : apiKeyValue;
        }
    }
}