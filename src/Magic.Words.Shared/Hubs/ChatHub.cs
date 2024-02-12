using Magic.Words.Core.Interfaces;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Magic.Words.Shared.Hubs
{
    public sealed class ChatHub : Hub
        // <IChatClient>
    {
     /*   public override async Task OnConnectedAsync()
        {
            await Clients.All.ReceiveMessage( $"{Context.ConnectionId} ");
        }
     */
        public async Task SendMessage(string user, string message) {
            await Clients.All.SendAsync("ReceiveMessage", user, message);
        }


    }
}
