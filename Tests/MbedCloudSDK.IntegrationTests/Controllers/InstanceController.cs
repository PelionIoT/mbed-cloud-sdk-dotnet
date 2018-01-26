using System;
using System.Collections.Generic;
using System.Linq;
using MbedCloudSDK.IntegrationTests.Models;
using MbedCloudSDK.IntegrationTests.Services;
using Microsoft.AspNetCore.Mvc;

namespace MbedCloudSDK.IntegrationTests.Controllers
{
    public class InstanceController : Controller
    {
        private IInstanceService _instanceService;

        public InstanceController(IInstanceService instanceService)
        {
            _instanceService = instanceService;
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
                    return NotFound();
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
                    return NotFound();
                }

                _instanceService.DeleteInstance(instance);
                return Ok();
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
                    return NotFound();
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
        public IActionResult RunMethod(string instanceId, string methodId, [FromBody] object parameters)
        {
            try
            {
                var instance = _instanceService.GetInstance(instanceId);
                if (instance == null)
                {
                    return NotFound();
                }

                var methods = _instanceService.ListInstanceMethods(instance);

                if (string.IsNullOrEmpty(methods.FirstOrDefault(m => m == methodId)))
                {
                    return NotFound();
                }

                return Json(_instanceService.ListInstanceMethods(instance));
            }
            catch (Exception e)
            {
                Response.StatusCode = 500;
                return Json(ErrorMessage.Map(e));
            }
        }
    }
}