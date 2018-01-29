using System;
using MbedCloudSDK.IntegrationTests.Models;
using MbedCloudSDK.IntegrationTests.Services;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;

namespace MbedCloudSDK.IntegrationTests.Controllers
{
    public class ServerController : Controller
    {
        private IApplicationLifetime _applicationLifetime;
        private IInstanceService _instanceService;

        public ServerController(IApplicationLifetime applicationLifetime, IInstanceService instanceService)
        {
            _applicationLifetime = applicationLifetime;
            _instanceService = instanceService;
        }

        [HttpGet("ping")]
        public IActionResult Ping()
        {
            return Json("pong");
        }

        [HttpPost("reset")]
        public IActionResult Reset()
        {
            try
            {
                _instanceService.ResetInstances();
                return StatusCode(205);
            }
            catch (Exception e)
            {
                Response.StatusCode = 500;
                return Json(ErrorMessage.Map(e));
            }
        }

        [HttpPost("shutdown")]
        public IActionResult Shutdown()
        {
            try
            {
                Console.WriteLine("Shutting down server...");
                _applicationLifetime.StopApplication();
                Response.StatusCode = 202;
                return Json("Goodbye");
            }
            catch (Exception e)
            {
                Response.StatusCode = 500;
                return Json(ErrorMessage.Map(e));
            }
        }
    }
}