// <auto-generated>
//
// Generated by
//                     _                        _
//   /\/\   __ _ _ __ | |__   __ _ ___ ___  ___| |_
//  /    \ / _` | '_ \| '_ \ / _` / __/ __|/ _ \ __|
// / /\/\ \ (_| | | | | | | | (_| \__ \__ \  __/ |_
// \/    \/\__,_|_| |_|_| |_|\__,_|___/___/\___|\__| v 2.0.0
//
// <copyright file="IPolicy.cs" company="Arm">
// Copyright (c) Arm. All rights reserved.
// </copyright>
// </auto-generated>

namespace Mbed.Cloud.Foundation
{
    using Mbed.Cloud.Common;
    using Mbed.Cloud.Foundation.Enums;

    /// <summary>
    /// Policy
    /// </summary>
    public interface IPolicy
    {
        /// <summary>
        /// action
        /// </summary>
        string Action
        {
            get;
        }

        /// <summary>
        /// allow
        /// </summary>
        bool? Allow
        {
            get;
        }

        /// <summary>
        /// feature
        /// </summary>
        string Feature
        {
            get;
        }

        /// <summary>
        /// inherited
        /// </summary>
        bool? Inherited
        {
            get;
        }

        /// <summary>
        /// inherited_from
        /// </summary>
        string InheritedFrom
        {
            get;
        }

        /// <summary>
        /// inherited_type
        /// </summary>
        PolicyInheritedType? InheritedType
        {
            get;
        }

        /// <summary>
        /// resource
        /// </summary>
        string Resource
        {
            get;
        }
    }
}