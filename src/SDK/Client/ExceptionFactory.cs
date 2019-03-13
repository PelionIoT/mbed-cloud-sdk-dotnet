// <copyright file="ExceptionFactory.cs" company="Arm">
// Copyright (c) Arm. All rights reserved.
// </copyright>

namespace Mbed.Cloud.RestClient
{
    using System;
    using RestSharp;

    /// <summary>
    /// A delegate to ExceptionFactory method
    /// </summary>
    /// <param name="methodName">Method name</param>
    /// <param name="response">Response</param>
    /// <param name="failOnNotFound">if set to <c>true</c> [fail on not found].</param>
    /// <returns>
    /// Exceptions
    /// </returns>
    public delegate Exception ExceptionFactory(string methodName, IRestResponse response, bool failOnNotFound);
}