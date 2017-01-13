using System;
using System.Runtime.Serialization;


namespace mbedCloudSDK.Devices.Model.Device
{
    /// <summary>
    /// The ID of the channel used to communicate with the device
    /// </summary>
    /// <value>The ID of the channel used to communicate with the device</value>
    public enum Mechanism
    {
        /// <summary>
        /// Enum Connector for "connector"
        /// </summary>
        [EnumMember(Value = "connector")]
        Connector,

        /// <summary>
        /// Enum Direct for "direct"
        /// </summary>
        [EnumMember(Value = "direct")]
        Direct
    }
}
