// <auto-generated>
//
// Generated by
//                     _                        _
//   /\/\   __ _ _ __ | |__   __ _ ___ ___  ___| |_
//  /    \ / _` | '_ \| '_ \ / _` / __/ __|/ _ \ __|
// / /\/\ \ (_| | | | | | | | (_| \__ \__ \  __/ |_
// \/    \/\__,_|_| |_|_| |_|\__,_|___/___/\___|\__| v 1.0.0
//
// <copyright file="ServerCredentials.cs" company="Arm">
// Copyright (c) Arm. All rights reserved.
// </copyright>
// </auto-generated>

namespace MbedCloud.SDK.Entities
{
    using MbedCloud.SDK.Common;
    using MbedCloud.SDK.Client;
    using System;
    using System.Threading.Tasks;
    using MbedCloudSDK.Exceptions;
    using System.Collections.Generic;

    /// <summary>
    /// ServerCredentials
    /// </summary>
    public class ServerCredentials : BaseEntity
    {
        public ServerCredentials()
        {
            Client = new Client(Config);
        }

        public ServerCredentials(Config config)
        {
            Config = config;
            Client = new Client(Config);
        }

        /// <summary>
        /// bootstrap
        /// </summary>
        public object Bootstrap
        {
            get;
            set;
        }

        /// <summary>
        /// created_at
        /// </summary>
        public DateTime? CreatedAt
        {
            get;
            set;
        }

        /// <summary>
        /// lwm2m
        /// </summary>
        public object Lwm2m
        {
            get;
            set;
        }

        /// <summary>
        /// server_certificate
        /// </summary>
        public string ServerCertificate
        {
            get;
            set;
        }

        /// <summary>
        /// server_uri
        /// </summary>
        public string ServerUri
        {
            get;
            set;
        }

        public async Task<ServerCredentials> GetAll()
        {
            try
            {
                return await Client.CallApi<ServerCredentials>(path: "/v3/server-credentials", method: HttpMethods.GET, objectToUnpack: this);
            }
            catch (MbedCloud.SDK.Client.ApiException e)
            {
                throw new CloudApiException(e.ErrorCode, e.Message, e.ErrorContent);
            }
        }

        public async Task<ServerCredentials> GetBootstrap()
        {
            try
            {
                return await Client.CallApi<ServerCredentials>(path: "/v3/server-credentials/bootstrap", method: HttpMethods.GET, objectToUnpack: this);
            }
            catch (MbedCloud.SDK.Client.ApiException e)
            {
                throw new CloudApiException(e.ErrorCode, e.Message, e.ErrorContent);
            }
        }

        public async Task<ServerCredentials> GetLwm2m()
        {
            try
            {
                return await Client.CallApi<ServerCredentials>(path: "/v3/server-credentials/lwm2m", method: HttpMethods.GET, objectToUnpack: this);
            }
            catch (MbedCloud.SDK.Client.ApiException e)
            {
                throw new CloudApiException(e.ErrorCode, e.Message, e.ErrorContent);
            }
        }
    }
}