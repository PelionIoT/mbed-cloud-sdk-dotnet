// an example: hello world
using System;
using Mbed.Cloud.Foundation;

// cloak
using NUnit.Framework;

[TestFixture]
// uncloak
public class HelloWorld
{
    // cloak
    [Test]
    public async System.Threading.Tasks.Task HelloWorldTask()
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
        var options = new DeviceDeviceListOptions
        {
            MaxResults = 10     // Limit to ten devices
        };

        // List the first ten devices on your Pelion Device Management account.
        foreach (var device in new DeviceRepository().List(options))
        {
            Console.WriteLine($"Hello device {device.Name}");
        }
    }
}
// end of example
