// <copyright file="UpdateExamples.ListUpdateCampaigns.cs" company="Arm">
// Copyright (c) Arm. All rights reserved.
// </copyright>

namespace ConsoleExamples.Examples.Update
{
    using System;
    using System.Collections.Generic;
    using MbedCloudSDK.Common.Query;
    using MbedCloudSDK.Update.Model.Campaign;

    /// <summary>
    /// Update examples
    /// </summary>
    public partial class UpdateExamples
    {
        /// <summary>
        /// List the first 3 update campaigns
        /// </summary>
        /// <returns>List of campaigns</returns>
        public List<Campaign> ListCampaigns()
        {
            var options = new QueryOptions
            {
                Limit = 5,
            };
            var updateCampaigns = api.ListCampaigns(options).Data;
            foreach (var item in updateCampaigns)
            {
                Console.WriteLine(item);
            }

            return updateCampaigns;
        }
    }
}
