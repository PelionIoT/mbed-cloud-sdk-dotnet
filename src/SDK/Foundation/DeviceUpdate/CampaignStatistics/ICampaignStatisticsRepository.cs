// <auto-generated>
//
// Generated by
//                     _                        _
//   /\/\   __ _ _ __ | |__   __ _ ___ ___  ___| |_
//  /    \ / _` | '_ \| '_ \ / _` / __/ __|/ _ \ __|
// / /\/\ \ (_| | | | | | | | (_| \__ \__ \  __/ |_
// \/    \/\__,_|_| |_|_| |_|\__,_|___/___/\___|\__| v 2.0.0
//
// <copyright file="ICampaignStatisticsRepository.cs" company="Arm">
// Copyright (c) Arm. All rights reserved.
// </copyright>
// </auto-generated>

namespace Mbed.Cloud.Foundation
{
    using Mbed.Cloud.Common;
    using Mbed.Cloud.Foundation;
    using System.Threading.Tasks;
    using MbedCloudSDK.Exceptions;
    using System.Collections.Generic;
    using System;
    using Mbed.Cloud.RestClient;

    /// <summary>
    /// CampaignStatisticsRepository
    /// </summary>
    public interface ICampaignStatisticsRepository
    {
        PaginatedResponse<ICampaignStatisticsCampaignStatisticsEventsListOptions, CampaignStatisticsEvents> Events(string campaignId, string id, ICampaignStatisticsCampaignStatisticsEventsListOptions options = null);
        PaginatedResponse<ICampaignStatisticsListOptions, CampaignStatistics> List(string campaignId, ICampaignStatisticsListOptions options = null);
        Task<CampaignStatistics> Read(string campaignId, string id);
    }
}