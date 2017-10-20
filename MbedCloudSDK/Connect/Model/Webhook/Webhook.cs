// <copyright file="Webhook.cs" company="Arm">
// Copyright (c) Arm. All rights reserved.
// </copyright>

namespace MbedCloudSDK.Connect.Model.Webhook
{
    using System.Collections.Generic;
    using Newtonsoft.Json;

    /// <summary>
    /// Webhook
    /// </summary>
    public class Webhook
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Webhook"/> class.
        /// Default constructor
        /// </summary>
        public Webhook()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Webhook"/> class.
        /// Create new webhook
        /// </summary>
        /// <param name="headers">Headers</param>
        /// <param name="url">Url</param>
        public Webhook(string url, Dictionary<string, string> headers = null)
        {
            Url = url;
            Headers = headers;
        }

        /// <summary>
        /// Gets the url of the webhook
        /// </summary>
        [JsonProperty]
        public string Url { get; private set; }

        /// <summary>
        /// Gets k/V dictionary of any headers
        /// </summary>
        [JsonProperty]
        public Dictionary<string, string> Headers { get; private set; }

        /// <summary>
        /// Map from api webhook to webhook
        /// </summary>
        /// <param name="data">Webhook</param>
        /// <returns>Webhook</returns>
        public static Webhook Map(mds.Model.Webhook data)
        {
            var webhook = new Webhook
            {
                Url = data.Url,
                Headers = data.Headers
            };
            return webhook;
        }

        /// <summary>
        /// Map to api webhook from webhook
        /// </summary>
        /// <param name="data">Webhook</param>
        /// <returns>Webhook</returns>
        public static mds.Model.Webhook MapToApiWebook(Webhook data)
        {
            var webhook = new mds.Model.Webhook(data.Url)
            {
                Headers = data.Headers
            };
            return webhook;
        }
    }
}