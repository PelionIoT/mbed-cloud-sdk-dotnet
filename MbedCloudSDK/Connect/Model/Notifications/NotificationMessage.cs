// <copyright file="NotificationMessage.cs" company="Arm">
// Copyright (c) Arm. All rights reserved.
// </copyright>
namespace MbedCloudSDK.Connect.Model.Notifications
{
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Notification Message
    /// </summary>
    public class NotificationMessage
    {
        /// <summary>
        /// Gets the AsyncResponses
        /// </summary>
        /// <returns>AsyncResponses</returns>
        public List<AsyncIdResponse> AsyncResponses { get; private set; }

        /// <summary>
        /// Gets the DeRegistrations
        /// </summary>
        /// <returns>DeRegistrations</returns>
        public List<string> DeRegistrations { get; private set; }

        /// <summary>
        /// Gets the RegistrationUpdates
        /// </summary>
        /// <returns>RegistrationUpdates</returns>
        public List<EndpointData> RegistrationUpdates { get; private set; }

        /// <summary>
        /// Gets the Registrations
        /// </summary>
        /// <returns>Registrations</returns>
        public List<EndpointData> Registrations { get; private set; }

        /// <summary>
        /// Gets the Notifications
        /// </summary>
        /// <returns>Notifications</returns>
        public List<NotificationData> Notifications { get; private set; }

        /// <summary>
        /// Gets the RegistrationsExpired
        /// </summary>
        /// <returns>RegistrationsExpired</returns>
        public List<string> RegistrationsExpired { get; private set; }

        /// <summary>
        /// Map the notification message
        /// </summary>
        /// <param name="data">Notification Message Data</param>
        /// <returns>The Notification Message</returns>
        public static NotificationMessage Map(mds.Model.NotificationMessage data)
        {
            var notificationMessage = new NotificationMessage
            {
                AsyncResponses = data?.AsyncResponses?.Select(a => AsyncIdResponse.Map(a))?.ToList() ?? Enumerable.Empty<AsyncIdResponse>().ToList(),
                DeRegistrations = data?.DeRegistrations ?? Enumerable.Empty<string>().ToList(),
                RegistrationUpdates = data?.RegUpdates?.Select(r => EndpointData.Map(r))?.ToList() ?? Enumerable.Empty<EndpointData>().ToList(),
                Registrations = data?.Registrations?.Select(r => EndpointData.Map(r))?.ToList() ?? Enumerable.Empty<EndpointData>().ToList(),
                Notifications = data?.Notifications?.Select(n => NotificationData.Map(n))?.ToList() ?? Enumerable.Empty<NotificationData>().ToList(),
                RegistrationsExpired = data?.RegistrationsExpired,
            };

            return notificationMessage;
        }
    }
}