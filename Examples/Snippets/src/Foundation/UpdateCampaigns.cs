using System;
using System.Linq;
using System.Threading.Tasks;
using Mbed.Cloud;
using Mbed.Cloud.Foundation;
using NUnit.Framework;

namespace Snippets.src.Foundation
{
    [TestFixture]
    public class UpdateCampaigns
    {
        [Test]
        public async Task FirmwareUpdateCampaignLaunch()
        {
            var sdk = new SDK();

            // an example: firmware_update_campaign_launch
            var firmwareManifestRepo = sdk.Foundation().FirmwareManifestRepository();
            var firmwareManifest = firmwareManifestRepo.List(new FirmwareManifestListOptions
            {
                MaxResults = 2,
            }).FirstOrDefault();

            var updateCampaignRepo = sdk.Foundation().UpdateCampaignRepository();
            var campaign = await updateCampaignRepo.Create(new UpdateCampaign
            {
                Name = "",
                Description = "",
                RootManifestId = firmwareManifest.Id,
                DeviceFilterHelper = new DeviceListOptions().CreatedAtLessThan(new DateTime(2019, 1, 1)).Filter,
            });

            Console.WriteLine((await updateCampaignRepo.Read(campaign.Id)).Phase);

            await updateCampaignRepo.Start(campaign.Id);

            Console.WriteLine((await updateCampaignRepo.Read(campaign.Id)).Phase);

            foreach (var metadata in updateCampaignRepo.DeviceMetadata(campaign.Id))
            {
                Console.WriteLine(metadata);
            }
            // end of example
        }
    }
}