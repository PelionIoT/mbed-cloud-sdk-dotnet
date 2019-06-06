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
                //  an example: creating and managing a subtenant account
                myAccount = await accountRepo.Create(new Account
                {
                    DisplayName = "new test account",
                    Aliases = new List<string>() { "alex_test_account" },
                    EndMarket = "IOT",
                    AdminFullName = "Alex Logan",
                    AdminEmail = "alexadmin@admin.com",
                });
                // cloak
            }
            catch (CloudApiException e) when (e.ErrorCode == 403)
            {
                myAccount = accountRepo.List().FirstOrDefault(a => a.DisplayName == "sdk_test_bob");
            }
            finally
            {
                Assert.IsInstanceOf(typeof(Account), myAccount);
                // uncloak
                var userRepo = new SubtenantUserRepository();

                // get first subtenant user acociated with the account
                var firstUser = accountRepo.Users(myAccount.Id).FirstOrDefault();

                var originalPhoneNumber = firstUser.PhoneNumber;

                var newPhoneNumber = originalPhoneNumber + "00";

                // update the user's phone number
                firstUser.PhoneNumber = newPhoneNumber;
                await userRepo.Update(myAccount.Id, firstUser.Id, firstUser);

                // cloak
                Assert.AreNotEqual(originalPhoneNumber, firstUser.PhoneNumber);
                Assert.AreEqual(newPhoneNumber, firstUser.PhoneNumber);
                // uncloak

                // change it back to the original
                firstUser.PhoneNumber = originalPhoneNumber;
                await userRepo.Update(myAccount.Id, firstUser.Id, firstUser);

                // end of example

                Assert.AreEqual(originalPhoneNumber, firstUser.PhoneNumber);
            }
        }

        private string randomString(int length = 16)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }
    }
}