using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Hosting;
using Server.Hubs;

namespace Server.BackgroundServices
{
    public class TickWorker : BackgroundService
    {
        private readonly IHubContext<TickHub, ITick> tickHub;
        private readonly int delay = 1000;
        private int tick;

        public TickWorker(IHubContext<TickHub, ITick> tickHub)
        {
            this.tickHub = tickHub;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                tick += delay;
                await tickHub.Clients.All.OnTickReceived(tick);
                await Task.Delay(delay, stoppingToken);
            }
        }
    }
}
