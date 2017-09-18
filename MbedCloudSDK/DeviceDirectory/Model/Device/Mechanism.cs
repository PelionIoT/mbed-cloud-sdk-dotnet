using System;
using System.Runtime.Serialization;


namespace MbedCloudSDK.DeviceDirectory.Model.Device
{
    /// <summary>
    /// The ID of the channel used to communicate with the device
    /// </summary>
    public enum Mechanism
    {
        /// <summary>
        /// Enum Connector for "connector"
        /// </summary>
        [EnumMember(Value = "connector")]
        connector,

        /// <summary>
        /// Enum Direct for "direct"
        /// </summary>
        [EnumMember(Value = "direct")]
        direct
    }
}
