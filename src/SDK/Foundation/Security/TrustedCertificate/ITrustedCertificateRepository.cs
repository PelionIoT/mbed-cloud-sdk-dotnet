// <auto-generated>
//
// Generated by
//                     _                        _
//   /\/\   __ _ _ __ | |__   __ _ ___ ___  ___| |_
//  /    \ / _` | '_ \| '_ \ / _` / __/ __|/ _ \ __|
// / /\/\ \ (_| | | | | | | | (_| \__ \__ \  __/ |_
// \/    \/\__,_|_| |_|_| |_|\__,_|___/___/\___|\__| v 2.0.0
//
// <copyright file="ITrustedCertificateRepository.cs" company="Arm">
// Copyright (c) Arm. All rights reserved.
// </copyright>
// </auto-generated>

namespace Mbed.Cloud.Foundation.Entities
{
    using Mbed.Cloud.Foundation.Common;
    using Mbed.Cloud.Foundation.Entities;
    using Mbed.Cloud.Foundation.ListOptions;
    using System.Threading.Tasks;
    using MbedCloudSDK.Exceptions;
    using System.Collections.Generic;
    using System;
    using Mbed.Cloud.Foundation.RestClient;

    /// <summary>
    /// TrustedCertificateRepository
    /// </summary>
    public interface ITrustedCertificateRepository
    {
        Task<TrustedCertificate> Create(TrustedCertificate request);
        Task Delete(string id);
        Task<TrustedCertificate> Get(string id);
        Task<DeveloperCertificate> GetDeveloperCertificateInfo(string id);
        PaginatedResponse<ITrustedCertificateListOptions, TrustedCertificate> List(ITrustedCertificateListOptions options = null);
        Task<TrustedCertificate> Update(string id, TrustedCertificate request);
    }
}