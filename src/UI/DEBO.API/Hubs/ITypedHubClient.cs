using System.Threading.Tasks;

namespace DEBO.API.Hubs
{
    public interface ITypedHubClient
    {
        Task BroadcastMessage(string type, string payload);
    }
}
