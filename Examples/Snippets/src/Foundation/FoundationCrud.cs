using System;
using System.Threading.Tasks;
using Mbed.Cloud;
using Mbed.Cloud.Foundation;
using Mbed.Cloud.Common.Filters;
using NUnit.Framework;
using Mbed.Cloud.Foundation.Enums;
using System.Collections.ObjectModel;
using System.Linq;

[TestFixture]
public class FoundationCrud
{
    [Test]
    public async System.Threading.Tasks.Task FoundationCrudTask()
    {
        // Create an instance of the Pelion Device Management SDK
        var sdk = new SDK();

        await Examples(sdk);
    }

    public async Task Examples(SDK sdk)
    {
        var userId = "user-1";

        // an example: create an entity
        var newUser = new User
        {
            Email = "csharp.sdk.user@arm.com"
        };

        await sdk
            .Foundation()
            .UserRepository()
            .Create(newUser);
        // end of example

        // an example: read an entity
        var userOne = await sdk
                            .Foundation()
                            .UserRepository()
                            .Read(userId);
        Console.WriteLine($"User email address: {userOne.Email}");
        // end of example

        // an example: update an entity
        var userTwo = await sdk
                            .Foundation()
                            .UserRepository()
                            .Read(userId);

        userTwo.FullName = "CSharp SDK User";

        await sdk
            .Foundation()
            .UserRepository()
            .Update(userTwo.Id, userTwo);
        // end of example

        // an example: delete an entity
        var userThree = await sdk
                            .Foundation()
                            .UserRepository()
                            .Read(userId);

        await sdk
            .Foundation()
            .UserRepository()
            .Delete(userThree.Id);
        // end of example

        // an example: list entities
        var options = new UserUserListOptions
        {
            Order = "ASC",
            PageSize = 5,
            MaxResults = 10,
            Include = "total_count"
        };

        var userList = sdk
                        .Foundation()
                        .UserRepository()
                        .List(options);

        foreach (var user in userList)
        {
            Console.WriteLine($"{user.FullName}: ({user.Id}): {user.Email}");
        }
        // end of example

        // an example: list entities with filters
        var userOptions = new UserUserListOptions()
            .EmailEqualTo("mr.test@mydomain.com")
            .StatusIn(UserStatus.ACTIVE, UserStatus.ENROLLING);

        userList = sdk
                    .Foundation()
                    .UserRepository()
                    .List(userOptions);

        foreach (var user in userList)
        {
            Console.WriteLine($"{user.FullName}: ({user.Id}): {user.Email}");
        }
        // end of example

        // an example: read first entity in list
        var firstUserInList = sdk
                                .Foundation()
                                .UserRepository()
                                .List()
                                .FirstOrDefault();

        Console.WriteLine($"User email address: {firstUserInList.Email}");
        // end of example
    }
}
