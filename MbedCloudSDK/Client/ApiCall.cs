// <copyright file="ApiCall.cs" company="Arm">
// Copyright (c) Arm. All rights reserved.
// </copyright>

namespace MbedCloudSDK.Client
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Threading.Tasks;
    using Newtonsoft.Json;
    using RestSharp;

    /// <summary>
    /// ApiCall
    /// </summary>
    public static class ApiCall
    {
        private static ExceptionFactory exceptionFactory;

        /// <summary>
        /// Calls the API.
        /// </summary>
        /// <typeparam name="T">Return type</typeparam>
        /// <param name="path">The path.</param>
        /// <param name="pathParams">The path parameters.</param>
        /// <param name="queryParams">The query parameters.</param>
        /// <param name="headerParams">The header parameters.</param>
        /// <param name="fileParams">The file parameters.</param>
        /// <param name="formParams">The form parameters.</param>
        /// <param name="contentTypes">The content types.</param>
        /// <param name="accepts">The accepts.</param>
        /// <param name="body">The body.</param>
        /// <param name="configuration">The configuration.</param>
        /// <param name="settings">The settings.</param>
        /// <param name="method">The method.</param>
        /// <param name="objectToPopulate">The object to populate.</param>
        /// <param name="populateObject">if set to <c>true</c> [populate object].</param>
        /// <returns>Object</returns>
        public static async Task<T> CallApi<T>(
                    string path,
                    Dictionary<string, object> pathParams = null,
                    Dictionary<string, object> queryParams = null,
                    Dictionary<string, object> headerParams = null,
                    Dictionary<string, Stream> fileParams = null,
                    Dictionary<string, object> formParams = null,
                    string[] contentTypes = null,
                    string[] accepts = null,
                    object body = null,
                    Configuration configuration = null,
                    JsonSerializerSettings settings = null,
                    Method method = default,
                    T objectToPopulate = default,
                    bool populateObject = false)
        {
            exceptionFactory = Configuration.DefaultExceptionFactory;
            var localVarPath = path;
            var localVarHeaderParams = new Dictionary<string, string>(configuration.DefaultHeader);
            var localVarPathParams = new Dictionary<string, string>();
            var localVarQueryParams = new List<KeyValuePair<string, string>>();
            var localVarFormParams = new Dictionary<string, string>();
            var localVarFileParams = new Dictionary<string, FileParameter>();
            object localVarPostBody = null;

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
                        localVarPathParams.Add(item.Key, configuration.ApiClient.ParameterToString(item.Value));
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
                        localVarQueryParams.AddRange(configuration.ApiClient.ParameterToKeyValuePairs(null, item.Key, item.Value));
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
                        localVarHeaderParams.Add(item.Key, configuration.ApiClient.ParameterToString(item.Value));
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
                        localVarFormParams.Add(item.Key, configuration.ApiClient.ParameterToString(item.Value));
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

            if (body != null)
            {
                localVarPostBody = configuration.ApiClient.Serialize(body, settings); // http body (model) parameter
            }

            localVarHeaderParams["Authorization"] = configuration.GetApiKeyWithPrefix("Authorization");

            // Console.WriteLine(localVarPostBody);

            // make the HTTP request
            var localVarResponse = (IRestResponse)await configuration.ApiClient.CallApiAsync(
                localVarPath,
                method,
                localVarQueryParams,
                localVarPostBody,
                localVarHeaderParams,
                localVarFormParams,
                localVarFileParams,
                localVarPathParams,
                localVarHttpContentType).ConfigureAwait(false);

            var localVarStatusCode = (int)localVarResponse.StatusCode;

            if (exceptionFactory != null)
            {
                var exception = exceptionFactory("AddApiKeyToGroups", localVarResponse);
                if (exception != null)
                {
                    throw exception;
                }
            }

            if (populateObject)
            {
                JsonConvert.PopulateObject(localVarResponse.Content, objectToPopulate, settings);
                return objectToPopulate;
            }

            return JsonConvert.DeserializeObject<T>(localVarResponse.Content, settings);
        }
    }
}