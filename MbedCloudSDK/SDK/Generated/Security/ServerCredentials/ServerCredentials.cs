namespace MbedCloud.SDK.Entities
{
    using System;

    /// <summary>
    /// ServerCredentials
    /// </summary>
    public class ServerCredentials
    {
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
        /// id
        /// </summary>
        public string Id
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
    }
}