using System.IO;
using System.Threading.Tasks;
using MbedCloud.SDK.Entities;

namespace MbedCloud.SDK.Common
{
    public static class CustomFunctions
    {
        public static bool IsDeveloperCertificateGetter(TrustedCertificate self)
        {
            return self.DeviceExecutionMode.HasValue ? (self.DeviceExecutionMode != 0) : false;
        }

        public static void IsDeveloperCertificateSetter(TrustedCertificate self, bool? value)
        {
            self.DeviceExecutionMode = value.HasValue ? 1 : 0;
            self.IsDeveloperCertificate = value;
        }

        public static Task<Stream> DownloadFullReportFile(DeviceEnrollmentBulkCreate self)
        {
            return null;
        }

        public static Task<Stream> DownloadFullReportFile(DeviceEnrollmentBulkDelete self)
        {
            return null;
        }

        public static Task<Stream> DownloadErrorsReportFile(DeviceEnrollmentBulkCreate self)
        {
            return null;
        }

        public static Task<Stream> DownloadErrorsReportFile(DeviceEnrollmentBulkDelete self)
        {
            return null;
        }
    }
}