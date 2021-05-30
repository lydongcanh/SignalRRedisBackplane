using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Server.Hubs
{
    public interface ITick
    {
        Task OnConnected();

        Task OnTickReceived(int tick);
    }
}
