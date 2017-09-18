using System;
using System.Collections.Generic;

namespace MbedCloudSDK.AccountManagement.Model.User
{
    ///<summary>
    /// Login History
    ///</summary>
    public class LoginHistory
    {
        ///<summary>
        /// Date of login
        ///</summary>
        public DateTime? Date { get; private set; }

        ///<summary>
        /// User agent used for login
        ///</summary>
        public string UserAgent { get; private set; }

        ///<summary>
        /// IP Address login from
        ///</summary>
        public string IpAddress { get; private set; }

        ///<summary>
        /// Whether login was successful
        ///</summary>
        public bool? Success { get; private set; }

        public LoginHistory(DateTime? date = null, string userAgent = null, string ipAddress = null, bool? success = null)
        {
            Date = date;
            UserAgent = userAgent;
            IpAddress = ipAddress;
            Success = success;
        }

        public static LoginHistory Map(iam.Model.LoginHistory data)
        {
            return new LoginHistory(data.Date, data.UserAgent, data.IpAddress, data.Success);
        }
    }
}