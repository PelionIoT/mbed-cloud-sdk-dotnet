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
                var user = new User().List().FirstOrDefault();

                Assert.IsInstanceOf(typeof(User), user);

                var gotUser = await new User
                {
                    Id = user.Id,
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
                var user = new User().List().FirstOrDefault();
                Assert.IsInstanceOf(typeof(User), user);
            }
            catch (System.Exception)
            {
                throw;
            }
        }

        [Test]
        public async System.Threading.Tasks.Task UserListForeignKeyAsync()
        {
            try
            {
                var groups = new PolicyGroup().List().All();

                var user = new User().List().FirstOrDefault();

                var newGroup = groups.FirstOrDefault(g => user.GroupIds != null ? user.GroupIds.Any(f => f == g.Id) : false);

                if (newGroup != null)
                {
                    user.GroupIds.Add(newGroup.Id);
                    await user.Update();

                    var userGroupIds = user.Groups().All().Select(g => g.Id).ToList();

                    Assert.Contains(newGroup.Id, userGroupIds);
                }
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
                var user = await new User
                {
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