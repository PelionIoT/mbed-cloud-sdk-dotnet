using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using MbedCloudSDK.Connect.Model.Notifications;
using Microsoft.AspNetCore.Mvc;
using WebhookExample.Models;
using WebhookExample.Services;

namespace WebhookExample.Controllers
{
    public class HomeController : Controller
    {
        private IConnectService _connectService;

        public HomeController(IConnectService connectService)
        {
            _connectService = connectService;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost("/subscribe")]
        public IActionResult Subscribe(string deviceId = "*", string[] resourcePaths = null)
        {
            _connectService.SubscribeToResourceValues(deviceId, resourcePaths.ToList());
            return Ok();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpPut("/")]
        public IActionResult Put([FromBody] NotificationMessage data)
        {
            _connectService.connect.Notify(data);
            return Ok();
        }
    }
}
