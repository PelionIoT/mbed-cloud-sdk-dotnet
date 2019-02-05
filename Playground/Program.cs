
using System;
using Newtonsoft.Json;
using MbedCloudSDK.Common.Extensions;
using System.Linq;
using System.Threading.Tasks;
using System.Net.WebSockets;
using System.Threading;
using MbedCloudSDK.Connect.Api;
using MbedCloudSDK.Common;
using System.Collections.Generic;

namespace Playground
{
    class Program
    {
        private const string Url = "wss://api-ns-websocket.mbedcloudintegration.net/v2/notification/websocket-connect";
        private const string ApiKey = "ak_1MDE2ODVjNzVjOTdjMjJjMTFjMDQ0ZDUzMDAwMDAwMDA0168b97683d6f65f42b0f3e100000000lt4PeToNqJ3ZvguwsxoxH7tadJci8qYv";
        private const string Host = "https://api-ns-websocket.mbedcloudintegration.net";

        static async Task Main(string[] args)
        {
            try
            {
                var connect = new ConnectApi(new Config(ApiKey, Host));
                var myDevice = connect.ListConnectedDevices().FirstOrDefault();

                connect.Subscribe.ResourceValues(myDevice.Id, new List<string> { "/3200/0/5501" });

                // create new client
                var ws = new ClientWebSocket();

                // set subprotocals e.g. pelion_ak_123, wss
                ws.Options.AddSubProtocol($"pelion_{ApiKey}");
                ws.Options.AddSubProtocol("wss");

                // connect to url
                await ws.ConnectAsync(new Uri(Url), CancellationToken.None);
                await Console.Out.WriteLineAsync("Connected to mds websocket");
                Console.WriteLine($"socket state - {ws.State}");

                // receive message
                await Task.WhenAll(Receive(ws));
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception...");
                Console.WriteLine(e);
            }
        }

        private static async Task Receive(ClientWebSocket ws)
        {
            var buffer = new byte[2048];

            while (true)
            {
                var result = await ws.ReceiveAsync(new ArraySegment<byte>(buffer), CancellationToken.None);
                if (result.MessageType == WebSocketMessageType.Close)
                {
                    Console.WriteLine("Closing...");
                    await ws.CloseOutputAsync(WebSocketCloseStatus.NormalClosure, "", CancellationToken.None);
                    break;
                }
                else
                {
                    var message = System.Text.Encoding.Default.GetString(buffer);
                    Console.WriteLine("Incoming message...");
                    Console.WriteLine(message);
                }
            }
        }
    }
}
