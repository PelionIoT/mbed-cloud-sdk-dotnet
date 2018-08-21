using System;
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

            var user = new MbedCloudSDK.AggregatorAccountAdmin.User.User()
            {
                Id = testUser.Id,
            };

            try
            {
                await user.Read();

                Console.WriteLine(user);

                user.FullName = "Don Draper";

                await user.Update();

                Console.WriteLine(user);
            }
            catch(Exception e)
            {
                Console.WriteLine(e);
            }
        }
    }
}
