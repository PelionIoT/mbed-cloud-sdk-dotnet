using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MbedCloud.SDK.Common;
using MbedCloud.SDK.Entities;
using MbedCloudSDK.Exceptions;
using NUnit.Framework;

namespace Snippets.src.Foundation
{
    [TestFixture]
    public class SubTenant
    {
        private static Random random = new Random();

        [Test]
        public async Task UpdateUserAsSubtenant()
        {
            Account myAccount = null;
            try
            {
                myAccount = await new Account
                {
                    DisplayName = "new test account",
                    Aliases = new List<string>() { "alex_test_account" },
                    EndMarket = "IOT",
                    AdminFullName = "Alex Logan",
                    AdminEmail = "alexadmin@admin.com",
                }.Create();
            }
            catch (CloudApiException e) when (e.ErrorCode == 403)
            {
                // get an admin account
                myAccount = new Account().List().FirstOrDefault(a => a.DisplayName == "sdk_test_bob");
            }
            finally
            {
                Assert.IsInstanceOf(typeof(Account), myAccount);

                // get first subtenant user acociated with the account
                var firstUser = myAccount.Users().FirstOrDefault();

                var phoneNumber = firstUser.PhoneNumber;

                // update the user's phone number
                firstUser.PhoneNumber = "117117";
                await firstUser.Update();

                Assert.AreNotEqual(phoneNumber, firstUser.PhoneNumber);
                Assert.AreEqual("117117", firstUser.PhoneNumber);

                // change it back to the original
                firstUser.PhoneNumber = phoneNumber;
                await firstUser.Update();

                Assert.AreNotEqual("117117", firstUser.PhoneNumber);
            }
        }

        [Test]
        public async Task SubTenantFlow()
        {
            try
            {
                // gat an admin account
                var myAccount = new Account().List().FirstOrDefault(a => a.DisplayName == "sdk_test_bob");

                // get all users acociated with the account
                var users = myAccount.Users().All();
                Assert.GreaterOrEqual(users.Count, 1);

                // add a user to account
                var user = await new SubtenantUser
                {
                    AccountId = myAccount.Id,
                    FullName = "tommi the wombat",
                    Username = $"tommi_{randomString()}",
                    PhoneNumber = "0800001066",
                    Email = $"tommi_{randomString()}@example.com",
                }.Create();

                Assert.IsInstanceOf(typeof(SubtenantUser), user);
                Assert.IsNotNull(user.CreatedAt);

                // created user is now in account user list
                var userInList = myAccount.Users().FirstOrDefault(u => u.Id == user.Id);

                Assert.IsInstanceOf(typeof(SubtenantUser), userInList);
                Assert.AreEqual(user.CreatedAt, userInList.CreatedAt);

                // update the user's phone number
                user.PhoneNumber = "118118";
                await user.Update();

                Assert.AreEqual("118118", user.PhoneNumber);

                // delete the user
                await user.Delete();
            }
            catch (System.Exception)
            {
                throw;
            }
        }

        [Test]
        public async Task AccountLists()
        {
            var myAccount = await new Account().Me();

            var user = myAccount.Users().First();
            if (user != null)
            {
                Assert.IsInstanceOf(typeof(SubtenantUser), user);
            }

            var trustedCert = myAccount.TrustedCertificates().First();
            if (trustedCert != null)
            {
                Assert.IsInstanceOf(typeof(SubtenantTrustedCertificate), trustedCert);
            }

            var invitation = myAccount.UserInvitations().First();
            if (invitation != null)
            {
                Assert.IsInstanceOf(typeof(SubtenantUserInvitation), invitation);
            }
        }

        [Test]
        public void AccountPasswordPolicies()
        {
            new Account().List().All().ForEach(a =>
            {
                if (a.PasswordPolicy != null)
                {
                    Assert.IsInstanceOf(typeof(PasswordPolicy), a.PasswordPolicy);
                }
            });
        }

        private string randomString(int length = 16)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }
    }
}