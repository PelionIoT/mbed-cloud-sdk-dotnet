// <copyright file="FilterFunctionCollection.cs" company="Arm">
// Copyright (c) Arm. All rights reserved.
// </copyright>

namespace MbedCloudSDK.Connect.Api.Subscribe.Collections
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// The collection of local filter functions
    /// </summary>
    /// <typeparam name="T">Return type of function</typeparam>
    public class FilterFunctionCollection<T> : List<Func<T, bool>>
    {
    }
}