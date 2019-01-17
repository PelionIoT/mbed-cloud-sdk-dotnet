// <copyright file="RenameSwitchResolver.cs" company="Arm">
// Copyright (c) Arm. All rights reserved.
// </copyright>

namespace Mbed.Cloud.Foundation.Common.CustomSerializers
{
    using System;
    using System.Collections.Generic;
    using System.Reflection;
    using Newtonsoft.Json.Serialization;

    /// <summary>
    /// RenameSwitchResolver
    /// </summary>
    /// <seealso cref="Newtonsoft.Json.Serialization.DefaultContractResolver" />
    public sealed class RenameSwitchResolver : DefaultContractResolver
    {
        /// <summary>
        /// Determines which contract type is created for the given type.
        /// </summary>
        /// <param name="objectType">Type of the object.</param>
        /// <returns>
        /// A <see cref="T:Newtonsoft.Json.Serialization.JsonContract" /> for the given type.
        /// </returns>
        protected override JsonContract CreateContract(Type objectType)
        {
            var renames = objectType.GetField("Renames", BindingFlags.NonPublic | BindingFlags.Static);

            if (renames != null)
            {
                var renameDict = renames.GetValue(null) as Dictionary<string, string>;
                NamingStrategy = new SnakeCaseNamingStrategyWithRenaming(renameDict);
            }
            else
            {
                if (NamingStrategy == null)
                {
                    NamingStrategy = new SnakeCaseNamingStrategy();
                }
            }

            return base.CreateContract(objectType);
        }
    }
}