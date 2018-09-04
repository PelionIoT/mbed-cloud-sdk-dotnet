using System;
using System.Linq;
using System.Threading.Tasks;
using MbedCloudSDK.Accounts.MyAccount;
using NUnit.Framework;

namespace Manhasset.Test
{
    [TestFixture]
    public class AccountCrud
    {
        [Test]
        public async Task CrudSequence()
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