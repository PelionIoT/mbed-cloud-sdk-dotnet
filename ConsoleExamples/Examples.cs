using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using mbedCloudSDK.Access;
using mbedCloudSDK.Access.Model.ApiKey;
using mbedCloudSDK.Common;
using mbedCloudSDK.Devices;
using mbedCloudSDK.Access.Api;
using mbedCloudSDK.Devices.Api;
using mbedCloudSDK.Devices.Model;
using mbedCloudSDK.Devices.Model.Device;
using mbedCloudSDK.Logging.Api;
using mbedCloudSDK.Update.Api;
using System.Windows.Forms;
using System.IO;
using mbedCloudSDK.Exceptions;
using mbedCloudSDK.Update.Model.FirmwareManifest;
using mbedCloudSDK.Update.Model.Campaign;
using mbedCloudSDK.Devices.Model.Query;

namespace ConsoleExamples
{
    /// @example
    public class Examples
    {
        private Config config;
        public Examples(Config config)
        {
            this.config = config;
        }
        
        /// <summary>
        /// Runs the IAM example. List all Api keys.
        /// </summary>
        public void runIAMExample()
        {
            AccessApi access = new AccessApi(config);
            var keys = access.ListApiKeys();
            foreach (var key in keys)
            {
                Console.WriteLine(key);
            }
        }
        
        /// <summary>
        /// Runs the endpoints example. List all endpoints.
        /// </summary>
        public void runEndpointsExample()
        {
            DevicesApi devices = new DevicesApi(config);
            foreach (var endpoint in devices.ListConnectedDevices())
            {
                Console.WriteLine(endpoint);
            }
        }
        
        /// <summary>
        /// Runs the devices example. List all devices in device catalog.
        /// </summary>
        public void runDevicesExample(){
            DevicesApi devices = new DevicesApi(config);
            ListParams listParam = new ListParams();
            listParam.Limit = 10;
            foreach (var device in devices.ListDevices(listParam))
            {
                Console.WriteLine(device.ToString());
            }
        }
        
        /// <summary>
        /// Runs the subscription example. Subscribe to the resource.
        /// </summary>
        public void runSubscriptionExample()
        {
            //Resource path
            var buttonResource = "/3200/0/5501";
            DevicesApi devices = new DevicesApi(config);
            //List all connected endpoints
            var endpoints = devices.ListConnectedDevices();
            if (endpoints == null)
            {
                throw new Exception("No endpoints registered. Aborting.");
            }
            //Start long polling thread
            devices.StartLongPolling();
            var resources = endpoints[0].ListResources();
            foreach(var resource in resources)
            {
                if (resource.Uri == buttonResource)
                {
                    //Subscribe to the resource
                    AsyncConsumer<String> consumer = devices.Subscribe(endpoints[0].Id, resource);
                    int counter = 0;
                    while (true)
                    {
                        //Get the value of the resource and print it
                        Task<string> t = consumer.GetValue();
                        Console.WriteLine(t.Result);
                        counter++;
                        if (counter >=5)
                        {
                            break;
                        }
                    }
                }
            }
        }

        public void runGetValueExample()
        {
            //Resource path
            var buttonResource = "/3200/0/5501";
            DevicesApi devices = new DevicesApi(config);
            //List all connected endpoints
            var endpoints = devices.ListConnectedDevices();
            if (endpoints == null)
            {
                throw new Exception("No endpoints registered. Aborting.");
            }
            //Start long polling thread
            devices.StartLongPolling();
            var resources = endpoints[0].ListResources();
            foreach (var resource in resources)
            {
                if (resource.Uri == buttonResource)
                {
                    var resp = devices.GetResourceValue(endpoints[0].Id, resource.Uri);
                    Console.WriteLine(resp.GetValue().Result);
                }
            }
        }

        public void runSetValueExample()
        {
            //Resource path
            var buttonResource = "3200/0/5501";
            DevicesApi devices = new DevicesApi(config);
            //List all connected endpoints
            var endpoints = devices.ListConnectedDevices();
            if (endpoints == null)
            {
                throw new Exception("No endpoints registered. Aborting.");
            }
            //Start long polling thread
            devices.StartLongPolling();
            var resources = endpoints[0].ListResources();
            var resp = devices.SetResourceValue(endpoints[0].Id, buttonResource, "100");
            Console.WriteLine(resp.GetValue().Result);
        }

