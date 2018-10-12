namespace MbedCloud.SDK.Entities
{
    using System;

    /// <summary>
    /// DeveloperCertificate
    /// </summary>
    public class DeveloperCertificate
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
        /// description
        /// </summary>
        public string Description
        {
            get;
            set;
        }

        /// <summary>
        /// developer_certificate
        /// </summary>
        public string DeveloperCertificate
        {
            get;
            set;
        }

        /// <summary>
        /// developer_private_key
        /// </summary>
        public string DeveloperPrivateKey
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
        /// name
        /// </summary>
        public string Name
        {
            get;
            set;
        }

        /// <summary>
        /// security_file_content
        /// </summary>
        public string SecurityFileContent
        {
            get;
            set;
        }
    }
}