using System;

namespace MbedCloudSDK.IntegrationTests.Foundation.Models
{
    public class Instance<T>
    {
        public string Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public T MyInstance { get; set; }

        public Instance(T instance)
        {
            MyInstance = instance;
            Id = Guid.NewGuid().ToString();
            CreatedAt = DateTime.Now;
        }
    }
}