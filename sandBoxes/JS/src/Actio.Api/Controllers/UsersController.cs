using Actio.Common.Commands;
using Microsoft.AspNetCore.Mvc;
using RawRabbit;
using System.Threading.Tasks;

namespace Actio.Api.Controllers
{
    [Route("[controller]")]
    public class UsersController : Controller
    {
        /// <summary>
        /// RabbitMQ bus client
        /// </summary>
        private readonly IBusClient _busClient;

        /// <summary>
        /// Instantiates a Users controller
        /// </summary>
        /// <param name="busClient">The RabbitMQ bus client</param>
        public UsersController(IBusClient busClient)
        {
            _busClient = busClient;
        }

        /// <summary>
        /// Sends the <see cref="CreateUser"/> command to the bus
        /// </summary>
        /// <param name="command">The <see cref="CreateUser"/> command to send to the bus</param>
        /// <returns>Returns a 202 Accepted response containing the user name</returns>
        [HttpPost("")]
        public async Task<IActionResult> Post([FromBody]CreateUser command)
        {            
            await _busClient.PublishAsync(command);

            return Accepted($"users/{command.Name}");
        }
    }
}