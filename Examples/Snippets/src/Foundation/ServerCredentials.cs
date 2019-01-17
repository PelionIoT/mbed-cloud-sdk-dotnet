using System.Threading.Tasks;
using Mbed.Cloud.Foundation.Entities;
using NUnit.Framework;

namespace Snippets.src.Foundation
{
    [TestFixture]
    public class ServerCredentialsTests
    {
        [Test]
        public async Task GetLwm2mCredentials()
        {
            var credentials = await new ServerCredentialsRepository().GetLwm2m();
            Assert.IsInstanceOf(typeof(ServerCredentials), credentials);
        }

        [Test]
        public async Task GetBootstrapCredentials()
        {
            var credentials = await new ServerCredentialsRepository().GetBootstrap();
            Assert.IsInstanceOf(typeof(ServerCredentials), credentials);
        }
    }
}