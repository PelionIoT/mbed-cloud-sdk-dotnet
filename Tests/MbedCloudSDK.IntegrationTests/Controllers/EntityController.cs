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
    public class EntityController : Controller
    {
        private readonly IFoundationService _foundationService;

        public EntityController(IFoundationService foundationService)
        {
            _foundationService = foundationService;
        }

        [HttpGet("foundation/entities")]
        public IActionResult ListAvailableEntities()
        {
            try
            {
                return Json(_foundationService.ListAvailableEntities().ToArray());
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

        [HttpGet("foundation/entities/{entityId}/instances")]
        public IActionResult GetInstancesOfEntity(string entityId)
        {
            try
            {
                return Json(_foundationService.ListEntityInstances(entityId).Select(e => e.ToJson()));
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

        [HttpPost("foundation/entities/{entityId}/instances")]
        public IActionResult CreateNewEntityInstance(string entityId, [FromBody] Dictionary<string, object> initialParams)
        {
            try
            {
                Response.StatusCode = 201;
                return Json(_foundationService.CreateEntityInstance(entityId, new Config(initialParams)).ToJson());
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