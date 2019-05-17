// <copyright file="SnakeCaseNamingStrategyWithRenaming.cs" company="Arm">
// Copyright (c) Arm. All rights reserved.
// </copyright>

namespace Mbed.Cloud.Common.CustomSerializers
{
    using System;
    using System.Collections.Generic;
    using Newtonsoft.Json.Serialization;

    /// <summary>
    /// SnakeCaseNamingStrategyWithRenaming
    /// </summary>
    /// <seealso cref="Newtonsoft.Json.Serialization.SnakeCaseNamingStrategy" />
    public sealed class SnakeCaseNamingStrategyWithRenaming : SnakeCaseNamingStrategy
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SnakeCaseNamingStrategyWithRenaming"/> class.
        /// </summary>
        /// <param name="mappings">The mappings.</param>
        public SnakeCaseNamingStrategyWithRenaming(Dictionary<string, string> mappings)
        {
            PropertyMappings = mappings;
        }

        private Dictionary<string, string> PropertyMappings { get; set; }

        /// <summary>
        /// Resolves the name of the property.
        /// </summary>
        /// <param name="propertyName">Name of the property.</param>
        /// <returns>string</returns>
        protected override string ResolvePropertyName(string propertyName)
        {
            var resolved = PropertyMappings.TryGetValue(propertyName, out string resolvedName);
            return resolved ? resolvedName : base.ResolvePropertyName(propertyName);
        }
    }
}