using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;

namespace DEBO.API.Hubs
{
    public class NotificationHub : Hub
    {
        public Task SendMessageToAll(string message)
        {
            return Clients.All.SendAsync("ReceiveMessage", message);
        }
    }
}
