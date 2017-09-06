using mbedCloudSDK.Common;
using mbedCloudSDK.Common.Query;
using mbedCloudSDK.DeviceDirectory.Api;
using mbedCloudSDK.Exceptions;
using mbedCloudSDK.Update.Api;
using mbedCloudSDK.Update.Model.Campaign;
using mbedCloudSDK.Update.Model.FirmwareManifest;
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

        public void CreateCampaign()
        {
            UpdateApi api = new UpdateApi(config);
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.RestoreDirectory = true;
            string dataFile = null;
            Console.WriteLine("Choose manifest file to upload: ");
            FirmwareManifest manifest = null;
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    if ((dataFile = openFileDialog.FileName) != null)
                    {

                        // Upload manifest
                        try
                        {
                            manifest = api.AddFirmwareManifest(dataFile, CreateRandomName());
                        }
                        catch (CloudApiException e)
                        {
                            Console.WriteLine("Error while uploading manifest, Error: " + e.ToString());
                            return;
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: Could not read file from disk. Wrror: " + ex.Message);
                }
            }

            // List all firware manifests
            QueryOptions listParamas = new QueryOptions();
            listParamas.Limit = 10;
            PaginatedResponse<FirmwareManifest> manifests = api.ListFirmwareManifests(listParamas);
            var enumerator = manifests.GetEnumerator();
            while (enumerator.MoveNext())
            {
                Console.WriteLine(enumerator.Current);
            }

            // List all queries

            var devicesApi = new DeviceDirectoryApi(config);
            var queries = devicesApi.ListQueries();

            var enumeratorQueries = queries.GetEnumerator();
            if (!enumeratorQueries.MoveNext())
            {
                Console.WriteLine("No query found");
                return;
            }
            var query = enumeratorQueries.Current;

            // Create Campaign
            string campaignName = CreateRandomName();
            var campaign = new Campaign();
            campaign.Name = campaignName;
            campaign.RootManifestId = manifest.Id;
            campaign.DeviceFilter = query.QueryString;
            campaign = api.AddCampaign(campaign);
            Console.WriteLine("Created campaign : " + campaign);

            // Start update campaign
            campaign = api.StartCampaign(campaign);

            // Print status of update campaign
            /*
            int countdown = 10;
            while (countdown >= 0)
            {
                Console.WriteLine(api.GetUpdateCampaignStatus(campaign.Id));
                countdown--;
            }*/
        }
    }
}
