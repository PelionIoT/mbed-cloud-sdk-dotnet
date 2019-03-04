using System;
using System.Linq;
using NUnit.Framework;
using MbedCloudSDK.Common.Extensions;
using Mbed.Cloud.Foundation;

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
                var userRepo = new UserRepository();
                var user = userRepo.List().FirstOrDefault();

                Assert.IsInstanceOf(typeof(User), user);

                var gotUser = await userRepo.Read(user.Id);

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
                var user = new UserRepository().List().FirstOrDefault();
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
                var userRepo = new UserRepository();

                var user = new User
                {
                    Username = "alex_ole_ball",
                    Email = "alex_ole_ball@alex.alex",
                    PhoneNumber = "01638742545",
                    FullName = "Alex Logan",
                };

                await userRepo.Create(user);

                user.PhoneNumber = "118118";

                await userRepo.Update(user.Id, user);

                Assert.AreEqual(user.PhoneNumber, "118118");

                await userRepo.Delete(user.Id);
            }
            catch (System.Exception)
            {
                throw;
            }
        }
    }
}