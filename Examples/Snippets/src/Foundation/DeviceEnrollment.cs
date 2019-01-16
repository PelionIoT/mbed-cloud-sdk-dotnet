// using System;
// using System.IO;
// using MbedCloud.SDK.Entities;
// using MbedCloud.SDK.Enums;
// using MbedCloudSDK.Exceptions;
// using NUnit.Framework;

// namespace Snippets.src.Foundation
// {
//     [TestFixture]
//     public class DeviceEnrollmentSnippets
//     {
//         [Test]
//         public async System.Threading.Tasks.Task EnrollOneDeviceAsync()
//         {
//             try
//             {
//                 // an example: device enrollment single
//                 var enrollment = new DeviceEnrollment
//                 {
//                     EnrollmentIdentity = "A-4E:63:2D:AE:14:BC:D1:09:77:21:95:44:ED:34:06:57:1E:03:B1:EF:0E:F2:59:44:71:93:23:22:15:43:23:12",
//                 };
//                 await enrollment.Create();
//                 // end of example

//                 Assert.NotNull(enrollment.ClaimedAt);

//                 await enrollment.Delete();
//             }
//             catch (CloudApiException e) when (e.ErrorCode == 409)
//             {
//                 // expect to return 409, device already enrolled
//                 return;
//             }
//             catch (Exception)
//             {
//                 throw;
//             }
//         }

//         [Test]
//         public async System.Threading.Tasks.Task BulkEnrollDevicesAsync()
//         {
//             try
//             {
//                 var pathToCsv = "/Users/alelog01/git/mbed-cloud-sdk-dotnet/Examples/Snippets/src/Foundation/test.csv";
//                 // an example: device enrollment bulk
//                 var bulk = new DeviceEnrollmentBulkCreate();
//                 // use System.IO file open
//                 using (var file = File.Open(pathToCsv, FileMode.Open))
//                 {
//                     await bulk.Create(file);
//                 }

//                 // cloak
//                 Assert.AreEqual(bulk.Status, DeviceEnrollmentBulkCreateStatusEnum.NEW);
//                 // uncloak

//                 await bulk.Get();
//                 // end of example

//                 Assert.IsTrue(bulk.Status == DeviceEnrollmentBulkCreateStatusEnum.COMPLETED || bulk.Status == DeviceEnrollmentBulkCreateStatusEnum.PROCESSING);

//                 var reportFile = await bulk.DownloadFullReportFile();
//                 Assert.IsTrue(reportFile.CanRead);
//                 reportFile.Close();

//                 var errors = await bulk.DownloadErrorsReportFile();
//                 Assert.IsTrue(errors.CanRead);
//                 errors.Close();
//             }
//             catch (Exception)
//             {
//                 throw;
//             }
//         }

//         [Test]
//         public async System.Threading.Tasks.Task BulkEnrollDeleteDevicesAsync()
//         {
//             try
//             {
//                 var pathToCsv = "/Users/alelog01/git/mbed-cloud-sdk-dotnet/Examples/Snippets/src/Foundation/test.csv";
//                 var bulk = new DeviceEnrollmentBulkDelete();
//                 // use System.IO file open
//                 using (var file = File.Open(pathToCsv, FileMode.Open))
//                 {
//                     await bulk.Delete(file);
//                 }

//                 Assert.AreEqual(bulk.Status, DeviceEnrollmentBulkDeleteStatusEnum.NEW);

//                 await bulk.Get();

//                 Assert.IsTrue(bulk.Status == DeviceEnrollmentBulkDeleteStatusEnum.COMPLETED || bulk.Status == DeviceEnrollmentBulkDeleteStatusEnum.PROCESSING);

//                 var reportFile = await bulk.DownloadFullReportFile();
//                 Assert.IsTrue(reportFile.CanRead);
//                 reportFile.Close();

//                 var errors = await bulk.DownloadErrorsReportFile();
//                 Assert.IsTrue(errors.CanRead);
//                 errors.Close();
//             }
//             catch (Exception)
//             {
//                 throw;
//             }
//         }
//     }
// }