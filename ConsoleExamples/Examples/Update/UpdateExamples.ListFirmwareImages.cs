using MbedCloudSDK.Common;
using MbedCloudSDK.Update.Api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MbedCloudSDK.Common.Query;
using MbedCloudSDK.Update.Model.FirmwareImage;

namespace ConsoleExamples.Examples.Update
{
    /// @example
    public partial class UpdateExamples
    {
        public List<FirmwareImage> ListImages()
        {
            var options = new QueryOptions()
            {
                Limit = 2
            };
            var images = api.ListFirmwareImages(options).Data;
            foreach (var item in images)
            {
                Console.WriteLine(item);
            }
            return images;
        }
    }
}
