using NUnit.Framework;
using MbedCloudSDK.Entities.User;
using System.Linq;
using System;
using System.Threading.Tasks;
using MbedCloudSDK.Entities.PolicyGroup;
using System.Collections.Generic;
using MbedCloudSDK.Common.Extensions;
using MbedCloudSDK.Common;

namespace Manhasset.Test
{
    [TestFixture]
    public class UserCrud
    {
        private User createdUser;

        private User NewUser()
        {
            return new User
            {
                Username = "noalgalex",
                FullName = "Alex Logan",
                Email = "alextester@gmail.com",
                PhoneNumber = "0800001066",
            };
        }

        [TearDown]
        public async Task TearDown()
        {
            if (createdUser != null)
            {
                await createdUser.Delete();
            }
        }

        [Test]
        public async Task CrudSequence()
        {
            var group = new PolicyGroup().List().FirstOrDefault();

            var newUser = NewUser();

            newUser.GroupIds = new List<string>() { group.Id };

            await newUser.Create();

            createdUser = newUser;

            Assert.AreEqual("0800001066", newUser.PhoneNumber);

            var getUser = await new User { Id = newUser.Id }.Get();

            // Assert.AreEqual(newUser.Id, getUser.Id);

            // var newNumber = "118118";

            // newUser.PhoneNumber = newNumber;

            // await newUser.Update();

            // Assert.AreEqual("118118", newUser.PhoneNumber);

            Assert.GreaterOrEqual(newUser?.GroupIds?.Count, 1);

            var allUsers = new User().List();

            var found = allUsers.FirstOrDefault(u => u.Id == newUser.Id);

            Assert.AreEqual(newUser.Id, found.Id);

            foreach (var user in allUsers)
            {
                if (user?.LoginHistory?.Any() == true)
                {
                    var history = user?.LoginHistory?.FirstOrDefault();
                    Assert.IsInstanceOf(typeof(DateTime), history?.Date);
                }
            }

            var myGroups = newUser.Groups();
            foreach (var item in myGroups)
            {
                Assert.GreaterOrEqual(item.UserCount, 1);
            }
        }
    }
}