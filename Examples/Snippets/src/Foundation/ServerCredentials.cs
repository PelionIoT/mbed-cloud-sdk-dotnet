// using System.Threading.Tasks;
// using MbedCloud.SDK.Entities;
// using NUnit.Framework;

// namespace Snippets.src.Foundation
// {
//     [TestFixture]
//     public class ServerCredentialsTests
//     {
//         [Test]
//         public async Task GetLwm2mCredentials()
//         {
//             var credentials = await new ServerCredentials().GetLwm2m();
//             Assert.IsInstanceOf(typeof(ServerCredentials), credentials);
//         }

//         [Test]
//         public async Task GetBootstrapCredentials()
//         {
//             var credentials = await new ServerCredentials().GetBootstrap();
//             Assert.IsInstanceOf(typeof(ServerCredentials), credentials);
//         }
//     }
// }