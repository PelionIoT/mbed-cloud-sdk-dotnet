using System;
using System.Collections.Generic;
using System.Linq;
using Mbed.Cloud.Foundation.Common;
using MbedCloudSDK.IntegrationTests.Exceptions;
using MbedCloudSDK.IntegrationTests.ExtensionMethods;
using MbedCloudSDK.IntegrationTests.Services;
using Microsoft.AspNetCore.Mvc;

namespace MbedCloudSDK.IntegrationTests.Controllers
{
    public class SDKController : Controller
    {
        private readonly IFoundationService _foundationService;

        public SDKController(IFoundationService foundationService)
        {
            _foundationService = foundationService;
        }

        [HttpGet("foundation/sdk/instances")]
        public IActionResult ListAllSDKInstances()
        {
            try
            {
                var sdkInstances = _foundationService.ListAllSDKInstances().Select(s => s.ToJson()).ToArray();
                return Json(sdkInstances);
            }
            catch (TestServerException e)
            {
                Response.StatusCode = e.ErrorCode;
                return Json(e.ToJson());
            }
            catch (Exception e)
            {
                Response.StatusCode = 500;
                return Json(e.ToJson());
            }
        }

        [HttpPost("/foundation/sdk/instances")]
        public IActionResult CreateNewSDKInstance([FromBody] Dictionary<string, object> initialParams)
        {
            try
            {
                // TODO get config from initialParams
                var sdkInstance = _foundationService.CreateSDKInstance(new Config());
                Response.StatusCode = 201;
                return Json(sdkInstance.ToJson());
            }
            catch (TestServerException e)
            {
                Response.StatusCode = e.ErrorCode;
                return Json(e.ToJson());
            }
            catch (Exception e)
            {
                Response.StatusCode = 500;
                return Json(e.ToJson());
            }
        }
    }
}