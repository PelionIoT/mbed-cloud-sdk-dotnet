// <copyright file="User.cs" company="Arm">
// Copyright (c) Arm. All rights reserved.
// </copyright>

namespace MbedCloudSDK.AccountManagement.Model.User
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Mbed.Cloud.Common;
    using MbedCloudSDK.Common;
    using MbedCloudSDK.Common.Extensions;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    /// <summary>
    /// This object represents a user in Mbed Cloud.
    /// </summary>
    public class User : Entity
    {
        /// <summary>
        /// Gets the status of the user. INVITED means that the user has not accepted the invitation request. RESET means that the password must be changed immediately.
        /// </summary>
        [JsonConverter(typeof(StringEnumConverter))]
        [JsonProperty]
        public UserStatus? Status { get; private set; }

        /// <summary>
        /// Gets or sets a username containing alphanumerical letters and -,._@+&#x3D; characters.
        /// </summary>
        public string Username { get; set; }

        /// <summary>
        /// Gets a flag indicating whether the user&#39;s email address has been verified or not.
        /// </summary>
        [JsonProperty]
        public bool? EmailVerified { get; private set; }

        /// <summary>
        /// Gets the UUID of the account.
        /// </summary>
        [JsonProperty]
        public string AccountId { get; private set; }

        /// <summary>
        /// Gets a timestamp of the latest change of the user password, in milliseconds.
        /// </summary>
        [JsonProperty]
        public long? PasswordChangedTime { get; private set; }

        /// <summary>
        /// Gets a list of IDs of the groups this user belongs to.
        /// </summary>
        [JsonProperty]
        public List<string> Groups { get; private set; }

        /// <summary>
        /// Gets creation UTC time RFC3339.
        /// </summary>
        [JsonProperty]
        public DateTime? CreatedAt { get; private set; }

        /// <summary>
        /// Gets or sets a flag indicating that the General Terms and Conditions has been accepted.
        /// </summary>
        public bool? TermsAccepted { get; set; }

        /// <summary>
        /// Gets or sets the email address.
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Gets or sets a flag indicating that receiving marketing information has been accepted.
        /// </summary>
        public bool? MarketingAccepted { get; set; }

        /// <summary>
        /// Gets or sets the full name of the user.
        /// </summary>
        public string FullName { get; set; }

        /// <summary>
        /// Gets or sets address.
        /// </summary>
        public string Address { get; set; }

        /// <summary>
        /// Gets a timestamp of the user creation in the storage, in milliseconds.
        /// </summary>
        [JsonProperty]
        public long? CreationTime { get; private set; }

        /// <summary>
        /// Gets or sets the password when creating a new user. It will be generated when not present in the request.
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// Gets or sets phone number.
        /// </summary>
        public string PhoneNumber { get; set; }

        /// <summary>
        /// Gets a timestamp of the latest login of the user, in milliseconds.
        /// </summary>
        [JsonProperty]
        public long? LastLoginTime { get; private set; }

        /// <summary>
        /// Gets whether two factor authentication has been enabled for this user.
        /// </summary>
        [JsonProperty]
        public bool? TwoFactorAuthentication { get; private set; }

        /// <summary>
        /// Gets history of logins for this user.
        /// </summary>
        [JsonProperty]
        public List<LoginHistory> LoginHistory { get; private set; }

        /// <summary>
        /// Map to User object.
        /// </summary>
        /// <param name="userInfo">Iam user object</param>
        /// <returns>User</returns>
        public static User Map(iam.Model.UserInfoResp userInfo)
        {
            var userStatus = userInfo.Status.ParseEnum<UserStatus>();
            var user = new User
            {
                Status = userStatus,
                Username = userInfo.Username,
                EmailVerified = userInfo.EmailVerified,
                AccountId = userInfo.AccountId,
                PasswordChangedTime = userInfo.PasswordChangedTime,
                Groups = userInfo.Groups ?? Enumerable.Empty<string>().ToList(),
                CreatedAt = userInfo.CreatedAt.ToNullableUniversalTime(),
                TermsAccepted = userInfo.IsGtcAccepted,
                Email = userInfo.Email,
                MarketingAccepted = userInfo.IsMarketingAccepted,
                FullName = userInfo.FullName,
                Address = userInfo.Address,
                CreationTime = userInfo.CreationTime,
                Password = userInfo.Password,
                PhoneNumber = userInfo.PhoneNumber,
                Id = userInfo.Id,
                LastLoginTime = userInfo.LastLoginTime,
                TwoFactorAuthentication = userInfo.IsTotpEnabled,
                LoginHistory = userInfo?.LoginHistory?.Select(l => { return Model.User.LoginHistory.Map(l); })?.ToList() ?? Enumerable.Empty<LoginHistory>().ToList()
            };
            return user;
        }

        /// <summary>
        /// Returns the string presentation of the object.
        /// </summary>
        /// <returns>String presentation of the object.</returns>
        public override string ToString()
            => this.DebugDump();

        /// <summary>
        /// Create post request
        /// </summary>
        /// <returns>User info request</returns>
        public iam.Model.UserInfoReq CreatePostRequest()
        {
            var request = new iam.Model.UserInfoReq(Email: Email)
            {
                Username = Username,
                FullName = FullName,
                Address = Address,
                Password = Password,
                PhoneNumber = PhoneNumber,
                IsGtcAccepted = TermsAccepted,
                IsMarketingAccepted = MarketingAccepted,
                Groups = Groups,
            };
            return request;
        }

        /// <summary>
        /// Create put request
        /// </summary>
        /// <returns>User info request</returns>
        public iam.Model.UserUpdateReq CreatePutRequest()
        {
            var request = new iam.Model.UserUpdateReq
            {
                Email = Email,
                PhoneNumber = PhoneNumber,
                Username = Username,
                IsGtcAccepted = TermsAccepted,
                FullName = FullName,
                Address = Address,
                IsMarketingAccepted = MarketingAccepted,
                IsTotpEnabled = TwoFactorAuthentication,
                Status = Convert.ToString(Status)?.GetEnumMemberValue(typeof(UserStatus)),
                Groups = Groups,
            };

            return request;
        }
    }
}