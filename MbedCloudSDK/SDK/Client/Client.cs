using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using MbedCloud.SDK.Client;
using MbedCloud.SDK.Common;
using MbedCloud.SDK.Common.CustomSerializers;
using Newtonsoft.Json;
using RestSharp;

namespace MbedCloud.SDK.Client
{
    public class Client
    {
        private static MbedCloud.SDK.Client.ExceptionFactory exceptionFactory;

        public Config Config { get; }

        private readonly JsonSerializerSettings serializationSettings;
        private readonly JsonSerializerSettings deserializationSettings;

        public Client(Config config)
        {
            Config = config;
            serializationSettings = SerializationSettings.GetSerializationSettings();
            deserializationSettings = SerializationSettings.GetDeserializationSettings(config);
            exceptionFactory = MbedCloud.SDK.Client.Configuration.DefaultExceptionFactory;
        }

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
            where T : new()
        {
            var clientConfiguration = Config.Configuration;
            var localVarPath = path;
            var localVarHeaderParams = new Dictionary<string, string>(clientConfiguration.DefaultHeader);
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

            var localVarHttpContentType =  MbedCloud.SDK.Client.ApiClient.SelectHeaderContentType(contentTypes ?? new string[] { });

            var localVarHttpHeaderAccept = MbedCloud.SDK.Client.ApiClient.SelectHeaderAccept(accepts ?? new string[] { });

            localVarHeaderParams.Add("Accept", localVarHttpHeaderAccept);

            // add path params
            if (pathParams != null)
            {
                foreach (var item in pathParams)
                {
                    if (item.Value != null)
                    {
                        localVarPathParams.Add(item.Key, clientConfiguration.ApiClient.ParameterToString(item.Value));
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
                        localVarQueryParams.AddRange(clientConfiguration.ApiClient.ParameterToKeyValuePairs(null, item.Key, item.Value));
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
                        localVarHeaderParams.Add(item.Key, clientConfiguration.ApiClient.ParameterToString(item.Value));
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
                        localVarFormParams.Add(item.Key, clientConfiguration.ApiClient.ParameterToString(item.Value));
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
                        localVarFileParams.Add(item.Key, MbedCloud.SDK.Client.ApiClient.ParameterToFile(item.Key, item.Value));
                    }
                }
            }

            if (bodyParams != null)
            {
                localVarPostBody = clientConfiguration.ApiClient.Serialize(bodyParams, serializationSettings); // http body (model) parameter
            }

            localVarHeaderParams["Authorization"] = clientConfiguration.GetApiKeyWithPrefix("Authorization");

            // Console.WriteLine(localVarPostBody);

            // make the HTTP request
            var localVarResponse = (IRestResponse)await clientConfiguration.ApiClient.CallApiAsync(
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

            if (exceptionFactory != null)
            {
                var exception = exceptionFactory("AddApiKeyToGroups", localVarResponse);
                if (exception != null)
                {
                    throw exception;
                }
            }

            if (string.IsNullOrEmpty(localVarResponse.Content))
            {
                return default(T);
            }

            if (objectToUnpack != null)
            {
                JsonConvert.PopulateObject(localVarResponse.Content, objectToUnpack, deserializationSettings);
                return objectToUnpack;
            }

            return JsonConvert.DeserializeObject<T>(localVarResponse.Content, deserializationSettings);
        }
    }
}