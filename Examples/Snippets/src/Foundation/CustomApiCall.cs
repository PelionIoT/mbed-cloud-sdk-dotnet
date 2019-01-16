// using System;
// using System.Collections.Generic;
// using System.Linq;
// using System.Threading.Tasks;
// using MbedCloud.SDK.Client;
// using MbedCloud.SDK.Common;
// using MbedCloud.SDK.Entities;
// using NUnit.Framework;

// namespace Snippets.src.Foundation
// {
//     [TestFixture]
//     public class CustomApiCall
//     {
//         [Test]
//         public async Task ACustomApiCall()
//         {
//             try
//             {
//                 // an example: custom api call
//                 var client = new MbedCloud.SDK.Client.Client(new Config());
//                 var res = await client.CallApi<ResponsePage<User>>(method: HttpMethods.GET, path: "/v3/users", queryParams: new Dictionary<string, object> { { "limit", 2 } });
//                 // end of example

//                 Assert.IsInstanceOf(typeof(User), res.Data.FirstOrDefault());
//                 Assert.IsNotNull(res.Data.FirstOrDefault().Id);
//             }
//             catch (Exception)
//             {
//                 throw;
//             }
//         }
//     }
// }