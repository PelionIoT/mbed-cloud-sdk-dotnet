/* 
 * <auto-generated>
 * Account Management API
 *
 * API for managing accounts, users, creating API keys, uploading trusted certificates
 *
 * OpenAPI spec version: v3
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

using iam.Client;
using iam.Api;
using iam.Model;

namespace iam.Test
{
    /// <summary>
    ///  Class for testing AccountAdminApi
    /// </summary>
    /// <remarks>
    /// This file is automatically generated by Swagger Codegen.
    /// Please update the test case below to test the API endpoint.
    /// </remarks>
    [TestFixture]
    public class AccountAdminApiTests
    {
        private AccountAdminApi instance;

        /// <summary>
        /// Setup before each unit test
        /// </summary>
        [SetUp]
        public void Init()
        {
            instance = new AccountAdminApi();
        }

        /// <summary>
        /// Clean up after each unit test
        /// </summary>
        [TearDown]
        public void Cleanup()
        {

        }

        /// <summary>
        /// Test an instance of AccountAdminApi
        /// </summary>
        [Test]
        public void InstanceTest()
        {
            // TODO uncomment below to test 'IsInstanceOfType' AccountAdminApi
            //Assert.IsInstanceOfType(typeof(AccountAdminApi), instance, "instance is a AccountAdminApi");
        }

        
        /// <summary>
        /// Test AddCertificate
        /// </summary>
        [Test]
        public void AddCertificateTest()
        {
            // TODO uncomment below to test the method and replace null with proper value
            //TrustedCertificateReq body = null;
            //var response = instance.AddCertificate(body);
            //Assert.IsInstanceOf<TrustedCertificateResp> (response, "response is TrustedCertificateResp");
        }
        
        /// <summary>
        /// Test AddSubjectsToGroup
        /// </summary>
        [Test]
        public void AddSubjectsToGroupTest()
        {
            // TODO uncomment below to test the method and replace null with proper value
            //string groupID = null;
            //SubjectList body = null;
            //var response = instance.AddSubjectsToGroup(groupID, body);
            //Assert.IsInstanceOf<UpdatedResponse> (response, "response is UpdatedResponse");
        }
        
        /// <summary>
        /// Test CreateUser
        /// </summary>
        [Test]
        public void CreateUserTest()
        {
            // TODO uncomment below to test the method and replace null with proper value
            //UserInfoReq body = null;
            //string action = null;
            //var response = instance.CreateUser(body, action);
            //Assert.IsInstanceOf<UserInfoResp> (response, "response is UserInfoResp");
        }
        
        /// <summary>
        /// Test DeleteUser
        /// </summary>
        [Test]
        public void DeleteUserTest()
        {
            // TODO uncomment below to test the method and replace null with proper value
            //string userId = null;
            //instance.DeleteUser(userId);
            
        }
        
        /// <summary>
        /// Test GetAllUsers
        /// </summary>
        [Test]
        public void GetAllUsersTest()
        {
            // TODO uncomment below to test the method and replace null with proper value
            //int? limit = null;
            //string after = null;
            //string order = null;
            //string include = null;
            //string statusEq = null;
            //var response = instance.GetAllUsers(limit, after, order, include, statusEq);
            //Assert.IsInstanceOf<UserInfoRespList> (response, "response is UserInfoRespList");
        }
        
        /// <summary>
        /// Test GetUser
        /// </summary>
        [Test]
        public void GetUserTest()
        {
            // TODO uncomment below to test the method and replace null with proper value
            //string userId = null;
            //var response = instance.GetUser(userId);
            //Assert.IsInstanceOf<UserInfoResp> (response, "response is UserInfoResp");
        }
        
        /// <summary>
        /// Test GetUsersOfGroup
        /// </summary>
        [Test]
        public void GetUsersOfGroupTest()
        {
            // TODO uncomment below to test the method and replace null with proper value
            //string groupID = null;
            //int? limit = null;
            //string after = null;
            //string order = null;
            //string include = null;
            //var response = instance.GetUsersOfGroup(groupID, limit, after, order, include);
            //Assert.IsInstanceOf<UserInfoRespList> (response, "response is UserInfoRespList");
        }
        
        /// <summary>
        /// Test RemoveUsersFromGroup
        /// </summary>
        [Test]
        public void RemoveUsersFromGroupTest()
        {
            // TODO uncomment below to test the method and replace null with proper value
            //string groupID = null;
            //SubjectList body = null;
            //var response = instance.RemoveUsersFromGroup(groupID, body);
            //Assert.IsInstanceOf<UpdatedResponse> (response, "response is UpdatedResponse");
        }
        
        /// <summary>
        /// Test UpdateMyAccount
        /// </summary>
        [Test]
        public void UpdateMyAccountTest()
        {
            // TODO uncomment below to test the method and replace null with proper value
            //AccountUpdateReq body = null;
            //var response = instance.UpdateMyAccount(body);
            //Assert.IsInstanceOf<AccountInfo> (response, "response is AccountInfo");
        }
        
        /// <summary>
        /// Test UpdateUser
        /// </summary>
        [Test]
        public void UpdateUserTest()
        {
            // TODO uncomment below to test the method and replace null with proper value
            //string userId = null;
            //UserUpdateReq body = null;
            //var response = instance.UpdateUser(userId, body);
            //Assert.IsInstanceOf<UserInfoResp> (response, "response is UserInfoResp");
        }
        
    }

}
