using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;

namespace DEBO.API.Hubs
{
    public class NotifyHub : Hub<ITypedHubClient>
    {
        public Task SendMessageToAll(string message)
        {
            throw new System.NotImplementedException();
        }
    }
}
