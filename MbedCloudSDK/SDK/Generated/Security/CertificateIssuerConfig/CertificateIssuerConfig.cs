namespace MbedCloud.SDK.Entities
{
    using System;

    /// <summary>
    /// CertificateIssuerConfig
    /// </summary>
    public class CertificateIssuerConfig
    {
        /// <summary>
        /// certificate_issuer_id
        /// </summary>
        public string CertificateIssuerId
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
        /// is_custom
        /// </summary>
        public bool? IsCustom
        {
            get;
            set;
        }

        /// <summary>
        /// reference
        /// </summary>
        public string Reference
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