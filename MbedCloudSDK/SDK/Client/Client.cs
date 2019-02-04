// <copyright file="Client.cs" company="Arm">
// Copyright (c) Arm. All rights reserved.
// </copyright>

namespace Mbed.Cloud.Foundation.RestClient
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Mbed.Cloud.Foundation.Common;
    using Newtonsoft.Json;
    using RestSharp;

    /// <summary>
    /// Client
    /// </summary>
    public class Client
    {
        /// <summary>
        /// Default creation of exceptions for a given method name and response object
        /// </summary>
        public static readonly ExceptionFactory ExceptionFactory = (methodName, response) =>
        {
            var status = (int)response.StatusCode;
            if (status == 404)
            {
                // ignore 404s
                return null;
            }

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

        private readonly ApiClient apiClient;
        private readonly string dateTimeFormat = "yyyy-MM-dd'T'HH:mm:ss.fffZ";
        private readonly JsonSerializerSettings deserializationSettings;

        private readonly JsonSerializerSettings serializationSettings;

        /// <summary>
        /// Initializes a new instance of the <see cref="Client"/> class.
        /// </summary>
        /// <param name="config">The configuration.</param>
        public Client(Config config)
        {
            Config = config;
            serializationSettings = SerializationSettings.GetSerializationSettings();
            deserializationSettings = SerializationSettings.GetDeserializationSettings(config);
            apiClient = new ApiClient(Config.Host);
        }

        /// <summary>
        /// Gets the configuration.
        /// </summary>
        /// <value>
        /// The configuration.
        /// </value>
        public Config Config { get; }

        /// <summary>
        /// Calls the API.
        /// </summary>
        /// <typeparam name="T">Type to return</typeparam>
        /// <param name="path">The path.</param>
        /// <param name="pathParams">The path parameters.</param>
        /// <param name="queryParams">The query parameters.</param>
        /// <param name="headerParams">The header parameters.</param>
        /// <param name="fileParams">The file parameters.</param>
        /// <param name="formParams">The form parameters.</param>
        /// <param name="contentTypes">The content types.</param>
        /// <param name="accepts">The accepts.</param>
        /// <param name="bodyParams">The body parameters.</param>
        /// <param name="method">The method.</param>
        /// <param name="objectToUnpack">The object to unpack.</param>
        /// <returns>Task of T</returns>
        public async Task<T> CallApi<T>(
                            string path,
                            Dictionary<string, object> pathParams = null,
                            Dictionary<string, object> queryParams = null,
                            Dictionary<string, object> headerParams = null,
                            Dictionary<string, Stream> fileParams = null,
                            Dictionary<string, object> formParams = null,
                            string[] contentTypes = null,
                            string[] accepts = null,
                            object bodyParams = null,
                            HttpMethods method = default,
                            T objectToUnpack = default)
                    where T : class, new()
        {
            var localVarPath = path;
            var localVarHeaderParams = new Dictionary<string, string>();
            var localVarPathParams = new Dictionary<string, string>();
            var localVarQueryParams = new List<KeyValuePair<string, string>>();
            var localVarFormParams = new Dictionary<string, string>();
            var localVarFileParams = new Dictionary<string, FileParameter>();
            object localVarPostBody = null;

            if (contentTypes == null)
            {
                contentTypes = new string[] { "application/json" };
            }

            if (accepts == null)
            {
                accepts = new string[] { "application/json" };
            }

            var localVarHttpContentType = ApiClient.SelectHeaderContentType(contentTypes ?? new string[] { });

            var localVarHttpHeaderAccept = ApiClient.SelectHeaderAccept(accepts ?? new string[] { });

            localVarHeaderParams.Add("Accept", localVarHttpHeaderAccept);

            // add path params
            if (pathParams != null)
            {
                foreach (var item in pathParams)
                {
                    if (item.Value != null)
                    {
                        localVarPathParams.Add(item.Key, ParameterToString(item.Value));
                    }
                }
            }

            // add query params
            if (queryParams != null)
            {
                foreach (var item in queryParams)
                {
                    if (item.Value != null)
                    {
                        localVarQueryParams.AddRange(ParameterToKeyValuePairs(null, item.Key, item.Value));
                    }
                }
            }

            // add header params
            if (headerParams != null)
            {
                foreach (var item in headerParams)
                {
                    if (item.Value != null)
                    {
                        localVarHeaderParams.Add(item.Key, ParameterToString(item.Value));
                    }
                }
            }

            // add form params
            if (formParams != null)
            {
                foreach (var item in formParams)
                {
                    if (item.Value != null)
                    {
                        localVarFormParams.Add(item.Key, ParameterToString(item.Value));
                    }
                }
            }

            // add file params
            if (fileParams != null)
            {
                foreach (var item in fileParams)
                {
                    if (item.Value != null)
                    {
                        localVarFileParams.Add(item.Key, ApiClient.ParameterToFile(item.Key, item.Value));
                    }
                }
            }

            if (bodyParams != null)
            {
                localVarPostBody = Serialize(bodyParams, serializationSettings); // http body (model) parameter
            }

            localVarHeaderParams["Authorization"] = $"{Config.AuthorizationPrefix} {Config.ApiKey}";

            // Console.WriteLine(localVarPostBody);

            // make the HTTP request
            var localVarResponse = (IRestResponse)await apiClient.CallApiAsync(
                localVarPath,
                (Method)((int)method),
                localVarQueryParams,
                localVarPostBody,
                localVarHeaderParams,
                localVarFormParams,
                localVarFileParams,
                localVarPathParams,
                localVarHttpContentType).ConfigureAwait(false);

            var localVarStatusCode = (int)localVarResponse.StatusCode;

            var exception = ExceptionFactory("AddApiKeyToGroups", localVarResponse);
            if (exception != null)
            {
                throw exception;
            }

            if (string.IsNullOrEmpty(localVarResponse.Content))
            {
                // we have an instance, if no content, then just return it.
                if (objectToUnpack != null)
                {
                    return objectToUnpack;
                }

                return null;
            }

            if (objectToUnpack != null)
            {
                JsonConvert.PopulateObject(localVarResponse.Content, objectToUnpack, deserializationSettings);
                return objectToUnpack;
            }

            if ((int)localVarResponse.StatusCode == 404)
            {
                // don't return anything for 404
                return null;
            }

            return JsonConvert.DeserializeObject<T>(localVarResponse.Content, deserializationSettings);
        }

        /// <summary>
        /// Convert params to key/value pairs.
        /// Use collectionFormat to properly format lists and collections.
        /// </summary>
        /// <param name="collectionFormat">The collection format.</param>
        /// <param name="name">Key name.</param>
        /// <param name="value">Value object.</param>
        /// <returns>
        /// A list of KeyValuePairs
        /// </returns>
        public IEnumerable<KeyValuePair<string, string>> ParameterToKeyValuePairs(string collectionFormat, string name, object value)
        {
            var parameters = new List<KeyValuePair<string, string>>();

            if (IsCollection(value) && collectionFormat == "multi")
            {
                var valueCollection = value as IEnumerable;
                parameters.AddRange(from object item in valueCollection select new KeyValuePair<string, string>(name, ParameterToString(item)));
            }
            else
            {
                parameters.Add(new KeyValuePair<string, string>(name, ParameterToString(value)));
            }

            return parameters;
        }

        /// <summary>
        /// If parameter is DateTime, output in a formatted string (default ISO 8601), customizable with Configuration.DateTime.
        /// If parameter is a list, join the list with ",".
        /// Otherwise just return the string.
        /// </summary>
        /// <param name="obj">The parameter (header, path, query, form).</param>
        /// <returns>Formatted string.</returns>
        public string ParameterToString(object obj)
        {
            if (obj is DateTime)
            {
                // Return a formatted date string - Can be customized with Configuration.DateTimeFormat
                // Defaults to an ISO 8601, using the known as a Round-trip date/time pattern ("o")
                // https://msdn.microsoft.com/en-us/library/az4se3k1(v=vs.110).aspx#Anchor_8
                // For example: 2009-06-15T13:45:30.0000000
                return ((DateTime)obj).ToString(dateTimeFormat);
            }
            else if (obj is DateTimeOffset)
            {
                // Return a formatted date string - Can be customized with Configuration.DateTimeFormat
                // Defaults to an ISO 8601, using the known as a Round-trip date/time pattern ("o")
                // https://msdn.microsoft.com/en-us/library/az4se3k1(v=vs.110).aspx#Anchor_8
                // For example: 2009-06-15T13:45:30.0000000
                return ((DateTimeOffset)obj).ToString(dateTimeFormat);
            }
            else if (obj is IList)
            {
                var flattenedString = new StringBuilder();
                foreach (var param in (IList)obj)
                {
                    if (flattenedString.Length > 0)
                    {
                        flattenedString.Append(",");
                    }

                    flattenedString.Append(param);
                }

                return flattenedString.ToString();
            }
            else
            {
                return Convert.ToString(obj);
            }
        }

        /// <summary>
        /// Serialize an input (model) into JSON string
        /// </summary>
        /// <param name="obj">object.</param>
        /// <param name="settings">todo: describe settings parameter on Serialize</param>
        /// <returns>JSON string.</returns>
        public string Serialize(object obj, JsonSerializerSettings settings)
        {
            try
            {
                settings.DateFormatString = dateTimeFormat;
                return obj != null ? JsonConvert.SerializeObject(obj, settings) : null;
            }
            catch (Exception e)
            {
                throw new ApiException(500, e.Message);
            }
        }

        /// <summary>
        /// Check if generic object is a collection.
        /// </summary>
        /// <param name="value">value</param>
        /// <returns>True if object is a collection type</returns>
        private static bool IsCollection(object value)
        {
            return value is IList || value is ICollection;
        }
    }
}