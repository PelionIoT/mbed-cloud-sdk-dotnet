using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Newtonsoft.Json;
using RestSharp;

namespace MbedCloudSDK.Client
{
    public static class ApiCall
    {
        public static MbedCloudSDK.Client.ExceptionFactory ExceptionFactory;
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
            MbedCloudSDK.Client.Configuration configuration = null,
            JsonSerializerSettings settings = null,
            Method method = default(Method),
            T @object = default,
            bool populateObject = false)
        {
            ExceptionFactory = MbedCloudSDK.Client.Configuration.DefaultExceptionFactory;
            var localVarPath = path;
            var localVarHeaderParams = new Dictionary<string, string>(configuration.DefaultHeader);
            var localVarPathParams = new Dictionary<string, string>();
            var localVarQueryParams = new List<KeyValuePair<string, string>>();
            var localVarFormParams = new Dictionary<string, string>();
            var localVarFileParams = new Dictionary<string, FileParameter>();
            object localVarPostBody = null;

            var localVarHttpContentType = configuration.ApiClient.SelectHeaderContentType(contentTypes ?? new string[] { });

            var localVarHttpHeaderAccept = configuration.ApiClient.SelectHeaderAccept(accepts ?? new string[] { });

            localVarHeaderParams.Add("Accept", localVarHttpHeaderAccept);

            //add path params
            if (pathParams != null)
                foreach (var item in pathParams)
                {
                    if (item.Value != null)
                        localVarPathParams.Add(item.Key, configuration.ApiClient.ParameterToString(item.Value));
                }

            //add query params
            if (queryParams != null)
                foreach (var item in queryParams)
                {
                    if (item.Value != null)
                        localVarQueryParams.AddRange(configuration.ApiClient.ParameterToKeyValuePairs(null, item.Key, item.Value));
                }

            //add header params
            if (headerParams != null)
                foreach (var item in headerParams)
                {
                    if (item.Value != null)
                        localVarHeaderParams.Add(item.Key, configuration.ApiClient.ParameterToString(item.Value));
                }

            //add form params
            if (formParams != null)
                foreach (var item in formParams)
                {
                    if (item.Value != null)
                        localVarFormParams.Add(item.Key, configuration.ApiClient.ParameterToString(item.Value));
                }

            // add file params
            if (fileParams != null)
                foreach (var item in fileParams)
                {
                    if (item.Value != null)
                        localVarFileParams.Add(item.Key, configuration.ApiClient.ParameterToFile(item.Key, item.Value));
                }

            if (body != null)
            {
                localVarPostBody = configuration.ApiClient.Serialize(body, settings); // http body (model) parameter
            }

            localVarHeaderParams["Authorization"] = configuration.GetApiKeyWithPrefix("Authorization");

            // Console.WriteLine(localVarPostBody);

            // make the HTTP request
            IRestResponse localVarResponse = (IRestResponse) await configuration.ApiClient.CallApiAsync(localVarPath,
                method, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams,
                localVarPathParams, localVarHttpContentType);

            int localVarStatusCode = (int)localVarResponse.StatusCode;

            // Console.WriteLine(localVarResponse.Content);

            if (ExceptionFactory != null)
            {
                Exception exception = ExceptionFactory("AddApiKeyToGroups", localVarResponse);
                if (exception != null) throw exception;
            }

            if (populateObject)
            {
                JsonConvert.PopulateObject(localVarResponse.Content, @object, settings);
                return @object;
            }

            return JsonConvert.DeserializeObject<T>(localVarResponse.Content, settings);
        }
    }
}