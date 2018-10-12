namespace MbedCloud.SDK.Entities
{
    using System;
    using System.Collections.Generic;
    using MbedCloud.SDK.Enums;

    /// <summary>
    /// ApiKey
    /// </summary>
    public class ApiKey
    {
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
        /// group_ids
        /// </summary>
        public List<string> GroupIds
        {
            get;
            set;
        }

        /// <summary>
        /// id
        /// </summary>
        public string Id
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
        public ApiKeyStatusEnum? Status
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