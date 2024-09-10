using Microsoft.AspNetCore.SignalR;
using WebApiSignalR.Helpers;

namespace WebApiSignalR.Hubs
{
    public class MessageHub:Hub
    {
        public override async Task OnConnectedAsync()
        {
            await Clients.All.SendAsync("ReceiveConnectInfo", "User Connected");
        }

        public override async Task OnDisconnectedAsync(Exception? exception)
        {
            await Clients.Others.SendAsync("DisconnectInfo", "User disconnected");
        }

        public async Task SendMessage(string message)
        {
            await Clients.All.SendAsync("ReceiveMessage", message + "'s Offer is ", FileHelper.Read());
        }
    }
}
