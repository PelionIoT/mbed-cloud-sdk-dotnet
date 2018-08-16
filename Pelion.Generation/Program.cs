using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using MbedCloudSDK.Common;
using MbedCloudSDK.TagPOC.User;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Serialization;
using Pelion.Generation.src.common;
using Pelion.Generation.src.common.generators;
using YamlDotNet.Serialization;

namespace Pelion.Generation
{
    class Program
    {
        static async Task<int> Main(string[] args)
        {
            if (args.Length < 3)
            {
                Console.WriteLine("Too few arguments");
                Console.WriteLine("Required areguments are:");
                Console.WriteLine(" - path to yaml file");
                Console.WriteLine(" - name of target project");
                Console.WriteLine(" - directory of repo");
                return 1;
            }
            var pathToYaml = args[0];
            var targetProjectName = args[1];
            var rootDirectory = args[2];
            var generation = new Generation(pathToYaml, targetProjectName, rootDirectory);
            generation.RunGeneration();
            return 0;

            // // var config = new Config();

            // // var userId = "0160220bab144212f02c240e00000000";

            // // var testIam = new AccountManagementApi(config);

            // // var iamConfig = new iam.Client.Configuration
            // // {
            // //     BasePath = config.Host,
            // //     DateTimeFormat = "yyyy-MM-dd'T'HH:mm:ss.fffZ",
            // // };
            // // iamConfig.AddApiKey("Authorization", config.ApiKey);
            // // iamConfig.AddApiKeyPrefix("Authorization", config.AuthorizationPrefix);
            // // iamConfig.CreateApiClient();

            // // var testUser = testIam.GetUser(userId);

            // // Console.WriteLine(JsonConvert.SerializeObject(testUser, settings));

            // // var user = new User()
            // // {
            // //     Id = userId,
            // //     TwoFactorAuthentication = true,
            // // };

            // // // var x = JsonConvert.SerializeObject(user);
            // // // Console.WriteLine(x);

            // // var res = ApiMethodCall.CallApi<User>(
            // //     path: "/v3/users/{user-id}",
            // //     pathParams: new Dictionary<string, object>() { { "user-id", user.Id } },
            // //     accepts: new string[] { "application/json" },
            // //     configuration: iamConfig
            // // );

            // // var iam = new AccountManagementApi(new Config());

            // // var user2 = new User
            // // {
            // //     Email = "forlan@forlan.com",
            // //     FullName = "Diego Forlan",
            // //     MarketingAccepted = true,
            // //     Username = "diego.forlan",
            // //     PhoneNumber = "0800001066"
            // // };

            // // var createdUser2 = iam.AddUser(user2);

            // //===========================================

            // var user = await new User
            // {
            //     Email = "forlan@forlan.com",
            //     FullName = "Diego Forlan",
            //     MarketingAccepted = true,
            //     Username = "diego.forlan",
            //     PhoneNumber = "0800001066"
            // }
            // .Create();

            // Console.WriteLine(user.GetHashCode());

            // Console.WriteLine($"My first phone number is {user.PhoneNumber}");

            // //var user = await User.Get(newUser.Id);

            // //Console.WriteLine($"Got my user again and the phone number is {user.PhoneNumber}");

            // user.PhoneNumber = "118118";
            // await user.Update();

            // Console.WriteLine(user.GetHashCode());

            // Console.WriteLine($"My phone number is now {user.PhoneNumber}");

            // await user.Delete();

            // return 0;
        }
    }
}
