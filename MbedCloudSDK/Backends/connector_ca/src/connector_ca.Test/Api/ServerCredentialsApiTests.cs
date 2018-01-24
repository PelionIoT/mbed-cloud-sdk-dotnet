/* 
 * <auto-generated>
 * Connect CA API
 *
 * Connect CA API provides methods to create and get Developer certificate. Also Connect CA provides server-credentials for Bootstarp and LWM2M Server.
 *
 * OpenAPI spec version: 3
 * 
 * Generated by: https://github.com/swagger-api/swagger-codegen.git
 * </auto-generated>
 */
using System;
using System.IO;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection;
using RestSharp;
using NUnit.Framework;

using connector_ca.Client;
using connector_ca.Api;
using connector_ca.Model;

namespace connector_ca.Test
{
    /// <summary>
    ///  Class for testing ServerCredentialsApi
    /// </summary>
    /// <remarks>
    /// This file is automatically generated by Swagger Codegen.
    /// Please update the test case below to test the API endpoint.
    /// </remarks>
    [TestFixture]
    public class ServerCredentialsApiTests
    {
        private ServerCredentialsApi instance;

        /// <summary>
        /// Setup before each unit test
        /// </summary>
        [SetUp]
        public void Init()
        {
            instance = new ServerCredentialsApi();
        }

        /// <summary>
        /// Clean up after each unit test
        /// </summary>
        [TearDown]
        public void Cleanup()
        {

        }

        /// <summary>
        /// Test an instance of ServerCredentialsApi
        /// </summary>
        [Test]
        public void InstanceTest()
        {
            // TODO uncomment below to test 'IsInstanceOfType' ServerCredentialsApi
            //Assert.IsInstanceOfType(typeof(ServerCredentialsApi), instance, "instance is a ServerCredentialsApi");
        }

        
        /// <summary>
        /// Test V3ServerCredentialsBootstrapGet
        /// </summary>
        [Test]
        public void V3ServerCredentialsBootstrapGetTest()
        {
            // TODO uncomment below to test the method and replace null with proper value
            //string authorization = null;
            //var response = instance.V3ServerCredentialsBootstrapGet(authorization);
            //Assert.IsInstanceOf<ServerCredentialsResponseData> (response, "response is ServerCredentialsResponseData");
        }
        
        /// <summary>
        /// Test V3ServerCredentialsLwm2mGet
        /// </summary>
        [Test]
        public void V3ServerCredentialsLwm2mGetTest()
        {
            // TODO uncomment below to test the method and replace null with proper value
            //string authorization = null;
            //var response = instance.V3ServerCredentialsLwm2mGet(authorization);
            //Assert.IsInstanceOf<ServerCredentialsResponseData> (response, "response is ServerCredentialsResponseData");
        }
        
    }

}
