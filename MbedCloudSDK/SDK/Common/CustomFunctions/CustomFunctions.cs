using System.IO;
using System.Threading.Tasks;
using MbedCloud.SDK.Entities;
using RestSharp;

namespace MbedCloud.SDK.Common
{
    public static class CustomFunctions
    {
        public static bool IsDeveloperCertificateGetter(TrustedCertificate self)
        {
            return self.DeviceExecutionMode.HasValue ? (self.DeviceExecutionMode != 0) : false;
        }

        public static bool IsDeveloperCertificateGetter(SubtenantTrustedCertificate self)
        {
            return self.DeviceExecutionMode.HasValue ? (self.DeviceExecutionMode != 0) : false;
        }

        public static void IsDeveloperCertificateSetter(TrustedCertificate self, bool? value)
        {
            self.DeviceExecutionMode = value.HasValue ? 1 : 0;
            self.IsDeveloperCertificate = value;
        }

        public static void IsDeveloperCertificateSetter(SubtenantTrustedCertificate self, bool? value)
        {
            self.DeviceExecutionMode = value.HasValue ? 1 : 0;
            self.IsDeveloperCertificate = value;
        }

        public static Task<Stream> DownloadFullReportFile(DeviceEnrollmentBulkCreateRepository repo, DeviceEnrollmentBulkCreate model)
        {
            return StreamToFile(repo.Config, model.FullReportFile);
        }

        public static Task<Stream> DownloadFullReportFile(DeviceEnrollmentBulkDeleteRepository repo, DeviceEnrollmentBulkDelete model)
        {
            return StreamToFile(repo.Config, model.ErrorsReportFile);
        }

        public static Task<Stream> DownloadErrorsReportFile(DeviceEnrollmentBulkCreateRepository repo, DeviceEnrollmentBulkCreate model)
        {
            return StreamToFile(repo.Config, model.FullReportFile, "error-report.csv");
        }

        public static Task<Stream> DownloadErrorsReportFile(DeviceEnrollmentBulkDeleteRepository repo, DeviceEnrollmentBulkDelete model)
        {
            return StreamToFile(repo.Config, model.ErrorsReportFile, "error-report.csv");
        }

        private static Task<Stream> StreamToFile(Config config, string url, string filePath = "report.csv")
        {
            using (var writer = File.OpenWrite(filePath))
            {
                if (!string.IsNullOrEmpty(url) && config != null)
                {
                    var client = new RestClient(config.Host);
                    var request = new RestRequest(url.Replace(config.Host, string.Empty))
                    {
                        ResponseWriter = (responseStream) => responseStream.CopyTo(writer)
                    };
                    request.AddHeader("Authorization", $"Bearer {config.ApiKey}");
                    client.Execute(request);
                }
            }

            return Task.FromResult<Stream>(File.OpenRead(filePath));
        }
    }
}