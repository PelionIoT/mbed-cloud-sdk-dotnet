// <copyright file="AccountManagementApi.Account.cs" company="Arm">
// Copyright (c) Arm. All rights reserved.
// </copyright>

namespace MbedCloudSDK.AccountManagement.Api
{
    using System.Threading.Tasks;
    using iam.Client;
    using MbedCloudSDK.AccountManagement.Model.Account;
    using MbedCloudSDK.Exceptions;

    /// <summary>
    /// Account Management Api
    /// </summary>
    public partial class AccountManagementApi
    {
        /// <summary>
        /// Get details of account associated with current API key
        /// </summary>
        /// <example>
        /// This example shows how to use the <see cref="AccountManagementApi.GetAccount"/> method.
        /// <code>
        /// using MbedCloudSDK.AccountManagement.Model.Account;
        /// using MbedCloudSDK.Exceptions;
        /// try
        /// {
        ///     var account = accountApi.GetAccount();
        ///     return account;
        /// }
        /// catch (CloudApiException e)
        /// {
        ///     throw e;
        /// }
        /// </code>
        /// </example>
        /// <returns><see cref="Account"/></returns>
        public Account GetAccount()
        {
            try
            {
                var account = developerApi.GetMyAccountInfo("limits, policies");
                return Account.Map(account);
            }
            catch (ApiException e)
            {
                throw new CloudApiException(e.ErrorCode, e.Message, e.ErrorContent);
            }
        }

        /// <summary>
        /// Get details of account associated with current API key asynchronously.
        /// </summary>
        /// <example>
        /// This example shows how to use the <see cref="AccountManagementApi.GetAccountAsync"/> method.
        /// <code>
        /// using MbedCloudSDK.AccountManagement.Model.Account;
        /// using MbedCloudSDK.Exceptions;
        /// try
        /// {
        ///     var account = await accountApi.GetAccountAsync();
        ///     return account;
        /// }
        /// catch (CloudApiException e)
        /// {
        ///     throw e;
        /// }
        /// </code>
        /// </example>
        /// <returns><see cref="Task"/> with an <see cref="Account"/></returns>
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
        /// Update details of account associated with current API key.
        /// </summary>
        /// <param name="account"><see cref="Account"/> with updated info.</param>
        /// <example>
        /// This example shows how to use the <see cref="AccountManagementApi.UpdateAccount"/> method.
        /// <code>
        /// try
        /// {
        ///     var account = new Account
        ///     {
        ///         state = "New York",
        ///         city = "New York",
        ///         country = "USA",
        ///     };
        ///     var updatedAccount = api.UpdateAccount(account);
        ///     return updatedAccount;
        /// }
        /// catch (CloudApiException e)
        /// {
        ///     throw e;
        /// }
        /// </code>
        /// </example>
        /// <returns><see cref="Account"/></returns>
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
        /// Update details of account associated with current API key asynchronously.
        /// </summary>
        /// <param name="account"><see cref="Account"/> with updated info.</param>
        /// <example>
        /// This example shows how to use the <see cref="AccountManagementApi.UpdateAccountAsync"/> method.
        /// <code>
        /// try
        /// {
        ///     var account = new Account
        ///     {
        ///         state = "New York",
        ///         city = "New York",
        ///         country = "USA",
        ///     };
        ///     var updatedAccount = api.UpdateAccount(account);
        ///     return updatedAccount;
        /// }
        /// catch (CloudApiException e)
        /// {
        ///     throw e;
        /// }
        /// </code>
        /// </example>
        /// <returns><see cref="Task"/> with <see cref="Account"/></returns>
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