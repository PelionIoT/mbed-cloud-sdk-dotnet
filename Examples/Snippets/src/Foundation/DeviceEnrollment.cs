using System;
using System.IO;
using System.Threading.Tasks;
using Mbed.Cloud.Foundation;
using Mbed.Cloud.Foundation.Enums;
using MbedCloudSDK.Exceptions;
using NUnit.Framework;

namespace Snippets.src.Foundation
{
    [TestFixture]
    public class DeviceEnrollmentExamples
    {
        [Test]
        public async Task DeviceEnrollmentSingle()
        {
            try
            {
                // an example: device enrollment single
                var enrollmentRepo = new DeviceEnrollmentRepository();
                var enrollment = new DeviceEnrollment
                {
                    EnrollmentIdentity = "A-4E:63:2D:AE:14:BC:D1:09:77:21:95:44:ED:34:06:57:1E:03:B1:EF:0E:F2:59:44:71:93:23:22:15:43:23:12",
                };
                await enrollmentRepo.Create(enrollment);
                // end of example

                Assert.NotNull(enrollment.ClaimedAt);

                await enrollmentRepo.Delete(enrollment.Id);
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
        public async Task DeviceEnrollmentBulk()
        {
            try
            {
                var pathToCsv = "../../../src/Foundation/test.csv";
                // an example: device enrollment bulk
                var bulkRepo = new DeviceEnrollmentBulkCreateRepository();

                // use System.IO file open
                var bulk = default(DeviceEnrollmentBulkCreate);
                using (var file = File.Open(pathToCsv, FileMode.Open))
                {
                    bulk = await bulkRepo.Create(file);
                }

                // cloak
                Assert.AreEqual(bulk.Status, DeviceEnrollmentBulkCreateStatus.NEW);
                // uncloak

                bulk = await bulkRepo.Read(bulk.Id);
                // end of example

                Assert.IsTrue(bulk.Status == DeviceEnrollmentBulkCreateStatus.COMPLETED || bulk.Status == DeviceEnrollmentBulkCreateStatus.PROCESSING);

                var reportFile = await bulkRepo.DownloadFullReportFile(bulk);
                Assert.IsTrue(reportFile.CanRead);
                reportFile.Close();

                var errors = await bulkRepo.DownloadErrorsReportFile(bulk);
                Assert.IsTrue(errors.CanRead);
                errors.Close();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}