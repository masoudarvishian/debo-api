using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DEBO.API.Hubs;
using DEBO.API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;

namespace DEBO.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessageController : ControllerBase
    {
        private readonly IHubContext<NotifyHub, ITypedHubClient> _hubContext;

        public MessageController(IHubContext<NotifyHub, ITypedHubClient> hubContext)
        {
            _hubContext = hubContext;
        }

        [HttpPost]
        public string Post([FromBody]Message message)
        {
            string returnMessage = string.Empty;

            try
            {
                _hubContext.Clients.All.BroadcastMessage(message.Type, message.Payload);
                returnMessage = "Success";
            }
            catch (Exception exc)
            {
                returnMessage = exc.Message;
            }

            return returnMessage;
        }
    }
}