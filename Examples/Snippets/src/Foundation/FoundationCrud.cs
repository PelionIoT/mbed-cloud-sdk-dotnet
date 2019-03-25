using System;
using System.Threading.Tasks;
using Mbed.Cloud;
using Mbed.Cloud.Foundation;
using Mbed.Cloud.Common.Filters;
using NUnit.Framework;
using Mbed.Cloud.Foundation.Enums;
using System.Collections.ObjectModel;

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
        var userOneId = "user-1";
        var userTwoId = "user-2";

        // an example: create an entity
        var newUser = new User();
        newUser.Email = "fred.bloggs+test@arm.com";
        await sdk.Foundation().UserRepository().Create(newUser);
        // end of example

        // an example: read an entity
        var userOne = await sdk.Foundation().UserRepository().Read(userOneId);
        Console.WriteLine("User email address is " + userOne.Email);
        // end of example

        // an example: update an entity
        var userTwo = await sdk.Foundation().UserRepository().Read(userTwoId);
        userTwo.FullName = "C Sharp SDK User";
        await sdk.Foundation().UserRepository().Update(userTwo.Id, userTwo);
        // end of example

        var idOfUserToRemove = newUser.Id;

        // an example: delete an entity
        await sdk.Foundation().UserRepository().Delete(idOfUserToRemove);
        // end of example

        // an example: list entities
        var options = new UserListOptions
        {
            Order = "asc",
            PageSize = 5,
            MaxResults = 10,
            Include = "total_count"
        };

        var userList = sdk.Foundation().UserRepository().List(options);
        foreach (var user in userList)
        {
            var message = string.Format("{0}: ({1}): {2}", user.FullName, user.Id, user.Email);
            Console.WriteLine(message);
        }
        // end of example

        // an example: list entities with filters
        var userOptions = new UserListOptions
        {
            Order = "asc",
            PageSize = 5,
            MaxResults = 10,
        };

        userOptions.EmailEqualTo("mr.test@mydomain.com").StatusIn(UserStatus.ACTIVE, UserStatus.ENROLLING);

        userList = sdk.Foundation().UserRepository().List(userOptions);
        foreach (var user in userList)
        {
            var message = string.Format("{0}: ({1}): {2}", user.FullName, user.Id, user.Email);
            Console.WriteLine(message);
        }
        // end of example

        // an example: read first entity in list
        var firstUserInList = sdk.Foundation().UserRepository().List().GetEnumerator().Current;
        Console.WriteLine("User email address: ", firstUserInList.Email);
        // end of example
    }
}
