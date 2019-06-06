// an example: hello world
using System;
using System.Threading.Tasks;
using Mbed.Cloud.Foundation;

// cloak
using NUnit.Framework;

[TestFixture]
// uncloak
public class HelloWorldExamples
{
    // cloak
    [Test]
    public void HelloWorld()
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
        var options = new DeviceListOptions
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
