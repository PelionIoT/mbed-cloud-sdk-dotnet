// <copyright file="RenameSwitchResolver.cs" company="Arm">
// Copyright (c) Arm. All rights reserved.
// </copyright>

namespace MbedCloudSDK.Common.CustomSerializers
{
    using System;
    using System.Collections.Generic;
    using Newtonsoft.Json.Serialization;

    /// <summary>
    /// RenameSwitchResolver
    /// </summary>
    /// <seealso cref="Newtonsoft.Json.Serialization.DefaultContractResolver" />
    public sealed class RenameSwitchResolver : DefaultContractResolver
    {
        private readonly Dictionary<Type, Dictionary<string, string>> renames;

        /// <summary>
        /// Initializes a new instance of the <see cref="RenameSwitchResolver"/> class.
        /// </summary>
        /// <param name="renames">The renames.</param>
        public RenameSwitchResolver(Dictionary<Type, Dictionary<string, string>> renames = null)
        {
            this.renames = renames ?? new Dictionary<Type, Dictionary<string, string>>();
        }

        /// <summary>
        /// Determines which contract type is created for the given type.
        /// </summary>
        /// <param name="objectType">Type of the object.</param>
        /// <returns>
        /// A <see cref="T:Newtonsoft.Json.Serialization.JsonContract" /> for the given type.
        /// </returns>
        protected override JsonContract CreateContract(Type objectType)
        {
            if (renames.ContainsKey(objectType))
            {
                NamingStrategy = new SnakeCaseNamingStrategyWithRenaming(renames[objectType]);
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