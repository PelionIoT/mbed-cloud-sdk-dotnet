using System.Linq;
using MbedCloudSDK.AccountManagement.Model.User;
using MbedCloudSDK.Common.Extensions;

namespace MbedCloudSDK.TagPOC.User
{
    public partial class User
    {
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
                LoginHistory = userInfo?.LoginHistory?.Select(l => { return AccountManagement.Model.User.LoginHistory.Map(l); })?.ToList() ?? Enumerable.Empty<LoginHistory>().ToList()
            };
            return user;
        }
    }
}