using Microsoft.AspNet.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

public class ChatHub : Hub
{
    public void Send(string name, string message)
    {
        string messageId = Guid.NewGuid().ToString();

        Clients.All.broadcastMessage(name, message, messageId);
    }

    public void Command(string name)
    {
        Clients.All.sendCommand(name);
    }

    public void Acknowledge(string messageId)
    {
        Clients.All.broadcastAcknowledge(messageId);
    }
}