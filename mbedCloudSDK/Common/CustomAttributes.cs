using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MbedCloudSDK.Common
{
    public class NameOverrideAttribute : Attribute
    {
        public string Name { get; set; }
    }
}
