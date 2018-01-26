using System;
using System.Collections.Generic;
using MbedCloudSDK.IntegrationTests.Models;
using MbedCloudSDK.IntegrationTests.Services;
using Microsoft.AspNetCore.Mvc;

namespace MbedCloudSDK.IntegrationTests.Controllers
{
    public class ModulesController : Controller
    {
        private IInstanceService _instanceService;

        public ModulesController(IInstanceService instanceService)
        {
            _instanceService = instanceService;
        }

        [HttpGet("modules")]
        public IActionResult ListModules()
        {
            // list modules
            return Ok();
        }

        [HttpGet("modules/{moduleId}/instances")]
        public IActionResult ListModuleInstances(string moduleId)
        {
            try
            {
                var module = ModuleEnumHelpers.Map(moduleId);
                if (module == ModuleEnum.None)
                {
                    return NotFound();
                }

                var modules = _instanceService.ListModuleInstances(module);
                return Json(modules);
            }
            catch (Exception e)
            {
                Response.StatusCode = 500;
                return Json(ErrorMessage.Map(e));
            }
        }

        [HttpPost("modules/{moduleId}/instances")]
        public IActionResult CreateNewModuleInstance(string moduleId, [FromBody] InstanceConfiguration instanceConfiguration)
        {
            try
            {
                instanceConfiguration.ReverseMap();
                var module = ModuleEnumHelpers.Map(moduleId);
                if (module == ModuleEnum.None)
                {
                    return NotFound();
                }

                var instance = _instanceService.AddModuleInstance(module, instanceConfiguration);
                Response.StatusCode = 201;
                return Json(instance);
            }
            catch (Exception e)
            {
                Response.StatusCode = 500;
                return Json(ErrorMessage.Map(e));
            }
        }
    }
}