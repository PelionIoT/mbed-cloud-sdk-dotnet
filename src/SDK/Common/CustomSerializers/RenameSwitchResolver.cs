// <copyright file="RenameSwitchResolver.cs" company="Arm">
// Copyright (c) Arm. All rights reserved.
// </copyright>

namespace Mbed.Cloud.Common.CustomSerializers
{
    using System;
    using System.Collections.Generic;
    using System.Reflection;
    using Newtonsoft.Json;
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

        /// <summary>
        /// Creates a <see cref="T:Newtonsoft.Json.Serialization.JsonProperty" /> for the given <see cref="T:System.Reflection.MemberInfo" />.
        /// </summary>
        /// <param name="member">The member to create a <see cref="T:Newtonsoft.Json.Serialization.JsonProperty" /> for.</param>
        /// <param name="memberSerialization">The member's parent <see cref="T:Newtonsoft.Json.MemberSerialization" />.</param>
        /// <returns>
        /// A created <see cref="T:Newtonsoft.Json.Serialization.JsonProperty" /> for the given <see cref="T:System.Reflection.MemberInfo" />.
        /// </returns>
        protected override JsonProperty CreateProperty(MemberInfo member, MemberSerialization memberSerialization)
        {
            var prop = base.CreateProperty(member, memberSerialization);

            if (!prop.Writable)
            {
                var property = member as PropertyInfo;
                if (property != null)
                {
                    var hasPrivateSetter = property.GetSetMethod(true) != null;
                    prop.Writable = hasPrivateSetter;
                }
            }

            return prop;
        }
    }
}