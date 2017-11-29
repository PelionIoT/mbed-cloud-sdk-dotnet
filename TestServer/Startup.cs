using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http;
using Owin;

namespace TestServer
{
    public class Startup
    {
        public void Configuration(IAppBuilder appBuilder)
        {
            HttpConfiguration config = new HttpConfiguration();
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "{module}/{method}",
                defaults: new { controller = "Home", action = "TestModuleMethod" }
            );

            config.Routes.MapHttpRoute(
                name: "Init",
                routeTemplate: "_init",
                defaults: new { controller = "Home", action = "Init" }
            );

            config.Routes.MapHttpRoute(
                name: "Exit",
                routeTemplate: "_exit",
                defaults: new { controller = "Home", action = "Exit" }
            );

            config.MessageHandlers.Add (new LogRequestAndResponseHandler ());

            appBuilder.UseWebApi(config);
        }

        public class LogRequestAndResponseHandler : DelegatingHandler
        {
            protected override async Task<HttpResponseMessage> SendAsync(
                HttpRequestMessage request, CancellationToken cancellationToken)
            {
                // log request body
                string requestBody = await request.Content.ReadAsStringAsync();
                Console.WriteLine(requestBody);

                // let other handlers process the request
                var result = await base.SendAsync(request, cancellationToken);

                if (result.Content != null)
                {
                    // once response body is ready, log it
                    var responseBody = await result.Content.ReadAsStringAsync();
                    Console.WriteLine(responseBody);
                }

                return result;
            }
        }
    }
}