using System;
using System.Reflection;

namespace MbedCloudSDK.IntegrationTests.Models
{
    public class Method
    {
        public string Name { get; set; }
        public string Entity { get; set; }
        public MethodInfo MethodInfo { get; set; }

        public Method(string name, string entity, MethodInfo methodInfo)
        {
            Name = name;
            Entity = entity;
            MethodInfo = methodInfo;
        }

        public object Call() {
            throw new NotImplementedException();
        }

    }
}