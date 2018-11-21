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
        /// Constructor
        /// </summary>
        /// <param name="busClient">The RabbitMQ bus client</param>
        public UsersController(IBusClient busClient)
        {
            _busClient = busClient;
        }

        /// <summary>
        /// Sends the Create User command to the bus
        /// </summary>
        /// <param name="command">The command to send to the bus</param>
        /// <returns></returns>
        [HttpPost("register")]
        public async Task<IActionResult> Post([FromBody]CreateUser command)
        {
            await _busClient.PublishAsync(command);

            return Accepted();
        }
    }
}