using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dot_net_academy_asp_mvc.Hubs
{
    public class SignalRHub : Hub
    {
        public async Task SendMessage(object model) //TODO: implement this
        {
            await Clients.All.SendAsync("ReceiveMessage",model);
        }
    }
}
