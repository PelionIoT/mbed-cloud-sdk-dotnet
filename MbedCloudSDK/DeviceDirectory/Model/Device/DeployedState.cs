using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace MbedCloudSDK.DeviceDirectory.Model.Device
{
    /// <summary>
    /// The state of the device's deployment
    /// </summary>
    public enum DeployedState
    {
        /// <summary>
        /// Enum Development for "development"
        /// </summary>
        [EnumMember(Value = "development")]
        development,

        /// <summary>
        /// Enum Production for "production"
        /// </summary>
        [EnumMember(Value = "production")]
        production
    }
}
