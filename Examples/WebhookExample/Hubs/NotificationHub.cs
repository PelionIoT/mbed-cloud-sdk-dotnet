using System.Threading.Tasks;
using MbedCloudSDK.Connect.Api.Subscribe.Models;
using Microsoft.AspNetCore.SignalR;

namespace WebhookExample.Hubs
{
    public class NotificationHub : Hub
    {
        public async Task SendNotification(ResourceValueChange notification)
        {
            await Clients.All.SendAsync("ReceiveNotification", notification);
        }
    }
}