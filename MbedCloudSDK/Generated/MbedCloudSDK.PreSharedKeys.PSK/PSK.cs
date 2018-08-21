// <copyright file="AccountManagementApi.Account.cs" company="Arm">
// Copyright (c) Arm. All rights reserved.
// </copyright>
namespace MbedCloudSDK.PreSharedKeys.PSK
{
    using MbedCloudSDK.Common;
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using MbedCloudSDK.Client;
    using MbedCloudSDK.Exceptions;
    using RestSharp;
    using MbedCloudSDK.Common.Extensions;

    /// <summary>
    /// PSK
    /// </summary>
    public partial class PSK : BaseModel
    {
        /// <summary>
        /// The date-time (RFC3339) when this pre-shared key was uploaded to Mbed Cloud.
        /// </summary>
        public DateTime CreatedAt
        {
            get;
            set;
        }

        /// <summary>
        /// The unique endpoint identifier that this pre-shared key applies to. 16-64 [printable](https://en.wikipedia.org/wiki/ASCII#Printable_characters) (non-control) ASCII characters.
        /// </summary>
        public string EndpointName
        {
            get;
            set;
        }

        public async Task<PSK> Create()
        {
            var renames = new Dictionary<string, string>();
            try
            {
                return await MbedCloudSDK.Client.ApiCall.CallApi<PSK>(path: "/v2/device-shared-keys", method: Method.POST, pathParams: new Dictionary<string, object>()
                {}, configuration: Config);
            }
            catch (MbedCloudSDK.Client.ApiException e)
            {
                throw new CloudApiException(e.ErrorCode, e.Message, e.ErrorContent);
            }
        }

        public async Task<PSK> Delete()
        {
            var renames = new Dictionary<string, string>();
            try
            {
                return await MbedCloudSDK.Client.ApiCall.CallApi<PSK>(path: "/v2/device-shared-keys/{endpoint_name}", method: Method.DELETE, pathParams: new Dictionary<string, object>()
                {}, configuration: Config);
            }
            catch (MbedCloudSDK.Client.ApiException e)
            {
                throw new CloudApiException(e.ErrorCode, e.Message, e.ErrorContent);
            }
        }

        public async Task<PSK> List()
        {
            var renames = new Dictionary<string, string>();
            try
            {
                return await MbedCloudSDK.Client.ApiCall.CallApi<PSK>(path: "/v2/device-shared-keys", method: Method.GET, pathParams: new Dictionary<string, object>()
                {}, configuration: Config);
            }
            catch (MbedCloudSDK.Client.ApiException e)
            {
                throw new CloudApiException(e.ErrorCode, e.Message, e.ErrorContent);
            }
        }

        public async Task<PSK> Read()
        {
            var renames = new Dictionary<string, string>();
            try
            {
                return await MbedCloudSDK.Client.ApiCall.CallApi<PSK>(path: "/v2/device-shared-keys/{endpoint_name}", method: Method.GET, pathParams: new Dictionary<string, object>()
                {}, configuration: Config);
            }
            catch (MbedCloudSDK.Client.ApiException e)
            {
                throw new CloudApiException(e.ErrorCode, e.Message, e.ErrorContent);
            }
        }

        /// <summary>
        /// Get human readable string of this object
        /// </summary>
        /// <returns>Serialized string of object</returns>
        public override string ToString() => this.DebugDump();
    }
}