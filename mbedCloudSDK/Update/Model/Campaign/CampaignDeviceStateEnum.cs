using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace mbedCloudSDK.Update.Model.Campaign
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
        Pending,
            
        /// <summary>
        /// Enum Updateddevicecatalog for "updated_device_catalog"
        /// </summary>
        [EnumMember(Value = "updated_device_catalog")]
        Updateddevicecatalog,
            
        /// <summary>
        /// Enum Updatedconnectorchannel for "updated_connector_channel"
        /// </summary>
        [EnumMember(Value = "updated_connector_channel")]
        Updatedconnectorchannel,
            
        /// <summary>
        /// Enum Deployed for "deployed"
        /// </summary>
        [EnumMember(Value = "deployed")]
        Deployed,
            
        /// <summary>
        /// Enum Manifestremoved for "manifestremoved"
        /// </summary>
        [EnumMember(Value = "manifestremoved")]
        Manifestremoved
    }
}
