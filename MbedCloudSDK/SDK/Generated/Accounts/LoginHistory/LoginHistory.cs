namespace MbedCloud.SDK.Entities
{
    using System;

    /// <summary>
    /// LoginHistory
    /// </summary>
    public class LoginHistory
    {
        /// <summary>
        /// date
        /// </summary>
        public DateTime? Date
        {
            get;
            set;
        }

        /// <summary>
        /// ip_address
        /// </summary>
        public string IpAddress
        {
            get;
            set;
        }

        /// <summary>
        /// success
        /// </summary>
        public bool? Success
        {
            get;
            set;
        }

        /// <summary>
        /// user_agent
        /// </summary>
        public string UserAgent
        {
            get;
            set;
        }
    }
}