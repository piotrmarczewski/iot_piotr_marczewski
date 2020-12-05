using ChatApp.Models;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChatApp.Hubs
{
    public class ChatHub:Hub
    {
        public void SendMessage(ChatMessage message)
        {
            Clients.All.SendAsync("RecivedMessage", message);
        }

        public void SignInUser(string userName)
        {
            Clients.All.SendAsync("UserSignedIn", userName);
        }
    }
}
