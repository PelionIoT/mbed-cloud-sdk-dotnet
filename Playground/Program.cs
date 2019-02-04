
using System;
using Newtonsoft.Json;
using MbedCloudSDK.Common.Extensions;
using System.Linq;
using MbedCloudSDK.AccountManagement.Api;
using Mbed.Cloud.Foundation.Enums;
using MbedCloudSDK.AccountManagement.Model.User;

namespace Playground
{
    class Program
    {
        static async System.Threading.Tasks.Task Main(string[] args)
        {
            try
            {
                var user = new AccountManagementApi(new Mbed.Cloud.Foundation.Common.Config());

                var listPaginator = user.ListUsers();

                var all = listPaginator.All();

                var first = listPaginator.FirstOrDefault();

                var some = listPaginator.Where(u => u.Status == UserStatus.RESET);

                var limitedPaginator = user.ListUsers(new Mbed.Cloud.Foundation.Common.QueryOptions { MaxResults = 2 });

                var limitedAll = limitedPaginator.All();

                Console.WriteLine(first);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
    }
}
