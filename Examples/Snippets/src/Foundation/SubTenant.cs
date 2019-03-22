using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Mbed.Cloud.Foundation;
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
            var accountRepo = new AccountRepository();
            Account myAccount = null;
            try
            {
                myAccount = await accountRepo.Create(new Account
                {
                    DisplayName = "new test account",
                    Aliases = new List<string>() { "alex_test_account" },
                    EndMarket = "IOT",
                    AdminFullName = "Alex Logan",
                    AdminEmail = "alexadmin@admin.com",
                });
            }
            catch (CloudApiException e) when (e.ErrorCode == 403)
            {
                myAccount = accountRepo.List().FirstOrDefault(a => a.DisplayName == "sdk_test_bob");
            }
            finally
            {
                Assert.IsInstanceOf(typeof(Account), myAccount);
                var userRepo = new SubtenantUserRepository();

                // get first subtenant user acociated with the account
                var firstUser = accountRepo.Users(myAccount.Id).FirstOrDefault();

                var originalPhoneNumber = firstUser.PhoneNumber;

                var newPhoneNumber = originalPhoneNumber + "00";

                // update the user's phone number
                firstUser.PhoneNumber = newPhoneNumber;
                await userRepo.Update(myAccount.Id, firstUser.Id, firstUser);

                Assert.AreNotEqual(originalPhoneNumber, firstUser.PhoneNumber);
                Assert.AreEqual(newPhoneNumber, firstUser.PhoneNumber);

                // change it back to the original
                firstUser.PhoneNumber = originalPhoneNumber;
                await userRepo.Update(myAccount.Id, firstUser.Id, firstUser);

                Assert.AreEqual(originalPhoneNumber, firstUser.PhoneNumber);
            }
        }

        [Test]
        public async Task SubTenantFlow()
        {
            var accountRepo = new AccountRepository();
            Account myAccount = null;
            try
            {
                myAccount = await accountRepo.Create(new Account
                {
                    DisplayName = "new test account",
                    Aliases = new List<string>() { "alex_test_account" },
                    EndMarket = "IOT",
                    AdminFullName = "Alex Logan",
                    AdminEmail = "alexadmin@admin.com",
                });
            }
            catch (CloudApiException e) when (e.ErrorCode == 403)
            {
                myAccount = accountRepo.List().FirstOrDefault(a => a.DisplayName == "sdk_test_bob");
            }
            finally
            {
                var userRepo = new SubtenantUserRepository();
                // Populate the new user details
                // create the user
                var user = await userRepo.Create(myAccount.Id, new SubtenantUser
                {
                    // Link this user to the account
                    AccountId = myAccount.Id,
                    FullName = "tommi the wombat",
                    Username = $"tommi_{randomString()}",
                    PhoneNumber = "0800001066",
                    Email = $"tommi_{randomString()}@example.com",
                });

                // end of example
                Assert.IsInstanceOf(typeof(SubtenantUser), user);
                Assert.IsNotNull(user.CreatedAt);

                // created user is now in account user list
                var userInList = accountRepo.Users(myAccount.Id).FirstOrDefault(u => u.Id == user.Id);

                Assert.IsInstanceOf(typeof(SubtenantUser), userInList);
                Assert.AreEqual(user.CreatedAt, userInList.CreatedAt);

                // delete the user
                await userRepo.Delete(myAccount.Id, user.Id);
            }
        }

        [Test]
        public async Task AccountLists()
        {
            var accountRepo = new AccountRepository();
            var myAccount = await accountRepo.Me();

            var user = accountRepo.Users(myAccount.Id).FirstOrDefault();
            if (user != null)
            {
                Assert.IsInstanceOf(typeof(SubtenantUser), user);
            }

            var trustedCert = accountRepo.TrustedCertificates(myAccount.Id)?.FirstOrDefault();
            if (trustedCert != null)
            {
                Assert.IsInstanceOf(typeof(SubtenantTrustedCertificate), trustedCert);
            }

            var invitation = accountRepo.UserInvitations(myAccount.Id)?.FirstOrDefault();
            if (invitation != null)
            {
                Assert.IsInstanceOf(typeof(SubtenantUserInvitation), invitation);
            }
        }

        [Test]
        public void AccountPasswordPolicies()
        {
            new AccountRepository().List().All().ForEach(a =>
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