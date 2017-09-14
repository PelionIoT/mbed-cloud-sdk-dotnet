using MbedCloudSDK.Common;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Text;

namespace MbedCloudSDK.AccountManagement.Model.User
{
    /// <summary>
    /// This object represents a user in mbed Cloud.
    /// </summary>
    public class User
    {

        /// <summary>
        /// The status of the user. INVITED means that the user has not accepted the invitation request. RESET means that the password must be changed immediately.
        /// </summary>
        [JsonConverter(typeof(StringEnumConverter))]
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
        public DateTime? CreatedAt { get; private set; }
        
        /// <summary>
        /// A flag indicating that the General Terms and Conditions has been accepted.
        /// </summary>
        public bool? TermsAccepted { get; set; }
        
        /// <summary>
        /// The email address.
        /// </summary>
        public string Email { get; set; }
        
        /// <summary>
        /// A flag indicating that receiving marketing information has been accepted.
        /// </summary>
        public bool? MarketingAccepted { get; set; }
        
        /// <summary>
        /// The full name of the user.
        /// </summary>
        public string FullName { get; set; }
        
        /// <summary>
        /// Address.
        /// </summary>
        public string Address { get; set; }
        
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
        [NameOverride(Name = "UserId")]
        [JsonProperty]
        public string Id { get; private set; }
        
        /// <summary>
        /// A timestamp of the latest login of the user, in milliseconds.
        /// </summary>
        public long? LastLoginTime { get; private set; }

        /// <summary>
        /// Whether two factor authentication has been enabled for this user.
        /// </summary>
        public bool? TwoFactorAuthentication { get; private set; }

        /// <summary>
        /// History of logins for this user.
        /// </summary>
        private List<LoginHistory> LoginHistory;

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
            sb.Append("  FullName: ").Append(FullName).Append("\n");
            sb.Append("  Username: ").Append(Username).Append("\n");
            sb.Append("  Password: ").Append(Password).Append("\n");
            sb.Append("  Email: ").Append(Email).Append("\n");
            sb.Append("  PhoneNumber: ").Append(PhoneNumber).Append("\n");
            sb.Append("  Address: ").Append(Address).Append("\n");
            sb.Append("  TermsAccepted: ").Append(TermsAccepted).Append("\n");
            sb.Append("  MarketingAccepted: ").Append(MarketingAccepted).Append("\n");
            sb.Append("  Groups: ").Append(Groups).Append("\n");
            sb.Append("  Id: ").Append(Id).Append("\n");
            sb.Append("  Status: ").Append(Status).Append("\n");
            sb.Append("  AccountId: ").Append(AccountId).Append("\n");
            sb.Append("  EmailVerified: ").Append(EmailVerified).Append("\n");
            sb.Append("  CreatedAt: ").Append(CreatedAt).Append("\n");
            sb.Append("  CreationTime: ").Append(CreationTime).Append("\n");
            sb.Append("  PasswordChangedTime: ").Append(PasswordChangedTime).Append("\n");
            sb.Append("  TwoFactorAuthentication: ").Append(TwoFactorAuthentication).Append("\n");            
            sb.Append("  LastLoginTime: ").Append(LastLoginTime).Append("\n");
            sb.Append("  loginHistory: ").Append(LoginHistory).Append("\n");
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
            user.TermsAccepted = userInfo.IsGtcAccepted;
            user.Email = userInfo.Email;
            user.MarketingAccepted = userInfo.IsMarketingAccepted;
            user.FullName = userInfo.FullName;
            user.Address = userInfo.Address;
            user.CreationTime = userInfo.CreationTime;
            user.Password = userInfo.Password;
            user.PhoneNumber = userInfo.PhoneNumber;
            user.Id = userInfo.Id;
            user.LastLoginTime = userInfo.LastLoginTime;
            user.TwoFactorAuthentication = userInfo.IsTotpEnabled;
            user.LoginHistory = Model.User.LoginHistory.MapList(userInfo.LoginHistory);
            return user; 
        }

        public iam.Model.UserInfoReq CreatePostRequest()
        {
            iam.Model.UserInfoReq request = new iam.Model.UserInfoReq(Email:Email);
            request.Username = this.Username;
            request.FullName = this.FullName;
            request.Address = this.Address;
            request.Password = this.Password;
            request.PhoneNumber = this.PhoneNumber;
            request.IsGtcAccepted = this.TermsAccepted;
            request.IsMarketingAccepted = this.MarketingAccepted;
            return request;
        }

        public iam.Model.UserUpdateReq CreatePutRequest()
        {
            iam.Model.UserUpdateReq request = new iam.Model.UserUpdateReq(Email:Email){
                PhoneNumber = PhoneNumber,
                Username = Username,
                IsGtcAccepted = TermsAccepted,
                FullName = FullName,
                Address = Address,
                IsMarketingAccepted = MarketingAccepted,
                Password = Password
            };
                                                                            
            return request;
        }
    }
}
