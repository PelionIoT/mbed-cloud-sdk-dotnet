using MbedCloudSDK.Common;
using MbedCloudSDK.Common.Query;
using MbedCloudSDK.DeviceDirectory.Api;
using MbedCloudSDK.Exceptions;
using MbedCloudSDK.Update.Api;
using MbedCloudSDK.Update.Model.Campaign;
using MbedCloudSDK.Update.Model.FirmwareManifest;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ConsoleExamples.Examples.Update
{
    /// @example
    public class CreateUpdateCampaign
    {
        private Config config;

        public CreateUpdateCampaign(Config config)
        {
            this.config = config;
        }

        private string CreateRandomName()
        {
            return DateTime.Now.ToString();
        }

        public Campaign CreateCampaign(bool selectFile)
        {
            UpdateApi api = new UpdateApi(config);
            string manifestId = string.Empty;

            if (selectFile)
            {
                manifestId = GetManifestFile(api);
            }

            // List all firware manifests
            var listParamas = new QueryOptions()
            {
                Limit = 10
            };
            var manifests = api.ListFirmwareManifests(listParamas).Data;
            foreach (var item in manifests)
            {
                Console.WriteLine(item);
            }

            if(!selectFile)
            {
                manifestId = manifests.LastOrDefault()?.Id;
            }

            // List all queries

            var devicesApi = new DeviceDirectoryApi(config);
            var queries = devicesApi.ListQueries().ToList();
            var query = queries.LastOrDefault();

            // Create Campaign
            string campaignName = CreateRandomName();
            var campaign = new Campaign();
            campaign.Name = campaignName;
            campaign.RootManifestId = manifestId;
            campaign.DeviceFilter = query.Filter;
            campaign = api.AddCampaign(campaign);

            Console.WriteLine("Created campaign : " + campaign);

            // Start update campaign
            campaign = api.StartCampaign(campaign);

            // Print status of update campaign
            int countdown = 10;
            while (countdown >= 0)
            {
                var options = new QueryOptions()
                {
                    Id = campaign.Id
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

        private string GetManifestFile(UpdateApi api)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.RestoreDirectory = true;
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
                            return String.Empty;
                        }
                    }

                    return String.Empty;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: Could not read file from disk. Wrror: " + ex.Message);
                    return String.Empty;
                }
            }

            return String.Empty;
        }
    }
}
