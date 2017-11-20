// <copyright file="UpdateExamples.CreateUpdateCampaign.cs" company="Arm">
// Copyright (c) Arm. All rights reserved.
// </copyright>

namespace ConsoleExamples.Examples.Update
{
    using System;
    using System.Linq;
    using System.Windows.Forms;
    using MbedCloudSDK.Common;
    using MbedCloudSDK.Common.Query;
    using MbedCloudSDK.DeviceDirectory.Api;
    using MbedCloudSDK.Exceptions;
    using MbedCloudSDK.Update.Api;
    using MbedCloudSDK.Update.Model.Campaign;

    /// <summary>
    /// Update examples
    /// </summary>
    public partial class UpdateExamples
    {
        private Config config;
        private UpdateApi api;

        /// <summary>
        /// Initializes a new instance of the <see cref="UpdateExamples"/> class.
        /// </summary>
        /// <param name="config">Config</param>
        public UpdateExamples(Config config)
        {
            this.config = config;
            api = new UpdateApi(config);
        }

        private static string CreateRandomName()
        {
            return DateTime.Now.ToString();
        }

        /// <summary>
        /// Create an update campaign
        /// </summary>
        /// <param name="selectFile">True to bring up a file dialog</param>
        /// <returns>Campaign</returns>
        public Campaign CreateCampaign(bool selectFile)
        {
            var manifestId = string.Empty;

            // select the manifest file
            if (selectFile)
            {
                manifestId = GetManifestFile(api);
            }

            // List all firware manifests
            var listParamas = new QueryOptions
            {
                Limit = 5,
            };
            var manifests = api.ListFirmwareManifests(listParamas).Data;
            foreach (var item in manifests)
            {
                Console.WriteLine(item);
            }

            if (!selectFile)
            {
                manifestId = manifests.LastOrDefault()?.Id;
            }

            // List all queries
            var devicesApi = new DeviceDirectoryApi(config);
            var queries = devicesApi.ListQueries();
            var query = queries.LastOrDefault();

            // Create Campaign
            var campaignName = CreateRandomName();
            var campaign = new Campaign
            {
                Name = campaignName,
                RootManifestId = manifestId,
                DeviceFilter = query.Filter,
            };
            campaign = api.AddCampaign(campaign);

            Console.WriteLine("Created campaign : " + campaign);

            // Start update campaign
            campaign = api.StartCampaign(campaign);

            // Print status of update campaign
            var countdown = 10;
            while (countdown >= 0)
            {
                var options = new QueryOptions
                {
                    Id = campaign.Id,
                };
                var states = api.ListCampaignDeviceStates(options).Data;
                foreach (var item in states)
                {
                    Console.WriteLine($"{item.Id} - {Convert.ToString(item.State)}");
                }

                countdown--;
            }

            return campaign;
        }

        private static string GetManifestFile(UpdateApi api)
        {
            using (var openFileDialog = new OpenFileDialog
            {
                RestoreDirectory = true,
            })
            {
                string dataFile = null;
                Console.WriteLine("Choose manifest file to upload: ");
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        if ((dataFile = openFileDialog.FileName) != null)
                        {
                            // Upload manifest
                            try
                            {
                                var manifest = api.AddFirmwareManifest(dataFile, CreateRandomName());
                                return manifest.Id;
                            }
                            catch (CloudApiException e)
                            {
                                Console.WriteLine("Error while uploading manifest, Error: " + e.ToString());
                                return string.Empty;
                            }
                        }

                        return string.Empty;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error: Could not read file from disk. Wrror: " + ex.Message);
                        return string.Empty;
                    }
                }

                return string.Empty;
            }
        }
    }
}
