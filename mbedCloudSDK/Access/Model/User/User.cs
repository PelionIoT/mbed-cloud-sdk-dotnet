using System;
using System.Collections.Generic;
using System.Text;

namespace mbedCloudSDK.Access.Model.User
{
    /// <summary>
    /// This object represents a user in mbed Cloud.
    /// </summary>
    public class User
    {

        /// <summary>
        /// The status of the user. INVITED means that the user has not accepted the invitation request. RESET means that the password must be changed immediately.
        /// </summary>
        public UserStatus? Status { get; private set; }

        /// <summary>
        /// A username containing alphanumerical letters and -,._@+&#x3D; characters.
        /// </summary>
        public string Username { get; set; }
        
        /// <summary>
        /// A flag indicating whether the user&#39;s email address has been verified or not.
        /// </summary>
        public bool? EmailVerified { get; private set; }
        
        /// <summary>
        /// The UUID of the account.
        /// </summary>
        public string AccountId { get; private set; }
        
        /// <summary>
        /// A timestamp of the latest change of the user password, in milliseconds.
        /// </summary>
        public long? PasswordChangedTime { get; private set; }
        
        /// <summary>
        /// A list of IDs of the groups this user belongs to.
        /// </summary>
        public List<string> Groups { get; set; }

        /// <summary>
        /// Creation UTC time RFC3339.
        /// </summary>
        public string CreatedAt { get; private set; }
        
        /// <summary>
        /// A flag indicating that the General Terms and Conditions has been accepted.
        /// </summary>
        public bool? IsGtcAccepted { get; set; }
        
        /// <summary>
        /// The email address.
        /// </summary>
        public string Email { get; set; }
        
        /// <summary>
        /// A flag indicating that receiving marketing information has been accepted.
        /// </summary>
        public bool? IsMarketingAccepted { get; set; }
        
        /// <summary>
        /// API resource entity version.
        /// </summary>
        public string Etag { get; private set; }
        
        /// <summary>
        /// The full name of the user.
        /// </summary>
        public string FullName { get; set; }
        
        /// <summary>
        /// Address.
        /// </summary>
        public string Address { get; set; }
        
        /// <summary>
        /// Gets or Sets CreationTimeMillis
        /// </summary>
        public long? CreationTimeMillis { get; private set; }
        
        /// <summary>
        /// A timestamp of the user creation in the storage, in milliseconds.
        /// </summary>
        public long? CreationTime { get; private set; }
        
        /// <summary>
        /// The password when creating a new user. It will will generated when not present in the request.
        /// </summary>
        public string Password { get; set; }
        
        /// <summary>
        /// Phone number.
        /// </summary>
        public string PhoneNumber { get; set; }
        
        /// <summary>
        /// The UUID of the user.
        /// </summary>
        public string Id { get; private set; }
        
        /// <summary>
        /// A timestamp of the latest login of the user, in milliseconds.
        /// </summary>
        public long? LastLoginTime { get; private set; }

        /// <summary>
        /// Initializes new instance of User class.
        /// </summary>
        /// <param name="options">Dictionary containing properties.</param>
        public User(IDictionary<string, object> options = null)
        {
            if (options != null)
            {
                foreach (KeyValuePair<string, object> item in options)
                {
                    var property = this.GetType().GetProperty(item.Key);
                    if (property != null)
                    {
                        property.SetValue(this, item.Value, null);
                    }
                }
            }
        }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class User {\n");
            sb.Append("  Status: ").Append(Status).Append("\n");
            sb.Append("  Username: ").Append(Username).Append("\n");
            sb.Append("  EmailVerified: ").Append(EmailVerified).Append("\n");
            sb.Append("  AccountId: ").Append(AccountId).Append("\n");
            sb.Append("  PasswordChangedTime: ").Append(PasswordChangedTime).Append("\n");
            sb.Append("  Groups: ").Append(Groups).Append("\n");
            sb.Append("  CreatedAt: ").Append(CreatedAt).Append("\n");
            sb.Append("  IsGtcAccepted: ").Append(IsGtcAccepted).Append("\n");
            sb.Append("  Email: ").Append(Email).Append("\n");
            sb.Append("  IsMarketingAccepted: ").Append(IsMarketingAccepted).Append("\n");
            sb.Append("  Etag: ").Append(Etag).Append("\n");
            sb.Append("  FullName: ").Append(FullName).Append("\n");
            sb.Append("  Address: ").Append(Address).Append("\n");
            sb.Append("  CreationTimeMillis: ").Append(CreationTimeMillis).Append("\n");
            sb.Append("  CreationTime: ").Append(CreationTime).Append("\n");
            sb.Append("  Password: ").Append(Password).Append("\n");
            sb.Append("  PhoneNumber: ").Append(PhoneNumber).Append("\n");
            sb.Append("  Id: ").Append(Id).Append("\n");
            sb.Append("  LastLoginTime: ").Append(LastLoginTime).Append("\n");
            sb.Append("}\n");
            return sb.ToString();
        }

        /// <summary>
        /// Map to User object.
        /// </summary>
        /// <param name="userInfo"></param>
        /// <returns></returns>
        public static User Map(iam.Model.UserInfoResp userInfo)
        {
            var userStatus = (UserStatus)Enum.Parse(typeof(UserStatus), userInfo.Status.ToString());
            User user = new User();
            user.Status = userStatus;
            user.Username = userInfo.Username;
            user.EmailVerified = userInfo.EmailVerified;
            user.AccountId = userInfo.AccountId;
            user.PasswordChangedTime = userInfo.PasswordChangedTime;
            user.Groups = userInfo.Groups;
            user.CreatedAt = userInfo.CreatedAt;
            user.IsGtcAccepted = userInfo.IsGtcAccepted;
            user.Email = userInfo.Email;
            user.IsMarketingAccepted = userInfo.IsMarketingAccepted;
            user.Etag = userInfo.Etag;
            user.FullName = userInfo.FullName;
            user.Address = userInfo.Address;
            user.CreationTimeMillis = userInfo.CreationTimeMillis;
            user.CreationTime = userInfo.CreationTime;
            user.Password = userInfo.Password;
            user.PhoneNumber = userInfo.PhoneNumber;
            user.Id = userInfo.Id;
            user.LastLoginTime = userInfo.LastLoginTime;
            return user; 
        }
    }
}
