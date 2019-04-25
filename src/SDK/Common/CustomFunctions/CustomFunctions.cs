// <copyright file="CustomFunctions.cs" company="Arm">
// Copyright (c) Arm. All rights reserved.
// </copyright>

namespace Mbed.Cloud.Common
{
    using System;
    using System.IO;
    using System.Threading.Tasks;
    using Mbed.Cloud.Common.Filters;
    using Mbed.Cloud.Foundation;
    using RestSharp;

    /// <summary>
    /// Custom Functions
    /// </summary>
    public static class CustomFunctions
    {
        /// <summary>
        /// Determines whether [is developer certificate getter] [the specified self].
        /// </summary>
        /// <param name="self">The self.</param>
        /// <returns>
        ///   <c>true</c> if [is developer certificate getter] [the specified self]; otherwise, <c>false</c>.
        /// </returns>
        public static bool IsDeveloperCertificateGetter(TrustedCertificate self)
        {
            return self.DeviceExecutionMode == 1;
        }

        /// <summary>
        /// Determines whether [is developer certificate getter] [the specified self].
        /// </summary>
        /// <param name="self">The self.</param>
        /// <returns>
        ///   <c>true</c> if [is developer certificate getter] [the specified self]; otherwise, <c>false</c>.
        /// </returns>
        public static bool IsDeveloperCertificateGetter(SubtenantTrustedCertificate self)
        {
            return self.DeviceExecutionMode == 1;
        }

        /// <summary>
        /// Determines whether [is developer certificate setter] [the specified self].
        /// </summary>
        /// <param name="self">The self.</param>
        /// <param name="value">The value.</param>
        public static void IsDeveloperCertificateSetter(TrustedCertificate self, bool? value)
        {
            self.DeviceExecutionMode = value.HasValue ? 1 : 0;
            self.IsDeveloperCertificate = value;
        }

        /// <summary>
        /// Determines whether [is developer certificate setter] [the specified self].
        /// </summary>
        /// <param name="self">The self.</param>
        /// <param name="value">The value.</param>
        public static void IsDeveloperCertificateSetter(SubtenantTrustedCertificate self, bool? value)
        {
            self.DeviceExecutionMode = value.HasValue ? 1 : 0;
            self.IsDeveloperCertificate = value;
        }

        /// <summary>
        /// Downloads the full report file.
        /// </summary>
        /// <param name="repo">The repo.</param>
        /// <param name="model">The model.</param>
        /// <returns>File</returns>
        public static Task<Stream> DownloadFullReportFile(DeviceEnrollmentBulkCreateRepository repo, DeviceEnrollmentBulkCreate model)
        {
            return StreamToFile(repo.Config, model.FullReportFile);
        }

        /// <summary>
        /// Downloads the full report file.
        /// </summary>
        /// <param name="repo">The repo.</param>
        /// <param name="model">The model.</param>
        /// <returns>File</returns>
        public static Task<Stream> DownloadFullReportFile(DeviceEnrollmentBulkDeleteRepository repo, DeviceEnrollmentBulkDelete model)
        {
            return StreamToFile(repo.Config, model.ErrorsReportFile);
        }

        /// <summary>
        /// Downloads the errors report file.
        /// </summary>
        /// <param name="repo">The repo.</param>
        /// <param name="model">The model.</param>
        /// <returns>File</returns>
        public static Task<Stream> DownloadErrorsReportFile(DeviceEnrollmentBulkCreateRepository repo, DeviceEnrollmentBulkCreate model)
        {
            return StreamToFile(repo.Config, model.FullReportFile, "error-report.csv");
        }

        /// <summary>
        /// Downloads the errors report file.
        /// </summary>
        /// <param name="repo">The repo.</param>
        /// <param name="model">The model.</param>
        /// <returns>File</returns>
        public static Task<Stream> DownloadErrorsReportFile(DeviceEnrollmentBulkDeleteRepository repo, DeviceEnrollmentBulkDelete model)
        {
            return StreamToFile(repo.Config, model.ErrorsReportFile, "error-report.csv");
        }

        public static void DeviceFilterHelperSetter(UpdateCampaign self, Filter filter)
        {
            throw new NotImplementedException();
        }

        public static Filter DeviceFilterHelperGetter(UpdateCampaign self)
        {
            throw new NotImplementedException();
        }

        public static string PreSharedKeyIdGetter(PreSharedKey self)
        {
            return self.EndpointName;
        }

        public static void PreSharedKeyIdSetter(PreSharedKey self, string value)
        {
            self.EndpointName = value;
            self.Id = self.EndpointName;
        }

        private static Task<Stream> StreamToFile(Config config, string url, string filePath = "report.csv")
        {
            using (var writer = File.OpenWrite(filePath))
            {
                if (!string.IsNullOrEmpty(url) && config != null)
                {
                    var client = new RestSharp.RestClient(config.Host);
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