using System.Collections.Generic;

namespace MbedCloudSDK.Connect.Model.Webhook
{
    /// <summary>
    /// Webhook
    /// </summary>
    public class Webhook
    {
        /// <summary>
        ///The url of the webhook
        /// </summary>
        public string Url { get; set; }

        /// <summary>
        ///K/V dictionary of any headers
        /// </summary>
        public Dictionary<string, string> Headers { get; set; }

        /// <summary>
        /// Default constructor
        /// </summary>
        public Webhook() {}

        /// <summary>
        /// Create new webhook
        /// </summary>
        public Webhook(string url, Dictionary<string, string> headers = null)
        {
            Url = url;
            Headers = headers;
        }

        /// <summary>
        /// Map from api webhook to webhook
        /// </summary>
        public static Webhook Map(mds.Model.Webhook data)
        {
            var webhook = new Webhook();
            webhook.Url = data.Url;
            webhook.Headers = data.Headers;
            return webhook;
        }

        /// <summary>
        /// Map to api webhook from webhook
        /// </summary>
        public static mds.Model.Webhook MapToApiWebook(Webhook data)
        {
            var webhook = new mds.Model.Webhook(data.Url);
            webhook.Headers = data.Headers;
            return webhook;
        }
    }
}