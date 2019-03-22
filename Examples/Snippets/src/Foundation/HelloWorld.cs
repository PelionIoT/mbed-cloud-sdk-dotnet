using System;
using System.Diagnostics;
using Mbed.Cloud.Foundation;
using NUnit.Framework;
using static NUnit.Framework.TestContext;

namespace Snippets.src.Foundation
{
    [TestFixture]
    public class HelloWorld
    {
        [Test]
        public async System.Threading.Tasks.Task HelloWorldTask()
        {
            try
            {
                // an example: hello world
                foreach (var device in new DeviceRepository().List())
                {
                    Console.WriteLine("Device name is " + device.Name);
                    // cloak
                    Progress.WriteLine("Device name is " + device.Name);
                    // uncloak
                }
                // end of example
            }
            catch (Exception)
            {
                // Exception processing here.
            }
        }
    }
}
