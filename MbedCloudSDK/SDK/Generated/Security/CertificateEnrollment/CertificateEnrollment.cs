namespace MbedCloud.SDK.Entities
{
    using System;
    using MbedCloud.SDK.Enums;

    /// <summary>
    /// CertificateEnrollment
    /// </summary>
    public class CertificateEnrollment
    {
        /// <summary>
        /// certificate_name
        /// </summary>
        public string CertificateName
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
        /// device_id
        /// </summary>
        public string DeviceId
        {
            get;
            set;
        }

        /// <summary>
        /// enroll_result
        /// </summary>
        public CertificateEnrollmentEnrollResultEnum? EnrollResult
        {
            get;
            set;
        }

        /// <summary>
        /// enroll_status
        /// </summary>
        public CertificateEnrollmentEnrollStatusEnum? EnrollStatus
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
    }
}