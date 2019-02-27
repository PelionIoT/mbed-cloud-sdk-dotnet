// <auto-generated>
//
// Generated by
//                     _                        _
//   /\/\   __ _ _ __ | |__   __ _ ___ ___  ___| |_
//  /    \ / _` | '_ \| '_ \ / _` / __/ __|/ _ \ __|
// / /\/\ \ (_| | | | | | | | (_| \__ \__ \  __/ |_
// \/    \/\__,_|_| |_|_| |_|\__,_|___/___/\___|\__| v 2.0.0
//
// <copyright file="IDeviceRepository.cs" company="Arm">
// Copyright (c) Arm. All rights reserved.
// </copyright>
// </auto-generated>

namespace Mbed.Cloud.Foundation.Entities
{
    using Mbed.Cloud.Foundation.Common;
    using Mbed.Cloud.Foundation.ListOptions;
    using Mbed.Cloud.Foundation.Entities;
    using System.Threading.Tasks;
    using MbedCloudSDK.Exceptions;
    using System.Collections.Generic;
    using System;
    using Mbed.Cloud.Foundation.RestClient;

    /// <summary>
    /// DeviceRepository
    /// </summary>
    public interface IDeviceRepository
    {
        Task<Device> Create(Device request);
        Task Delete(string id);
        Task<Device> Get(string id);
        PaginatedResponse<IDeviceListOptions, Device> List(IDeviceListOptions options = null);
        Task<CertificateEnrollment> RenewCertificate(string certificateName, string id);
        Task<Device> Update(string id, Device request);
    }
}