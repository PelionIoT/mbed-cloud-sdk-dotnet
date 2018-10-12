namespace MbedCloud.SDK.Entities
{
    using System;
    using MbedCloud.SDK.Enums;

    /// <summary>
    /// CertificateIssuer
    /// </summary>
    public class CertificateIssuer
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
        /// description
        /// </summary>
        public string Description
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
        /// issuer_attributes
        /// </summary>
        public object IssuerAttributes
        {
            get;
            set;
        }

        /// <summary>
        /// issuer_type
        /// </summary>
        public CertificateIssuerIssuerTypeEnum? IssuerType
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
        /// successful
        /// </summary>
        public bool? Successful
        {
            get;
            set;
        }
    }
}