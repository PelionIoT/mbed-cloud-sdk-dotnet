using System;
using System.Linq;
using MbedCloudSDK.Billing.Api;
using MbedCloudSDK.Common;
using MbedCloudSDK.Accounts.User;
using MbedCloudSDK.Accounts.ApiKey;
using Newtonsoft.Json;
using System.Collections.Generic;
using MbedCloudSDK.Accounts.SubtenantAccount;

namespace Playground
{
    class Program
    {
        static async System.Threading.Tasks.Task Main(string[] args)
        {
            try
            {
                Console.WriteLine("---------------------User-----------------------------");

                var users = User.List(limit: 2);

                Console.WriteLine($"I can list {users.Count()} users.");

                var getUser = new User()
                {
                    Id = users.FirstOrDefault()?.Id,
                };

                Console.WriteLine($"The first user has Id {getUser.Id}");

                await getUser.Get();

                Console.WriteLine($"and was created on {getUser.CreatedAt}");

                Console.WriteLine($"It has {getUser.Groups().Count()} groups.");

                var user = new User()
                {
                    Address = "the street",
                    Email = "noalgalex22222@gmail.com",
                    FullName = "Don D",
                    PhoneNumber = "07845215995",
                    Username = "drdond22222",
                };

                Console.WriteLine($"Creating a new user with phone number {user.PhoneNumber}");

                await user.Create();

                Console.WriteLine($"The id is {user.Id} and the phone number is {user.PhoneNumber}");

                user.PhoneNumber = "118118";

                await user.Update();

                Console.WriteLine($"The phone number is now {user.PhoneNumber}");

                Console.WriteLine("deleting...");
                await user.Delete();

                Console.WriteLine("---------------------ApiKey-----------------------------");

                var keys = ApiKey.List();

                Console.WriteLine($"I can list {keys.Count()} keys.");

                var getKey = new ApiKey()
                {
                    Id = keys.FirstOrDefault()?.Id,
                };

                Console.WriteLine($"The first key has Id {getKey.Id}");

                Console.WriteLine($"It has {getKey.Groups().Count()} groups.");

                var apiKey = new ApiKey
                {
                    Name = "test key"
                };

                Console.WriteLine($"Creating a new api key with name {apiKey.Name}");

                await apiKey.Create();

                Console.WriteLine($"The Id is {apiKey.Id} and it was created at {apiKey.CreatedAt}");

                apiKey.Name = "updated test key";

                await apiKey.Update();

                Console.WriteLine($"The name is now {apiKey.Name}");

                Console.WriteLine("Deleting....");

                await apiKey.Delete();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
    }
}
