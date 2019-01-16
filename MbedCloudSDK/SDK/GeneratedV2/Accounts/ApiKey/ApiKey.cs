using System;
using MbedCloud.SDK.Common;
using MbedCloud.SDK.Enums;

namespace MbedCloud.SDK.GeneratedV2.Accounts.ApiKey
{
    /// <summary>
    /// ApiKey
    /// </summary>
    public class ApiKey : Entity
    {
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
        /// creation_time
        /// </summary>
        public long? CreationTime
        {
            get;
            set;
        }

        /// <summary>
        /// key
        /// </summary>
        public string Key
        {
            get;
            set;
        }

        /// <summary>
        /// last_login_time
        /// </summary>
        public long? LastLoginTime
        {
            get;
            set;
        }

        /// <summary>
        /// name
        /// </summary>
        public string Name
        {
            get;
            set;
        }

        /// <summary>
        /// owner
        /// </summary>
        public string Owner
        {
            get;
            set;
        }

        /// <summary>
        /// status
        /// </summary>
        public ApiKeyStatusStatusEnum? Status
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
    }
}