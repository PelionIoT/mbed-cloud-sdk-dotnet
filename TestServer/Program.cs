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
        static void Main(string[] args)
        {
            string baseAddress = "http://localhost:3000/";

            var apiKey = args[0];
            Utils.UpdateAppSetting("ApiKey", apiKey); 

            using (WebApp.Start<Startup>(url: baseAddress))
            {
                Console.WriteLine("Running at " + baseAddress);
                Thread.Sleep(Timeout.Infinite);
            }
        }

        
    }
}
