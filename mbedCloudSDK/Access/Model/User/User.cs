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
        /// <value>The status of the user. INVITED means that the user has not accepted the invitation request. RESET means that the password must be changed immediately.</value>
        public UserStatus? Status { get; }

        /// <summary>
        /// A username containing alphanumerical letters and -,._@+&#x3D; characters.
        /// </summary>
        /// <value>A username containing alphanumerical letters and -,._@+&#x3D; characters.</value>
        public string Username { get; set; }
        
        /// <summary>
        /// A flag indicating whether the user&#39;s email address has been verified or not.
        /// </summary>
        /// <value>A flag indicating whether the user&#39;s email address has been verified or not.</value>
        public bool? EmailVerified { get; }
        
        /// <summary>
        /// The UUID of the account.
        /// </summary>
        /// <value>The UUID of the account.</value>
        public string AccountId { get; }
        
        /// <summary>
        /// A timestamp of the latest change of the user password, in milliseconds.
        /// </summary>
        /// <value>A timestamp of the latest change of the user password, in milliseconds.</value>
        public long? PasswordChangedTime { get; }
        
        /// <summary>
        /// A list of IDs of the groups this user belongs to.
        /// </summary>
        /// <value>A list of IDs of the groups this user belongs to.</value>
        public List<string> Groups { get; set; }

        /// <summary>
        /// Creation UTC time RFC3339.
        /// </summary>
        /// <value>Creation UTC time RFC3339.</value>
        public string CreatedAt { get; }
        
        /// <summary>
        /// A flag indicating that the General Terms and Conditions has been accepted.
        /// </summary>
        /// <value>A flag indicating that the General Terms and Conditions has been accepted.</value>
        public bool? IsGtcAccepted { get; set; }
        
        /// <summary>
        /// The email address.
        /// </summary>
        /// <value>The email address.</value>
        public string Email { get; set; }
        
        /// <summary>
        /// A flag indicating that receiving marketing information has been accepted.
        /// </summary>
        /// <value>A flag indicating that receiving marketing information has been accepted.</value>
        public bool? IsMarketingAccepted { get; set; }
        
        /// <summary>
        /// API resource entity version.
        /// </summary>
        /// <value>API resource entity version.</value>
        public string Etag { get; }
        
        /// <summary>
        /// The full name of the user.
        /// </summary>
        /// <value>The full name of the user.</value>
        public string FullName { get; set; }
        
        /// <summary>
        /// Address.
        /// </summary>
        /// <value>Address.</value>
        public string Address { get; set; }
        
        /// <summary>
        /// Gets or Sets CreationTimeMillis
        /// </summary>
        public long? CreationTimeMillis { get; }
        
        /// <summary>
        /// A timestamp of the user creation in the storage, in milliseconds.
        /// </summary>
        /// <value>A timestamp of the user creation in the storage, in milliseconds.</value>
        public long? CreationTime { get; }
        
        /// <summary>
        /// The password when creating a new user. It will will generated when not present in the request.
        /// </summary>
        /// <value>The password when creating a new user. It will will generated when not present in the request.</value>
        public string Password { get; set; }
        
        /// <summary>
        /// Phone number.
        /// </summary>
        /// <value>Phone number.</value>
        public string PhoneNumber { get; set; }
        
        /// <summary>
        /// The UUID of the user.
        /// </summary>
        /// <value>The UUID of the user.</value>
        public string Id { get; }
        
        /// <summary>
        /// A timestamp of the latest login of the user, in milliseconds.
        /// </summary>
        /// <value>A timestamp of the latest login of the user, in milliseconds.</value>
        public long? LastLoginTime { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="User" /> class.
        /// </summary>
        /// <param name="Status">The status of the user. INVITED means that the user has not accepted the invitation request. RESET means that the password must be changed immediately. (required).</param>
        /// <param name="Username">A username containing alphanumerical letters and -,._@+&#x3D; characters. (required).</param>
        /// <param name="EmailVerified">A flag indicating whether the user&#39;s email address has been verified or not. (default to false).</param>
        /// <param name="AccountId">The UUID of the account. (required).</param>
        /// <param name="PasswordChangedTime">A timestamp of the latest change of the user password, in milliseconds..</param>
        /// <param name="Groups">A list of IDs of the groups this user belongs to..</param>
        /// <param name="CreatedAt">Creation UTC time RFC3339..</param>
        /// <param name="IsGtcAccepted">A flag indicating that the General Terms and Conditions has been accepted. (default to false).</param>
        /// <param name="Email">The email address. (required).</param>
        /// <param name="IsMarketingAccepted">A flag indicating that receiving marketing information has been accepted. (default to false).</param>
        /// <param name="Etag">API resource entity version. (required).</param>
        /// <param name="FullName">The full name of the user..</param>
        /// <param name="Address">Address..</param>
        /// <param name="CreationTimeMillis">CreationTimeMillis.</param>
        /// <param name="CreationTime">A timestamp of the user creation in the storage, in milliseconds..</param>
        /// <param name="Password">The password when creating a new user. It will will generated when not present in the request..</param>
        /// <param name="PhoneNumber">Phone number..</param>
        /// <param name="Id">The UUID of the user. (required).</param>
        /// <param name="LastLoginTime">A timestamp of the latest login of the user, in milliseconds..</param>
        public User(UserStatus? Status = null, string Username = null, bool? EmailVerified = null, string AccountId = null, long? PasswordChangedTime = null, List<string> Groups = null, string CreatedAt = null, bool? IsGtcAccepted = null, string Email = null, bool? IsMarketingAccepted = null, string Etag = null, string FullName = null, string Address = null, long? CreationTimeMillis = null, long? CreationTime = null, string Password = null, string PhoneNumber = null, string Id = null, long? LastLoginTime = null)
        {
            this.Status = Status;
            this.Username = Username;
            this.AccountId = AccountId;
            this.Email = Email;
            this.Etag = Etag;
            this.Id = Id;
            this.EmailVerified = false;
            this.PasswordChangedTime = PasswordChangedTime;
            this.Groups = Groups;
            this.CreatedAt = CreatedAt;
            // use default value if no "IsGtcAccepted" provided
            if (IsGtcAccepted == null)
            {
                this.IsGtcAccepted = false;
            }
            else
            {
                this.IsGtcAccepted = IsGtcAccepted;
            }
            // use default value if no "IsMarketingAccepted" provided
            if (IsMarketingAccepted == null)
            {
                this.IsMarketingAccepted = false;
            }
            else
            {
                this.IsMarketingAccepted = IsMarketingAccepted;
            }
            this.FullName = FullName;
            this.Address = Address;
            this.CreationTimeMillis = CreationTimeMillis;
            this.CreationTime = CreationTime;
            this.Password = Password;
            this.PhoneNumber = PhoneNumber;
            this.LastLoginTime = LastLoginTime;
        }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class UserInfoResp {\n");
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

        public static User Convert(iam.Model.UserInfoResp userInfo)
        {
            var userStatus = (UserStatus)Enum.Parse(typeof(UserStatus), userInfo.Status.ToString());
            return new User(userStatus, userInfo.Username, userInfo.EmailVerified, userInfo.AccountId, userInfo.PasswordChangedTime,
                userInfo.Groups, userInfo.CreatedAt, userInfo.IsGtcAccepted, userInfo.Email, userInfo.IsMarketingAccepted, userInfo.Etag,
                userInfo.FullName, userInfo.Address, userInfo.CreationTimeMillis, userInfo.CreationTime, userInfo.Password, userInfo.PhoneNumber,
                userInfo.Id, userInfo.LastLoginTime);
        }
    }
}
