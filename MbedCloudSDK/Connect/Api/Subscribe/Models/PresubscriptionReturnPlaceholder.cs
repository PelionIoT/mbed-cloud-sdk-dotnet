using MbedCloudSDK.Connect.Model.Notifications;

namespace MbedCloudSDK.Connect.Api.Subscribe.Models
{
    public class PresubscriptionReturnPlaceholder
    {
        public string DeviceId { get; set; }
        public string Path { get; set; }
        public string Payload { get; set; }

        public static PresubscriptionReturnPlaceholder Map(NotificationData data)
        {
            return new PresubscriptionReturnPlaceholder
            {
                DeviceId = data.DeviceId,
                Path = data.Path,
                Payload = data.Payload,
            };
        }
    }
}