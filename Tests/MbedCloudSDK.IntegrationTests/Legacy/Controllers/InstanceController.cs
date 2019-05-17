using System;
using System.Collections.Generic;
using System.Linq;
using MbedCloudSDK.Exceptions;
using MbedCloudSDK.IntegrationTests.ExtensionMethods;
using MbedCloudSDK.IntegrationTests.Models;
using MbedCloudSDK.IntegrationTests.Services;
using Microsoft.AspNetCore.Mvc;

namespace MbedCloudSDK.IntegrationTests.Controllers
{
    public class InstanceController : Controller
    {
        private IInstanceService _instanceService;
        private IMethodRunnerService _methodRunnerService;

        public InstanceController(IInstanceService instanceService, IMethodRunnerService methodRunnerService)
        {
            _instanceService = instanceService;
            _methodRunnerService = methodRunnerService;
        }

        [HttpGet("instances")]
        public IActionResult GetAllInstances()
        {
            try
            {
                return Json(_instanceService.GetAllInstances());
            }
            catch (Exception e)
            {
                Response.StatusCode = 500;
                return Json(ErrorMessage.Map(e));
            }
        }

        [HttpGet("instances/{instanceId}")]
        public IActionResult GetInstance(string instanceId)
        {
            try
            {
                var instance = _instanceService.GetInstance(instanceId);
                if (instance == null)
                {
                    Response.StatusCode = 404;
                    return Json(new ErrorMessage { Message = "No instances found", Traceback = "" });
                }

                return Json(instance);
            }
            catch (Exception e)
            {
                Response.StatusCode = 500;
                return Json(ErrorMessage.Map(e));
            }
        }

        [HttpDelete("instances/{instanceId}")]
        public IActionResult DeleteInstance(string instanceId)
        {
            try
            {
                var instance = _instanceService.GetInstance(instanceId);
                if (instance == null)
                {
                    Response.StatusCode = 404;
                    return Json(new ErrorMessage { Message = "No instance found", Traceback = "" });
                }

                _instanceService.DeleteInstance(instance);
                return Json(true);
            }
            catch (Exception e)
            {
                Response.StatusCode = 500;
                return Json(ErrorMessage.Map(e));
            }
        }

        [HttpGet("instances/{instanceId}/methods")]
        public IActionResult ListInstanceMethods(string instanceId)
        {
            try
            {
                var instance = _instanceService.GetInstance(instanceId);
                if (instance == null)
                {
                    Response.StatusCode = 404;
                    return Json(new ErrorMessage { Message = "No methods found", Traceback = "" });
                }

                return Json(_instanceService.ListInstanceMethods(instance));
            }
            catch (Exception e)
            {
                Response.StatusCode = 500;
                return Json(ErrorMessage.Map(e));
            }
        }

        [HttpPost("instances/{instanceId}/methods/{methodId}")]
        public IActionResult RunMethod(string instanceId, string methodId, [FromBody] Dictionary<string, object> parameters = null)
        {
            try
            {
                var instance = _instanceService.GetInstance(instanceId);
                if (instance == null)
                {
                    Response.StatusCode = 404;
                    return Json(new ErrorMessage { Message = "no such instance", Traceback = "" });
                }

                var methods = _instanceService.ListInstanceMethods(instance);

                if (methods.FirstOrDefault(m => m.Name == methodId) == null)
                {
                    Response.StatusCode = 404;
                    return Json(new ErrorMessage { Message = "no such method", Traceback = "" });
                }

                var instanceObject = _instanceService.GetInstanceObject(instance);

                var result = _methodRunnerService.TestModuleMethod(instance, instanceObject, methodId, parameters);

                return Json(new ApiResult { Payload = result });
            }
            catch (CloudApiException e)
            {
                Response.StatusCode = 500;
                return Json(e.ToJson());
            }
            catch (Exception e)
            {
                Response.StatusCode = 500;
                return Json(ErrorMessage.Map(e));
            }
        }
    }
}