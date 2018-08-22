using System;
using System.Linq;
using MbedCloudSDK.AccountManagement.Api;
using MbedCloudSDK.Billing.Api;
using MbedCloudSDK.Common;

namespace Playground
{
    class Program
    {
        static async System.Threading.Tasks.Task Main(string[] args)
        {
            var iam = new AccountManagementApi(new Config());

            var testUser = iam.ListUsers().First();

            var user = new MbedCloudSDK.Accounts.User.User()
            {
                Address = "the street",
                Email = "noalgalex22@gmail.com",
                FullName = "Don D",
                PhoneNumber = "07845215995",
                Username = "drdond22",
            };

            try
            {
                var getUser = new MbedCloudSDK.Accounts.User.User()
                {
                    Id = testUser.Id,
                };

                // Console.WriteLine(await getUser.Read());

                await user.Create();
                //await user.Read();

                Console.WriteLine($"My phone number is {user.PhoneNumber}");

                user.PhoneNumber = "118118";

                await user.Update();

                Console.WriteLine($"My phone number is now {user.PhoneNumber}");

                //Console.WriteLine(iam.ListUsers().All().FirstOrDefault(u => u.Id == user.Id));

                await user.Delete();
            }
            catch(Exception e)
            {
                Console.WriteLine(e);
            }
        }
    }
}
