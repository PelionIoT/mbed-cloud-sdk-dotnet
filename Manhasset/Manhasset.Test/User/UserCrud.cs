using NUnit.Framework;
using MbedCloudSDK.Accounts.User;
using System.Linq;

namespace Manhasset.Test.User
{
    [TestFixture]
    public class UserCrud
    {
        [Test]
        public void UserCrudPhoneNumber()
        {
            var user = MbedCloudSDK.Accounts.User.User.List().FirstOrDefault();

            Assert.IsInstanceOf(typeof(MbedCloudSDK.Accounts.User.User), user, "First item in list of users in not a User.");

            Assert.NotNull(typeof(string), user.PhoneNumber, "Phone number doesn not exist on the user");

            
        }
    }
}