using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Mbed.Cloud.Common;
using Mbed.Cloud.Foundation;
using Mbed.Cloud.RestClient;
using NUnit.Framework;

namespace Snippets.src.Foundation
{
    [TestFixture]
    public class CustomApiCallExamples
    {
        [Test]
        public async Task CustomApiCall()
        {
            try
            {
                // an example: custom api call
                var client = new Client(new Config());
                var res = await client.CallApi<ResponsePage<User>>(method: HttpMethods.GET, path: "/v3/users", queryParams: new Dictionary<string, object> { { "limit", 2 } });
                // end of example

                Assert.IsInstanceOf(typeof(User), res.Data.FirstOrDefault());
                Assert.IsNotNull(res.Data.FirstOrDefault().Id);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}