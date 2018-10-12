namespace MbedCloud.SDK.Entities
{
    using System;

    /// <summary>
    /// EnrollmentClaim
    /// </summary>
    public class EnrollmentClaim
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
        /// claimed_at
        /// </summary>
        public DateTime? ClaimedAt
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
        /// enrolled_device_id
        /// </summary>
        public string EnrolledDeviceId
        {
            get;
            set;
        }

        /// <summary>
        /// enrollment_identity
        /// </summary>
        public string EnrollmentIdentity
        {
            get;
            set;
        }

        /// <summary>
        /// expires_at
        /// </summary>
        public DateTime? ExpiresAt
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