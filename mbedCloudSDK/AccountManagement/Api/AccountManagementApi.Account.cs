using iam.Client;
using iam.Model;
using MbedCloudSDK.AccountManagement.Model.Account;
using MbedCloudSDK.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MbedCloudSDK.AccountManagement.Api
{
    public partial class AccountManagementApi
    {
        /// <summary>
        /// Get account info.
        /// </summary>
        /// <returns></returns>
        public Account GetAccount()
        {
            try
            {
                // Get account information including limits and policies
                var account = developerApi.GetMyAccountInfo("limits, policies");
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
            var req = account.CreateUpdateRequest();
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
            var req = account.CreateUpdateRequest();
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
