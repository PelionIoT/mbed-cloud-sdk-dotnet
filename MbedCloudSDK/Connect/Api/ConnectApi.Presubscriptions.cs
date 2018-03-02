// <copyright file="ConnectApi.Presubscriptions.cs" company="Arm">
// Copyright (c) Arm. All rights reserved.
// </copyright>

namespace MbedCloudSDK.Connect.Api
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using MbedCloudSDK.Connect.Model.Subscription;
    using MbedCloudSDK.Exceptions;

    /// <summary>
    /// Connect Api
    /// </summary>
    public partial class ConnectApi
    {
        /// <summary>
        /// Update pre-subscription data. Pre-subscription data will be removed for empty list.
        /// </summary>
        /// <param name="presubscriptions">Array of <see cref="Presubscription"/></param>
        /// <example>
        /// <code>
        /// try
        /// {
        ///     var presubscription = new Presubscription
        ///     {
        ///         DeviceId = "015bb66a92a30000000000010010006d",
        ///         ResourcePaths = new List { "/5001/0/1" },
        ///     };
        ///     connectApi.UpdatePresubscriptions(new Presubscription[] { presubscription });
        ///
        ///     foreach (var item in api.ListPresubscriptions())
        ///     {
        ///         Console.WriteLine(item);
        ///     }
        /// }
        /// catch (MbedCloudApiException)
        /// {
        ///     throw;
        /// }
        /// </code>
        /// </example>
        /// <exception cref="CloudApiException">CloudApiException</exception>
        public void UpdatePresubscriptions(Presubscription[] presubscriptions)
        {
            var presubscriptionArray = new mds.Model.PresubscriptionArray();
            foreach (var presubscription in presubscriptions)
            {
                var updatedPresubscription = new mds.Model.Presubscription(presubscription.DeviceId, presubscription.DeviceType, presubscription.ResourcePaths);
                presubscriptionArray.Add(updatedPresubscription);
            }

            try
            {
                subscriptionsApi.V2SubscriptionsPut(presubscriptionArray);
            }
            catch (mds.Client.ApiException ex)
            {
                throw new mds.Client.ApiException(ex.ErrorCode, ex.Message, ex.ErrorContent);
            }
        }

        /// <summary>
        /// Get a list of pre-subscription data.
        /// </summary>
        /// <returns>List of <see cref="Presubscription"/></returns>
        /// <example>
        /// <code>
        /// try
        /// {
        ///     var presubscriptions = connectApi.ListPresubscriptions();
        ///     foreach (var item in presubscriptions)
        ///     {
        ///         Console.WriteLine(item);
        ///     }
        ///     return presubscriptions;
        /// }
        /// catch (MbedCloudApiException)
        /// {
        ///     throw;
        /// }
        /// </code>
        /// </example>
        /// <exception cref="CloudApiException">CloudApiException</exception>
        public Presubscription[] ListPresubscriptions()
        {
            try
            {
                return subscriptionsApi.V2SubscriptionsGet().Select(p => Presubscription.Map(p)).ToArray();
            }
            catch (mds.Client.ApiException ex)
            {
                throw new CloudApiException(ex.ErrorCode, ex.Message, ex.ErrorContent);
            }
        }

        /// <summary>
        /// Delete the presubscriptions
        /// </summary>
        /// <example>
        /// <code>
        /// try
        /// {
        ///     connectApi.DeletePresubscriptions();
        /// }
        /// catch (MbedCloudApiException)
        /// {
        ///     throw;
        /// }
        /// </code>
        /// </example>
        /// <exception cref="CloudApiException">CloudApiException</exception>
        public void DeletePresubscriptions()
        {
            try
            {
                subscriptionsApi.V2SubscriptionsPut(new mds.Model.PresubscriptionArray());
            }
            catch (mds.Client.ApiException ex)
            {
                throw new mds.Client.ApiException(ex.ErrorCode, ex.Message, ex.ErrorContent);
            }
        }

        /// <summary>
        /// Remove all subscriptions
        /// </summary>
        /// <remarks>
        /// Warning: This could be slow for large numbers of connected devices. If possible, explicitly delete subscriptions known to have been created.
        /// </remarks>
        /// <example>
        /// <code>
        /// try
        /// {
        ///     connectApi.DeleteSubscriptions();
        /// }
        /// catch (CloudApiException)
        /// {
        ///     throw;
        /// }
        /// </code>
        /// </example>
        /// <exception cref="CloudApiException">CloudApiException</exception>
        public void DeleteSubscriptions()
        {
            try
            {
                foreach (var item in ListConnectedDevices())
                {
                    try
                    {
                        DeleteDeviceSubscriptions(item.Id);
                    }
                    catch (CloudApiException)
                    {
                        Console.WriteLine("No subscriptions found for this device");
                    }
                }

                ResourceSubscribtions.Clear();
            }
            catch (mds.Client.ApiException e)
            {
                throw new CloudApiException(e.ErrorCode, e.Message, e.ErrorContent);
            }
        }
    }
}