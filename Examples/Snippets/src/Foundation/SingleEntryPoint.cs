using System.Collections.Generic;
using System.Threading.Tasks;
using MbedCloudSDK.Entities.User;
using MbedCloudSDK.Common;
using MbedCloudSDK;
using NUnit.Framework;
using MbedCloudSDK.Exceptions;
using MbedCloudSDK.Common.Query;
using RestSharp;
using System.Linq;

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
                new List<string> { "ak_1", "ak_2" }.ForEach(k => allUsers.AddRange(new SDK(k).User().List()));
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
                var allUsers = new SDK(config).User().List();
                // end of example
            });
        }

        [Test]
        public async Task CustomApiCall()
        {
            // an example: custom api call
            var res = await MbedCloudSDK.Client.ApiCall.CallApiEntity<ResponsePage<User>>(method: Method.GET, path: "/v3/users", queryParams: new Dictionary<string, object>{ {"limit", 2 }});
            // cloak

            Assert.IsInstanceOf(typeof(User), res.Data.FirstOrDefault());
            Assert.IsNotNull(res.Data.FirstOrDefault().Id);
        }

        [Test]
        public async Task CustomApiCallString()
        {
            // uncloak
            // or
            var res = await MbedCloudSDK.Client.ApiCall.CallApiString(method: Method.GET, path: "/v3/users", queryParams: new Dictionary<string, object> { { "limit", 2 } });
            // cloak

            Assert.IsInstanceOf(typeof(string), res);
        }

        [Test]
        public async Task CustomApiCallDynamic()
        {
            // uncloak
            // or
            var res = await MbedCloudSDK.Client.ApiCall.CallApiDynamic(method: Method.GET, path: "/v3/users", queryParams: new Dictionary<string, object> { { "limit", 2 } });
            // end of example

            Assert.IsNotNull(res);
        }
    }
}