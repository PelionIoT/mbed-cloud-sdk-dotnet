using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MbedCloud.SDK;
using MbedCloud.SDK.Client;
using MbedCloud.SDK.Common;
using MbedCloud.SDK.Entities;
using MbedCloudSDK.Exceptions;
using NUnit.Framework;

namespace Snippets.src.Foundation
{
    [TestFixture]
    public class SingleEntryPoint
    {
        [Test]
        public void CustomConfig()
        {
            Assert.Throws<CloudApiException>(() => {
                // an example: using multiple api keys
                var allUsers = new List<User>();
                new List<string> { "ak_1", "ak_2" }.ForEach(k => allUsers.AddRange(new SDK(new Config(k)).Entities.User.List()));
                // end of example
            });
        }

        [Test]
        public void ReallyCustomConfig()
        {
            Assert.Throws<CloudApiException>(() =>
            {
                // an example: using custom hosts
                var config = new Config(apiKey: "ak_1", host: "https://example");
                var allUsers = new SDK(config).Entities.User.List();
                // end of example
            });
        }

        [Test]
        public async Task CustomApiCall()
        {
            // an example: custom api call
            var client = new MbedCloud.SDK.Client.Client(new Config());
            var res = await client.CallApi<ResponsePage<User>>(method: HttpMethods.GET, path: "/v3/users", queryParams: new Dictionary<string, object>{ {"limit", 2 }});
            // end of example

            Assert.IsInstanceOf(typeof(User), res.Data.FirstOrDefault());
            Assert.IsNotNull(res.Data.FirstOrDefault().Id);
        }
    }
}