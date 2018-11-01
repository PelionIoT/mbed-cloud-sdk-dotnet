using System;
using System.IO;
using MbedCloud.SDK.Entities;
using MbedCloud.SDK.Enums;
using MbedCloudSDK.Exceptions;
using NUnit.Framework;

namespace Snippets.src.Foundation
{
    [TestFixture]
    public class DeviceEnrollmentSnippets
    {
        [Test]
        public async System.Threading.Tasks.Task EnrollOneDeviceAsync()
        {
            try
            {
                // an example: device enrollment single
                var enrollment = new DeviceEnrollment
                {
                    EnrollmentIdentity = "A-4E:63:2D:AE:14:BC:D1:09:77:21:95:44:ED:34:06:57:1E:03:B1:EF:0E:F2:59:44:71:93:23:22:15:43:23:12",
                };
                await enrollment.Create();
                // end of example

                Assert.NotNull(enrollment.ClaimedAt);
            }
            catch (CloudApiException e) when (e.ErrorCode == 409)
            {
                // expect to return 409, device already enrolled
                return;
            }
            catch (Exception)
            {
                throw;
            }
        }

        [Test]
        public async System.Threading.Tasks.Task BulkEnrollDevicesAsync()
        {
            try
            {
                var pathToCsv = "/Users/alelog01/git/mbed-cloud-sdk-dotnet/Examples/Snippets/src/Foundation/test.csv";
                // an example: device enrollment bulk
                var bulk = new DeviceEnrollmentBulkCreate();
                // use System.IO file open
                using (var file = File.Open(pathToCsv, FileMode.Open))
                {
                    await bulk.Create(file);
                }

                // cloak
                Assert.AreEqual(bulk.Status, DeviceEnrollmentBulkCreateStatusEnum.NEW);
                // uncloak

                await bulk.Get();
                // end of example

                Assert.IsTrue(bulk.Status == DeviceEnrollmentBulkCreateStatusEnum.COMPLETED || bulk.Status == DeviceEnrollmentBulkCreateStatusEnum.PROCESSING);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}