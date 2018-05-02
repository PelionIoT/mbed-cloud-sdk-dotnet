using MbedCloudSDK.Connect.Model.Notifications;

namespace MbedCloudSDK.Connect.Api.Subscribe.Models
{
    public class ResourceValueChange
    {
        public string DeviceId { get; set; }
        public string Path { get; set; }
        public string Payload { get; set; }

        public static ResourceValueChange Map(NotificationData data)
        {
            return new ResourceValueChange
            {
                DeviceId = data.DeviceId,
                Path = data.Path,
                Payload = data.Payload,
            };
        }
    }
}