// <copyright file="AccountManagementExamples.GetAccount.cs" company="Arm">
// Copyright (c) Arm. All rights reserved.
// </copyright>

namespace ConsoleExamples.Examples.AccountManagement
{
    using System;
    using System.Threading.Tasks;
    using MbedCloudSDK.AccountManagement.Api;
    using MbedCloudSDK.AccountManagement.Model.Account;
    using MbedCloudSDK.Common;

    /// <summary>
    /// Account managment examples
    /// </summary>
    public partial class AccountManagementExamples
    {
        private AccountManagementApi api;
        private Config config;

        /// <summary>
        /// Initializes a new instance of the <see cref="AccountManagementExamples"/> class.
        /// </summary>
        /// <param name="config">Config</param>
        public AccountManagementExamples(Config config)
        {
            this.config = config;
            api = new AccountManagementApi(this.config);
        }

        /// <summary>
        /// Gets details of the account asociated with this api key
        /// </summary>
        /// <returns>An Account object</returns>
        public Account GetAccountDetails()
        {
            var account = api.GetAccount();
            Console.WriteLine(account);
            return account;
        }

        /// <summary>
        /// Gets the account details asyncronously
        /// </summary>
        /// <returns>A task with the account object</returns>
        public async Task<Account> GetAccountDetailsAsync()
        {
            var account = await api.GetAccountAsync();
            Console.WriteLine(account);
            return account;
        }

        /// <summary>
        /// Update an account
        /// </summary>
        /// <returns>Account</returns>
        public Account UpdateAccount()
        {
            var account = new Account
            {
                State = "New York",
                City = "New York",
                Country = "USA",
            };
            var updatedAccount = api.UpdateAccount(account);
            Console.WriteLine(updatedAccount);
            return updatedAccount;
        }

        /// <summary>
        /// Update an account async
        /// </summary>
        /// <returns>Account</returns>
        public async Task<Account> UpdateAccountAsync()
        {
            var account = new Account
            {
                State = "New York",
                City = "New York",
                Country = "USA",
            };
            var updatedAccount = await api.UpdateAccountAsync(account);
            Console.WriteLine(updatedAccount);
            return updatedAccount;
        }
    }
}