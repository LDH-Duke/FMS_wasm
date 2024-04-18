using Microsoft.AspNetCore.SignalR;

namespace FMS.Server.Hubs
{
    public class BroadcastHub : Hub
    {
        public async Task SendMessage()
        {
            await Clients.All.SendAsync("AlarmSelect");
        }
    }
}
