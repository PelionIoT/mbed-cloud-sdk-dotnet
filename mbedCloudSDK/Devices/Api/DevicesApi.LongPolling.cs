using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mbedCloudSDK.Devices.Api
{
    public partial class DevicesApi
    {
        private void LongPolling()
        {
            var api = new mds.Api.NotificationsApi(config.Host);
            api.Configuration.ApiKey["Authorization"] = config.ApiKey;
            api.Configuration.ApiKeyPrefix["Authorization"] = config.AuthorizationPrefix;
            while (!cancellationToken.IsCancellationRequested)
            {
                var resp = api.V2NotificationPullGet();
                if (resp == null)
                {
                    continue;
                }
                if (resp.AsyncResponses != null)
                {
                    foreach (var asyncReponse in resp.AsyncResponses)
                    {
                        byte[] data = Convert.FromBase64String(asyncReponse.Payload);
                        string payload = Encoding.UTF8.GetString(data);
                        if (asyncResponses.ContainsKey(asyncReponse.Id))
                        {
                            asyncResponses[asyncReponse.Id].Add(payload);
                        }
                    }
                }
                if (resp.Notifications != null)
                {
                    foreach (var notification in resp.Notifications)
                    {
                        byte[] data = Convert.FromBase64String(notification.Payload);
                        string payload = Encoding.UTF8.GetString(data);
                        string resourceSubs = notification.Ep + notification.Path;
                        if (resourceSubscribtions.ContainsKey(resourceSubs))
                        {
                            resourceSubscribtions[resourceSubs].Queue.Add(payload);
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Starts the long polling.
        /// </summary>
        public void StartLongPolling()
        {
            longPollingTask.Start();
        }

        /// <summary>
        /// Stops the long polling.
        /// </summary>
        public void StopLongPolling()
        {
            cancellationToken.Cancel();
        }
    }
}
