using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MbedCloudSDK.Entities.ApiKey;
using MbedCloudSDK.Entities.MyAccount;
using MbedCloudSDK.Entities.User;
using MbedCloudSDK.Common;
using NUnit.Framework;
using System;

namespace Snippets.src.Foundation
{
    [TestFixture]
    public class EntityExamples
    {
        [Test]
        public async Task Quick()
        {
            // an example: checking account status
            var myAccount = await new MyAccount().Get();
            var isActive = myAccount.Status == MyAccountStatusEnum.ACTIVE;
            // end of example

            Assert.IsTrue(isActive);
        }

        [Test]
        public void Listing()
        {
            // an example: listing api keys
            var allKeys = new ApiKey().List();
            var allKeyNames = allKeys.Select(k => k.Name);
            // end of example

            Assert.GreaterOrEqual(allKeyNames.Count(), 1);
        }

        [Test]
        public async Task AccountCrudSequence()
        {
            var myAccount = await new MyAccount().Get();
            var isActive = myAccount.Status;
            Assert.AreEqual(MyAccountStatusEnum.ACTIVE, isActive);

            var newAddress = GetRandonAddress();

            myAccount.AddressLine1 = newAddress;
            await myAccount.Update();

            Assert.AreEqual(newAddress, myAccount.AddressLine1);
        }

        private string GetRandonAddress()
        {
            var random = new Random();
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, 12)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }
    }
}