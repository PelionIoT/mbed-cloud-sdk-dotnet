// <copyright file="DeviceEventObserver.cs" company="Arm">
// Copyright (c) Arm. All rights reserved.
// </copyright>

namespace MbedCloudSDK.Connect.Api.Subscribe.Observers.DeviceEvent
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using MbedCloudSDK.Connect.Api.Subscribe.Models;
    using MbedCloudSDK.Connect.Model.Notifications;

    /// <summary>
    /// Device Stae Observer
    /// </summary>
    public class DeviceEventObserver : Observer<DeviceEventData, DeviceEventFilter>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DeviceEventObserver"/> class.
        /// Device State Observer
        /// </summary>
        /// <example>
        /// This example shows how you can use the DeviceStateObserver. For more examples, see the Examples project.
        /// <code>
        /// var observer = connect.Subscribe.DeviceEvents();
        /// // subscribe to Deregistration and Registration events
        /// observer.Where(f => f.Event == DeviceEventEnum.DeRegistration || f.Event == DeviceEventEnum.Registration);
        /// // add a callback to print message when recieved
        /// observer.OnNotify += res => Console.WriteLine(res);
        ///     // take two values
        /// var firstValue = observer.Next();
        /// var secondValue = observer.Next();
        /// </code>
        /// </example>
        public DeviceEventObserver()
        {
        }

        /// <summary>
        /// Notify this observer
        /// </summary>
        /// <param name="data">The device event data</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        public override async Task NotifyAsync(DeviceEventData data)
        {
            if (!FilterFuncs.Any())
            {
                await base.NotifyAsync(data);
            }
            else
            {
                if (FilterFuncs.TrueForAll(f => f.Invoke(new DeviceEventFilter { Id = data.DeviceId, Event = data.State })))
                {
                    await base.NotifyAsync(data);
                }
            }
        }

        /// <summary>
        /// Filter the device events
        /// </summary>
        /// <param name="filterFunc">Function to be run on the device events</param>
        /// <returns>The device event observer so Where calls can be chained</returns>
        public DeviceEventObserver Filter(Func<DeviceEventFilter, bool> filterFunc)
        {
            FilterFuncs.Add(filterFunc);
            return this;
        }
    }
}