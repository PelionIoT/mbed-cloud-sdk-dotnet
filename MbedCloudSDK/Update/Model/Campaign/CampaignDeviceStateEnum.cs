﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace MbedCloudSDK.Update.Model.Campaign
{
    /// <summary>
    /// Device state in update campaign.
    /// </summary>
    public enum CampaignDeviceStateEnum
    {
        /// <summary>
        /// Enum Pending for "pending"
        /// </summary>
        [EnumMember(Value = "pending")]
        pending,
            
        /// <summary>
        /// Enum Updateddevicecatalog for "updated_device_catalog"
        /// </summary>
        [EnumMember(Value = "updated_device_catalog")]
        updated_device_catalog,
            
        /// <summary>
        /// Enum Updatedconnectorchannel for "updated_connector_channel"
        /// </summary>
        [EnumMember(Value = "updated_connector_channel")]
        updated_connector_channel,
            
        /// <summary>
        /// Enum Deployed for "deployed"
        /// </summary>
        [EnumMember(Value = "deployed")]
        deployed,
            
        /// <summary>
        /// Enum Manifestremoved for "manifestremoved"
        /// </summary>
        [EnumMember(Value = "manifestremoved")]
        manifestremoved
    }
}