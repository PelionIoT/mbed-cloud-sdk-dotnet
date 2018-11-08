using System;
using System.Linq;
using MbedCloud.SDK.Entities;
using NUnit.Framework;
using MbedCloudSDK.Common.Extensions;

namespace Snippets.src.Foundation
{
    [TestFixture]
    public class CrudExamples
    {
        [Test]
        public async System.Threading.Tasks.Task UserGetAsync()
        {
            try
            {
                var user = new Account().MyUsers().FirstOrDefault();

                Assert.IsInstanceOf(typeof(User), user);

                var gotUser = await new User
                {
                    Id = user.Id,
                    AccountId = user.AccountId,
                }.Get();

                Assert.IsInstanceOf(typeof(User), gotUser);
                Assert.AreEqual(gotUser.CreatedAt, user.CreatedAt);

                var loginHistory = gotUser.LoginHistory.FirstOrDefault();
                Assert.IsInstanceOf(typeof(LoginHistory), loginHistory);
            }
            catch (System.Exception)
            {
                throw;
            }
        }

        [Test]
        public void UserList()
        {
            try
            {
                var user = new Account().MyUsers().FirstOrDefault();
                Assert.IsInstanceOf(typeof(User), user);
            }
            catch (System.Exception)
            {
                throw;
            }
        }

        [Test]
        public async System.Threading.Tasks.Task PhoneDemoAsync()
        {
            try
            {
                var myAccount = await new Account().Me();

                var user = await new User
                {
                    AccountId = myAccount.Id,
                    Username = "alexcs",
                    Email = "alex@alex.alex",
                    PhoneNumber = "01638742545",
                    FullName = "Alex Logan",
                }.Create();

                user.PhoneNumber = "118118";

                await user.Update();

                Assert.AreEqual(user.PhoneNumber, "118118");

                await user.Delete();
            }
            catch (System.Exception)
            {
                throw;
            }
        }
    }
}