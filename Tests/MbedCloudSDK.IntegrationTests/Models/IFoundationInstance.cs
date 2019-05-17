using System.Collections.Generic;

namespace MbedCloudSDK.IntegrationTests.Models
{
    public interface IFoundationInstance
    {
        string Name { get; set; }
        Dictionary<string, Method> Methods { get; set; }
        FoundationInstanceResponse ToJson();
        object ExecuteMethod(string methodId, Dictionary<string, object> parameters);
    }
}