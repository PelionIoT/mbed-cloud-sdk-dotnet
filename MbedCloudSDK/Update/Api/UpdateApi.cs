// <copyright file="UpdateApi.cs" company="Arm">
// Copyright (c) Arm. All rights reserved.
// </copyright>

namespace MbedCloudSDK.Update.Api
{
    using System;
    using System.Linq;
    using MbedCloudSDK.Common;
    using update_service.Client;

    /// <summary>
    /// Exposing functionality from: Update service, Update campaigns and Manifest management
    /// </summary>
    public partial class UpdateApi : BaseApi
    {
        private Config config;
        private update_service.Api.DefaultApi api;

        /// <summary>
        /// Initializes a new instance of the <see cref="UpdateApi"/> class.
        /// </summary>
        /// <param name="config">Config.</param>
        public UpdateApi(Config config)
            : base(config)
        {
            if (config.Host != string.Empty)
            {
                Configuration.Default.ApiClient = new ApiClient(config.Host);
            }

            this.config = config;
            api = new update_service.Api.DefaultApi();
            api.Configuration.ApiKey["Authorization"] = config.ApiKey;
            api.Configuration.ApiKeyPrefix["Authorization"] = config.AuthorizationPrefix;
            api.Configuration.DateTimeFormat = "yyyy-MM-ddThh:mm:ss.ffffffZ";
        }

        /// <summary>
        /// Get meta data for the last Mbed Cloud API call
        /// </summary>
        /// <returns>Api Metadata</returns>
        public static ApiMetadata GetLastApiMetadata()
        {
            return ApiMetadata.Map(update_service.Client.Configuration.Default.ApiClient.LastApiResponse.LastOrDefault());
        }

        /// <summary>
        /// TestTest
        /// </summary>
        /// <returns>Campaign</returns>
        public Model.Campaign.Campaign TestTest()
        {
            var manifestId = string.Empty;

            // List all firware manifests
            var listParamas = new Common.Query.QueryOptions
            {
                Limit = 5,
            };

            var manifests = ListFirmwareManifests(listParamas).Data;
            foreach (var item in manifests)
            {
                System.Console.WriteLine(item);
            }

            manifestId = manifests.LastOrDefault()?.Id;

            // List all queries
            var devicesApi = new DeviceDirectory.Api.DeviceDirectoryApi(config);
            var queries = devicesApi.ListQueries();
            var query = queries.LastOrDefault();

            // Create Campaign
            var campaignName = System.DateTime.Now.ToString();
            var campaign = new Model.Campaign.Campaign
            {
                Name = campaignName,
                RootManifestId = manifestId,
                DeviceFilter = query.Filter,
            };

            campaign = AddCampaign(campaign);

            Console.WriteLine("Created campaign : " + campaign);

            // Start update campaign
            campaign = StartCampaign(campaign);

            // Print status of update campaign
            var countdown = 10;
            while (countdown >= 0)
            {
                var options = new Common.Query.QueryOptions
                {
                    Id = campaign.Id,
                };
                var states = ListCampaignDeviceStates(options).Data;
                foreach (var item in states)
                {
                    Console.WriteLine($"{item.Id} - {Convert.ToString(item.State)}");
                }

                countdown--;
            }

            return campaign;
        }
    }
}
