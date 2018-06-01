using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using MbedCloudSDK.Connect.Model.Notifications;
using MbedCloudSDK.Connect.Model.Webhook;
using MbedCloudSDK.Exceptions;
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
        public IActionResult Subscribe([FromBody] SubscribeModel model)
        {
            try
            {
                var observer = _connectService.connect.Subscribe.ResourceValues(model.DeviceId, model.ResourcePaths);
                observer.OnNotify += (res) => Console.WriteLine(res);
                return Ok();
            }
            catch (CloudApiException)
            {
                return RedirectToAction("Error");
            }
        }

        [HttpPost("/register")]
        public IActionResult RegisterWebhook([FromBody] RegisterModel model)
        {
            try
            {
                var webhook = _connectService.connect.GetWebhook();
                if (webhook != null)
                {
                    if (webhook.Url == model.Url)
                    {
                        Console.WriteLine($"Webhook already set to {model.Url}");
                        return Ok();
                    }
                    else
                    {
                        Console.WriteLine($"Webhook currently set to {webhook.Url}, changing to {model.Url}");
                    }
                }
                else
                {
                    Console.WriteLine($"No webhook currently registered, setting to {model.Url}");
                }

                _connectService.connect.UpdateWebhook(new Webhook(model.Url));
            }
            catch (CloudApiException e)
            {
                Console.WriteLine(e);
                RedirectToAction("Error");
            }


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
