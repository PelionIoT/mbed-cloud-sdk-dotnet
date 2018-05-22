using System.Collections.Generic;

namespace WebhookExample.Models
{
    public class SubscribeModel
    {
        public string DeviceId { get; set; }
        public List<string> ResourcePaths { get; set; }
    }
}