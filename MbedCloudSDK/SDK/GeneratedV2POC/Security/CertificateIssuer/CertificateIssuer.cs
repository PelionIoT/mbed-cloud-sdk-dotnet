// <auto-generated>
//
// Generated by
//                     _                        _
//   /\/\   __ _ _ __ | |__   __ _ ___ ___  ___| |_
//  /    \ / _` | '_ \| '_ \ / _` / __/ __|/ _ \ __|
// / /\/\ \ (_| | | | | | | | (_| \__ \__ \  __/ |_
// \/    \/\__,_|_| |_|_| |_|\__,_|___/___/\___|\__| v 1.0.0
//
// <copyright file="CertificateIssuer.cs" company="Arm">
// Copyright (c) Arm. All rights reserved.
// </copyright>
// </auto-generated>

namespace MbedCloud.SDK.Entities
{
    using MbedCloud.SDK.Common;
    using System;
    using System.Collections.Generic;
    using MbedCloud.SDK.Enums;

    /// <summary>
    /// CertificateIssuer
    /// </summary>
    public class CertificateIssuer : Entity
    {
        /// <summary>
        /// created_at
        /// </summary>
        public DateTime? CreatedAt
        {
            get;
            internal set;
        }

        /// <summary>
        /// description
        /// </summary>
        public string Description
        {
            get;
            set;
        }

        /// <summary>
        /// issuer_attributes
        /// </summary>
        public Dictionary<string, string> IssuerAttributes
        {
            get;
            set;
        }

        /// <summary>
        /// issuer_type
        /// </summary>
        public CertificateIssuerTypeEnum? IssuerType
        {
            get;
            set;
        }

        /// <summary>
        /// name
        /// </summary>
        public string Name
        {
            get;
            set;
        }
    }
}