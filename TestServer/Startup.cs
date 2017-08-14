using Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

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

            appBuilder.UseWebApi(config);
        }
    }
}
