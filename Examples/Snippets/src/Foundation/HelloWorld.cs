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
            main();
        }
        catch (Exception)
        {
            // Exception processing here.
        }
    }

// uncloak
    public void Main()
    {
        // List the first ten devices on your Pelion Device Management account.
        var options = new DeviceListOptions
        {
            MaxResults = 10
        };

        foreach (var device in new DeviceRepository().List(options))
        {
            Console.WriteLine("Hello device " + device.Name);
        }
    }
}
// end of example
