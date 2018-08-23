using System;
using System.Linq;
using MbedCloudSDK.AccountManagement.Api;
using MbedCloudSDK.Billing.Api;
using MbedCloudSDK.Common;
using MbedCloudSDK.Accounts.User;

namespace Playground
{
    class Program
    {
        static async System.Threading.Tasks.Task Main(string[] args)
        {
            var iam = new AccountManagementApi(new Config());

            var testUser = iam.ListUsers(new MbedCloudSDK.Common.Query.QueryOptions { Limit = 2 }).First();

            var user = new User()
            {
                Address = "the street",
                Email = "noalgalex22222@gmail.com",
                FullName = "Don D",
                PhoneNumber = "07845215995",
                Username = "drdond22222",
                TwoFactorAuthEnabled = true,
            };

            try
            {
                var users = User.List();

                Console.WriteLine($"I can list {users.Count()} users.");

                var getUser = new User()
                {
                    Id = users.FirstOrDefault()?.Id,
                };

                Console.WriteLine($"The first user has Id {getUser.Id}");

                await getUser.Read();

                Console.WriteLine($"and was created on {getUser.CreatedAt}");

                Console.WriteLine($"It has {getUser.Groups().Count()} groups.");

                Console.WriteLine($"Creating a new user with phone number {user.PhoneNumber}");

                await user.Create();

                Console.WriteLine($"The id is {user.Id} and the phone number is {user.PhoneNumber}");

                user.PhoneNumber = "118118";

                await user.Update();

                Console.WriteLine($"The phone number is now {user.PhoneNumber}");

                //Console.WriteLine(iam.ListUsers().All().FirstOrDefault(u => u.Id == user.Id));
                Console.WriteLine("deleting...");
                await user.Delete();
            }
            catch(Exception e)
            {
                Console.WriteLine(e);
            }
        }
    }
}
