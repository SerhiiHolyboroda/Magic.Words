using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Magic.Words.Shared.Hubs
{
    public class MyHub : Hub
    {
        public async Task SendMessage(string user, string message)
        {
            Context.GetHttpContext();
            //await Clients.User(userId).SendAsync("ReceiveMessage", message);
        await Clients.All.SendAsync("ReceiveMessage", user, message);
        }

        public async Task ReceiveComment(string commentContent) {
          
            await Clients.All.SendAsync("ReceiveComment", commentContent);
        }

        public async Task DeleteComment(int commentId) {
            
            await Clients.All.SendAsync("DeleteComment", commentId);
        }
    }
}