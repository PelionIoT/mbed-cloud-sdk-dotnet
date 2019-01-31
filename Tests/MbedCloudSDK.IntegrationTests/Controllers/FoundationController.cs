using System;
using System.Collections.Generic;
using System.Linq;
using MbedCloudSDK.Exceptions;
using MbedCloudSDK.IntegrationTests.Exceptions;
using MbedCloudSDK.IntegrationTests.ExtensionMethods;
using MbedCloudSDK.IntegrationTests.Services;
using Microsoft.AspNetCore.Mvc;

namespace MbedCloudSDK.IntegrationTests.Controllers
{
    public class FoundationController : Controller
    {
        private readonly IFoundationService _foundationService;

        public FoundationController(IFoundationService foundationService)
        {
            _foundationService = foundationService;
        }

        [HttpGet("foundation/instances")]
        public IActionResult GetAllFoundationInstances()
        {
            try
            {
                return Json(_foundationService.ListAllInstances().Select(i => i.ToJson()).ToArray());
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

        [HttpGet("foundation/instances/{instanceId}")]
        public IActionResult GetInstanceById(string instanceId)
        {
            try
            {
                return Json(_foundationService.GetInstanceById(instanceId).ToJson());
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

        [HttpDelete("foundation/instances/{instanceId}")]
        public IActionResult DeleteInstance(string instanceId)
        {
            try
            {
                _foundationService.DeleteInstance(instanceId);
                return StatusCode(204);
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

        [HttpGet("foundation/instances/{instanceId}/methods")]
        public IActionResult ListMethodsOfInstance(string instanceId)
        {
            try
            {
                return Json(_foundationService.ListInstanceMethods(instanceId)
                                                .Select(m => new { name = m.Value.Name.ToLower() })
                                                .ToArray());
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

        [HttpPost("foundation/instances/{instanceId}/methods/{methodId}")]
        public IActionResult ExecuteMethodOnInstance(string instanceId, string methodId, [FromBody] Dictionary<string, object> parameters = null)
        {
            try
            {
                return Json(_foundationService.ExecuteMethod(instanceId, methodId, parameters));
            }
            catch (CloudApiException e)
            {
                Response.StatusCode = 500;
                return Json(e.ToJson());
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