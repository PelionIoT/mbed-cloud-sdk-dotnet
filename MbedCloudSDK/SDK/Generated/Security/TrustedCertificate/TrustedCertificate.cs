namespace MbedCloud.SDK.Entities
{
    using System;
    using MbedCloud.SDK.Common;
    using MbedCloud.SDK.Enums;

    /// <summary>
    /// TrustedCertificate
    /// </summary>
    public class TrustedCertificate
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
        /// certificate
        /// </summary>
        public string Certificate
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
        /// developer
        /// </summary>
        public bool? Developer
        {
            get
            {
                return CustomFunctions.DeveloperCertificateGetter(this);
            }

            set
            {
                CustomFunctions.DeveloperCertificateSetter(this, value);
            }
        }

        /// <summary>
        /// device_execution_mode
        /// </summary>
        public int? DeviceExecutionMode
        {
            get;
            set;
        }

        /// <summary>
        /// enrollment_mode
        /// </summary>
        public bool? EnrollmentMode
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
        /// issuer
        /// </summary>
        public string Issuer
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
        /// owner_id
        /// </summary>
        public string OwnerId
        {
            get;
            set;
        }

        /// <summary>
        /// service
        /// </summary>
        public TrustedCertificateServiceEnum? Service
        {
            get;
            set;
        }

        /// <summary>
        /// status
        /// </summary>
        public TrustedCertificateStatusEnum? Status
        {
            get;
            set;
        }

        /// <summary>
        /// subject
        /// </summary>
        public string Subject
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
        /// validity
        /// </summary>
        public DateTime? Validity
        {
            get;
            set;
        }
    }
}