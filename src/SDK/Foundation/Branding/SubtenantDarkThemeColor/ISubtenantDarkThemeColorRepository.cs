// <auto-generated>
//
// Generated by
//                     _                        _
//   /\/\   __ _ _ __ | |__   __ _ ___ ___  ___| |_
//  /    \ / _` | '_ \| '_ \ / _` / __/ __|/ _ \ __|
// / /\/\ \ (_| | | | | | | | (_| \__ \__ \  __/ |_
// \/    \/\__,_|_| |_|_| |_|\__,_|___/___/\___|\__| v 2.0.0
//
// <copyright file="ISubtenantDarkThemeColorRepository.cs" company="Arm">
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
    /// SubtenantDarkThemeColorRepository
    /// </summary>
    public interface ISubtenantDarkThemeColorRepository
    {
        Task Delete(string accountId, string reference);
        PaginatedResponse<ISubtenantDarkThemeColorSubtenantDarkThemeColorListOptions, SubtenantDarkThemeColor> List(string accountId, ISubtenantDarkThemeColorSubtenantDarkThemeColorListOptions options = null);
        Task<SubtenantDarkThemeColor> Read(string accountId, string reference);
        Task<SubtenantDarkThemeColor> Update(string accountId, string reference, SubtenantDarkThemeColor request);
    }
}