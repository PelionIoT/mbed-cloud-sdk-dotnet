using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace mbedCloudSDK.Update.Model.Campaign
{
    /// <summary>
    /// The state of the campaign
    /// </summary>
    /// <value>The state of the campaign</value>
    public enum UpdateCampaignState
    {
        /// <summary>
        /// Enum Draft for "draft"
        /// </summary>
        [EnumMember(Value = "draft")]
        Draft,

        /// <summary>
        /// Enum Scheduled for "scheduled"
        /// </summary>
        [EnumMember(Value = "scheduled")]
        Scheduled,

        /// <summary>
        /// Enum Devicefetch for "devicefetch"
        /// </summary>
        [EnumMember(Value = "devicefetch")]
        Devicefetch,

        /// <summary>
        /// Enum Devicecopy for "devicecopy"
        /// </summary>
        [EnumMember(Value = "devicecopy")]
        Devicecopy,

        /// <summary>
        /// Enum Devicecopycomplete for "devicecopycomplete"
        /// </summary>
        [EnumMember(Value = "devicecopycomplete")]
        Devicecopycomplete,

        /// <summary>
        /// Enum Publishing for "publishing"
        /// </summary>
        [EnumMember(Value = "publishing")]
        Publishing,

        /// <summary>
        /// Enum Deploying for "deploying"
        /// </summary>
        [EnumMember(Value = "deploying")]
        Deploying,

        /// <summary>
        /// Enum Deployed for "deployed"
        /// </summary>
        [EnumMember(Value = "deployed")]
        Deployed,

        /// <summary>
        /// Enum Manifestremoved for "manifestremoved"
        /// </summary>
        [EnumMember(Value = "manifestremoved")]
        Manifestremoved,

        /// <summary>
        /// Enum Expired for "expired"
        /// </summary>
        [EnumMember(Value = "expired")]
        Expired
    }
}
