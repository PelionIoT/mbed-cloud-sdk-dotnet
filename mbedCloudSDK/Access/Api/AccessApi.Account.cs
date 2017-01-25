using iam.Api;
using iam.Client;
using iam.Model;
using mbedCloudSDK.Access.Model.Account;
using mbedCloudSDK.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mbedCloudSDK.Access.Api
{
    public partial class AccessApi
    {
        /// <summary>
        /// Get account info.
        /// </summary>
        /// <returns></returns>
        public Account GetAccount()
        {
            try
            {
                var account = developerApi.GetMyAccountInfo();
                return Account.Map(account);
            }
            catch (ApiException e)
            {
                throw new CloudApiException(e.ErrorCode, e.Message, e.ErrorContent);
            }
        }

        /// <summary>
        /// Get account info asynchronously.
        /// </summary>
        /// <returns></returns>
        public async Task<Account> GetAccountAsync()
        {
            try
            {
                var account = await developerApi.GetMyAccountInfoAsync();
                return Account.Map(account);
            }
            catch (ApiException e)
            {
                throw new CloudApiException(e.ErrorCode, e.Message, e.ErrorContent);
            }
        }

        /// <summary>
        /// Update account.
        /// </summary>
        /// <param name="account">Updated account info.</param>
        /// <returns></returns>
        public Account UpdateAccount(Account account)
        {
            // Create Account request
            AccountUpdateReq req = new AccountUpdateReq(account.AddressLine2, account.City, account.AddressLine1,
                account.DisplayName, account.Country, account.Company, account.State, account.Contact,
                account.PostalCode, null, account.PhoneNumber, account.Email, account.Aliases);
            try
            {
                var accountInfo = adminApi.UpdateMyAccount(req);
                return Account.Map(accountInfo);
            }
            catch (ApiException e)
            {
                throw new CloudApiException(e.ErrorCode, e.Message, e.ErrorContent);
            }
        }

        /// <summary>
        /// Update account asynchronously.
        /// </summary>
        /// <param name="account">Updated account info.</param>
        /// <returns></returns>
        public async Task<Account> UpdateAccountAsync(Account account)
        {
            // Create account update request
            AccountUpdateReq req = new AccountUpdateReq(account.AddressLine2, account.City, account.AddressLine1,
                account.DisplayName, account.Country, account.Company, account.State, account.Contact, account.PostalCode,
                null, account.PhoneNumber, account.Email, account.Aliases);
            try
            {
                var accountInfo = await adminApi.UpdateMyAccountAsync(req);
                return Account.Map(accountInfo);
            }
            catch (ApiException e)
            {
                throw new CloudApiException(e.ErrorCode, e.Message, e.ErrorContent);
            }
        }
    }
}
