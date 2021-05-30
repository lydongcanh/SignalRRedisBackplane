using System;
using System.Timers;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;
using Timer = System.Timers.Timer;

namespace Server.Hubs
{
    public class TickHub : Hub<ITick>
    {
        public override async Task OnConnectedAsync()
        {
            await Clients.All.OnConnected();
        }
    }
}
