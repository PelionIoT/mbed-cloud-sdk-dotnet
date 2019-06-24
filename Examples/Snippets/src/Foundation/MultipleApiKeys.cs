// an example: hello world with multiple api keys
using System;
using Mbed.Cloud;
using Mbed.Cloud.Common;
using Mbed.Cloud.Foundation;

// cloak
using NUnit.Framework;

[TestFixture]
// uncloak
public class MultipleApiKeys
{
    // cloak
    private string API_KEY_ONE;
    private string API_KEY_TWO;

    [Test]
    public async System.Threading.Tasks.Task MultipleApiKeysTask()
    {
        try
        {
            var sdk = new SDK();

            API_KEY_ONE = sdk.Config.ApiKey;
            API_KEY_TWO = sdk.Config.ApiKey;

            Main();
        }
        catch (Exception)
        {
            // Exception processing here.
        }
    }

    // uncloak
    public static void Main()
    {
        // Create instances of the Pelion Device Management SDK for two accounts
        var account_one = new SDK(API_KEY_ONE);
        var account_two = new SDK(API_KEY_TWO);

        var options = new DeviceListOptions
        {
            MaxResults = 10     // Limit to ten devices
        };

        // List the first ten devices on the first account
        foreach (var device in account_one.Foundation().DeviceRepository().List(options))
        {
            Console.WriteLine("Account One device " + device.Name);
        }

        // List the first ten devices on the second account
        foreach (var device in account_two.Foundation().DeviceRepository().List(options))
        {
            Console.WriteLine("Account Two device " + device.Name);
        }
    }
}
// end of example
