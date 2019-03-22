using System;
using System.Diagnostics;
using Mbed.Cloud;
using Mbed.Cloud.Foundation;
using NUnit.Framework;
using static NUnit.Framework.TestContext;

namespace Snippets.src.Foundation
{
    [TestFixture]
    public class HelloWorldSeparateSdk
    {
        [Test]
        public async System.Threading.Tasks.Task HelloWorldSeparateSdkTask()
        {
            try
            {
                var sdk = new SDK();

                // an example: hello world with sdk instance
                foreach (var device in sdk.Foundation().DeviceRepository().List())
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
