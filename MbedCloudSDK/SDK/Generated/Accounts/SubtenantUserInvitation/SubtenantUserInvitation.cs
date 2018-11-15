// <auto-generated>
//
// Generated by
//                     _                        _
//   /\/\   __ _ _ __ | |__   __ _ ___ ___  ___| |_
//  /    \ / _` | '_ \| '_ \ / _` / __/ __|/ _ \ __|
// / /\/\ \ (_| | | | | | | | (_| \__ \__ \  __/ |_
// \/    \/\__,_|_| |_|_| |_|\__,_|___/___/\___|\__| v 1.0.0
//
// <copyright file="SubtenantUserInvitation.cs" company="Arm">
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
    /// SubtenantUserInvitation
    /// </summary>
    public class SubtenantUserInvitation : BaseEntity
    {
        public SubtenantUserInvitation()
        {
        }

        public SubtenantUserInvitation(Config config) : base(config)
        {
        }

        /// <summary>
        /// account_id
        /// </summary>
        public string AccountId
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
        /// email
        /// </summary>
        public string Email
        {
            get;
            set;
        }

        /// <summary>
        /// expiration
        /// </summary>
        public DateTime? Expiration
        {
            get;
            set;
        }

        /// <summary>
        /// updated_at
        /// </summary>
        public DateTime? UpdatedAt
        {
            get;
            set;
        }

        /// <summary>
        /// user_id
        /// </summary>
        public string UserId
        {
            get;
            set;
        }

        public async Task<SubtenantUserInvitation> Create()
        {
            try
            {
                var pathParams = new Dictionary<string, object> { { "account-id", AccountId }, };
                var bodyParams = new SubtenantUserInvitation { Email = Email, };
                return await Client.CallApi<SubtenantUserInvitation>(path: "/v3/accounts/{account-id}/user-invitations", pathParams: pathParams, bodyParams: bodyParams, method: HttpMethods.POST, objectToUnpack: this);
            }
            catch (MbedCloud.SDK.Client.ApiException e)
            {
                throw new CloudApiException(e.ErrorCode, e.Message, e.ErrorContent);
            }
        }

        public async Task<SubtenantUserInvitation> Delete()
        {
            try
            {
                var pathParams = new Dictionary<string, object> { { "account-id", AccountId }, { "invitation-id", Id }, };
                return await Client.CallApi<SubtenantUserInvitation>(path: "/v3/accounts/{account-id}/user-invitations/{invitation-id}", pathParams: pathParams, method: HttpMethods.DELETE, objectToUnpack: this);
            }
            catch (MbedCloud.SDK.Client.ApiException e)
            {
                throw new CloudApiException(e.ErrorCode, e.Message, e.ErrorContent);
            }
        }

        public async Task<SubtenantUserInvitation> Get()
        {
            try
            {
                var pathParams = new Dictionary<string, object> { { "account-id", AccountId }, { "invitation-id", Id }, };
                return await Client.CallApi<SubtenantUserInvitation>(path: "/v3/accounts/{account-id}/user-invitations/{invitation-id}", pathParams: pathParams, method: HttpMethods.GET, objectToUnpack: this);
            }
            catch (MbedCloud.SDK.Client.ApiException e)
            {
                throw new CloudApiException(e.ErrorCode, e.Message, e.ErrorContent);
            }
        }
    }
}