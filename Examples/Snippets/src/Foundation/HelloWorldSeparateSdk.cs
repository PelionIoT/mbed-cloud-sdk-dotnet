// an example: hello world with sdk instance
using System;
using Mbed.Cloud;
using Mbed.Cloud.Foundation;

// cloak
using NUnit.Framework;

[TestFixture]
// uncloak
public class HelloWorldSeparateSdk
{
    // cloak
    [Test]
    public async System.Threading.Tasks.Task HelloWorldSeparateSdkTask()
    {
        try
        {
            Main();
        }
        catch (Exception)
        {
            // Exception processing here.
        }
    }

    // uncloak
    public void Main()
    {
        // Create an instance of the Pelion Device Management SDK
        var sdk = new SDK();

        var options = new DeviceListOptions
        {
            MaxResults = 10     // Limit to ten devices
        };

        // List the first ten devices on your Pelion Device Management account
        foreach (var device in sdk.Foundation().DeviceRepository().List(options))
        {
            Console.WriteLine($"Hello device {device.Name}");
        }
    }
}
// end of example
