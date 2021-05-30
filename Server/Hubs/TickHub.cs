using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;

namespace Server.Hubs
{
    public class TickHub : Hub
    {
        public async Task Tick(int time)
        {
            await Clients.All.SendAsync("OnTickReceived", time);
        }
    }
}
