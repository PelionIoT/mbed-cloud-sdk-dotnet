// <copyright file="LongNameContractResolver.cs" company="Arm">
// Copyright (c) Arm. All rights reserved.
// </copyright>

namespace MbedCloudSDK.Common
{
    using System;
    using System.Collections.Generic;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Serialization;

    /// <summary>
    /// Long name contract resolver
    /// </summary>
    /// <seealso cref="Newtonsoft.Json.Serialization.DefaultContractResolver" />
    internal class LongNameContractResolver : DefaultContractResolver
    {
        /// <summary>
        /// Creates properties for the given <see cref="T:Newtonsoft.Json.Serialization.JsonContract" />.
        /// </summary>
        /// <param name="type">The type to create properties for.</param>
        /// <param name="memberSerialization">The member serialization mode for the type.</param>
        /// <returns>
        /// Properties for the given <see cref="T:Newtonsoft.Json.Serialization.JsonContract" />.
        /// </returns>
        protected override IList<JsonProperty> CreateProperties(Type type, MemberSerialization memberSerialization)
        {
            // Let the base class create all the JsonProperties
            // using the short names
            var list = base.CreateProperties(type, memberSerialization);

            // Now inspect each property and replace the
            // short name with the real property name
            foreach (JsonProperty prop in list)
            {
                prop.PropertyName = prop.UnderlyingName;
            }

            return list;
        }
    }
}