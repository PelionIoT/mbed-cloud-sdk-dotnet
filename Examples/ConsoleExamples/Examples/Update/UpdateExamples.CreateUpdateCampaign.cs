// <copyright file="UpdateExamples.CreateUpdateCampaign.cs" company="Arm">
// Copyright (c) Arm. All rights reserved.
// </copyright>

namespace ConsoleExamples.Examples.Update
{
    using System;
    using System.Linq;
    using System.Threading;
    using MbedCloudSDK.Common;
    using MbedCloudSDK.Common.Filter;
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
        /// <returns>Campaign</returns>
        public Campaign CreateCampaign()
        {
            // List all firware manifests
            var listParamas = new QueryOptions
            {
                Limit = 5,
            };
            var manifests = api.ListFirmwareManifests(listParamas).Data;

            var manifestId = manifests.LastOrDefault()?.Id;

            var deviceFilter = new Filter();

            deviceFilter.Add("state", "registered");
            // deviceFilter.Add("account_id", "015bc8548c2d02420a016d0600000000");

            // Create Campaign
            var campaignName = CreateRandomName();
            var campaign = new Campaign
            {
                Name = campaignName,
                ManifestId = manifestId,
                DeviceFilter = deviceFilter,
            };
            campaign = api.AddCampaign(campaign);

            var fieldsToUpdate = new Campaign
            {
                Name = $"updated-{campaign.Name}",
            };

            var updatedCampaign = api.UpdateCampaign(campaign.Id, fieldsToUpdate);

            Console.WriteLine("Created campaign : " + campaign);

            api.ListCampaignDeviceStates(updatedCampaign.Id).Data.ForEach(s => Console.WriteLine(s));

            // Start update campaign
            campaign = api.StartCampaign(updatedCampaign.Id, updatedCampaign);

            Console.WriteLine("Started campaign");

            Thread.Sleep(2000);

            // Print status of update campaign
            var countdown = 10;
            while (countdown >= 0)
            {
                var states = api.ListCampaignDeviceStates(campaign.Id).Data;
                foreach (var item in states)
                {
                    Console.WriteLine($"Device state - {Convert.ToString(item.State)}");
                }

                countdown--;
            }

            api.StopCampaign(campaign.Id, campaign);

            api.DeleteCampaign(campaign.Id);

            return campaign;
        }
    }
}

