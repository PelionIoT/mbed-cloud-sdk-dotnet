// <copyright file="UpdateExamples.ListFirmwareImages.cs" company="Arm">
// Copyright (c) Arm. All rights reserved.
// </copyright>

namespace ConsoleExamples.Examples.Update
{
    using System;
    using System.Collections.Generic;
    using MbedCloudSDK.Common.Query;
    using MbedCloudSDK.Update.Model.FirmwareImage;

    /// <summary>
    /// Update examples
    /// </summary>
    public partial class UpdateExamples
    {
        /// <summary>
        /// List of first 2 firmware images
        /// </summary>
        /// <returns>List of firmware images</returns>
        public List<FirmwareImage> ListImages()
        {
            var options = new QueryOptions
            {
                Limit = 5,
            };
            var images = api.ListFirmwareImages(options).Data;
            foreach (var item in images)
            {
                Console.WriteLine(item);
            }

            return images;
        }

        /// <summary>
        /// Add a firmware image
        /// </summary>
        /// <returns>The firmware image</returns>
        public FirmwareImage AddFirmwareImage()
        {
            var firmwareImage = api.AddFirmwareImage("./images/firmware_image.bin", "new firmware image", "description");
            Console.WriteLine(firmwareImage);
            api.DeleteFirmwareImage(firmwareImage.Id);
            return firmwareImage;
        }
    }
}