        /// <summary>
        /// Runs the webhook example. Create a webhook for the resouce.
        /// </summary>
        public void runWebhookExample()
        {
            //Resource path
            var buttonResource = "/3200/0/5501";
            DevicesApi devices = new DevicesApi(config);
            //List all connected endpoints
            var endpoints = devices.ListConnectedDevices();
            if (endpoints == null)
            {
                throw new Exception("No endpoints registered. Aborting.");
            }
            //webhook address
            string webhook = "http://testwebhooksdotnet.requestcatcher.com/test";
            devices.RegisterWebhook(webhook);
            Thread.Sleep(2000);
            //subscribe to the resource
            var resources = endpoints[0].ListResources();
            foreach (var resource in resources)
            {
                if (resource.Uri == buttonResource)
                {
                    //Subscribe to the resource
                    devices.Subscribe(endpoints[0].Id, resource);
                    Console.WriteLine(string.Format("Webhook registered, see output on {0}", webhook));
                    //Deregister webhook after 1 minute
                    Thread.Sleep(60000);
                    devices.DeregisterWebhooks();
                    break;
                }
            }
            
        }

        public void runLogsExample()
        {
            LoggingApi api = new LoggingApi(config);
            ListParams listParam = new ListParams();
            listParam.Limit = 10;
            foreach (var log in api.ListDeviceLogs(listParam))
            {
                Console.WriteLine(log.ToString());
            }
        }
        
        /// <summary>
        /// Runs the device query example. Create new query.
        /// </summary>
        public void runDeviceQueryExample()
        {
            DevicesApi devices = new DevicesApi(config);
            Query query = new Query();
            query.Attributes.Add("auto_update", "true");
            query.Name = "test";
            devices.AddQuery(query);
        }
        
        public async void runAsyncExample()
        {
            AccessApi access = new AccessApi(config);
            var keysTask = access.ListApiKeysAsync();
            Console.WriteLine("Dont wait for response");
            List<ApiKey> keys = keysTask.Result;
            foreach (var key in keys)
            {
                Console.WriteLine(key);
            }
        }

        private string CreateRandomName()
        {
            return DateTime.Now.ToString();
        }

        public void runUpdateCampaignExample()
        {
            UpdateApi api = new UpdateApi(config);
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.RestoreDirectory = true;
            Stream dataFile = null;
            Console.WriteLine("Choose manifest file to upload: ");
            FirmwareManifest manifest = null;
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    if ((dataFile = openFileDialog.OpenFile()) != null)
                    {
                        using (dataFile)
                        {
                            // Upload manifest
                            try
                            {
                                manifest = api.AddFirmwareManifest(dataFile, CreateRandomName());
                            }
                            catch(CloudApiException e)
                            {
                                Console.WriteLine("Error while uploading manifest, Error: " + e.ToString());
                                return;
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: Could not read file from disk. Wrror: " + ex.Message);
                }
            }
            
            // List all firware manifests
            ListParams listParamas = new ListParams();
            listParamas.Limit = 10;
            PaginatedResponse<FirmwareManifest> manifests = api.ListFirmwareManifests(listParamas);
            var enumerator = manifests.GetEnumerator();
            while(enumerator.MoveNext())
            {
                Console.WriteLine(enumerator.Current);
            }

            // List all queries

            var devicesApi = new DevicesApi(config);
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
            var campaign = new UpdateCampaign();
            campaign.Name = campaignName;
            campaign.RootManifestId = manifest.Id;
            campaign.DeviceFilter = query.QueryString;
            campaign = api.AddUpdateCampaign(campaign);
            Console.WriteLine("Created campaign : " + campaign);

            // Start update campaign
            campaign = api.StartUpdateCampaign(campaign);

            // Print status of update campaign
            int countdown = 10;
            while(countdown >=0)
            {
                Console.WriteLine(api.GetUpdateCampaignStatus(campaign.Id));
                countdown--;
            }
        }

        public void runListUpdateCampaignsExample()
        {
            UpdateApi api = new UpdateApi(config);
            var updateCampaigns = api.ListUpdateCampaigns();
            var enumerator = updateCampaigns.GetEnumerator();
            while (enumerator.MoveNext())
            {
                Console.WriteLine(enumerator.Current);
            }
        }

        public void runListFirmwareImagesExample()
        {
            UpdateApi api = new UpdateApi(config);
            var enumerator = api.ListFirmwareImages().GetEnumerator();
            while (enumerator.MoveNext())
            {
                Console.WriteLine(enumerator.Current);
            }
        }

        public void runListFirmwareManifestsExample()
        {
            UpdateApi api = new UpdateApi(config);
            var manifests = api.ListFirmwareManifests();
            var enumerator = manifests.GetEnumerator();
            while (enumerator.MoveNext())
            {
                Console.WriteLine(enumerator.Current);
            }
        }
    }
}
