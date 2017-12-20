using Microsoft.Owin.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Threading;

namespace TestServer
{
    public class Program
    {
        public static System.Threading.ManualResetEvent shutDown = new ManualResetEvent(false);
        static void Main(string[] args)
        {
            string baseAddress = "http://localhost:3000/";

            var apiKey = args[0];
            Utils.UpdateAppSetting("ApiKey", apiKey);
            var host = args[1];
            Utils.UpdateAppSetting("Host", host);

            using (WebApp.Start<Startup>(url: baseAddress))
            {
                Console.WriteLine($"Running at {baseAddress}");
                shutDown.WaitOne();
            }
        }
    }
}
