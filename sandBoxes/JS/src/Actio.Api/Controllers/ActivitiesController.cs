using Actio.Common.Commands;
using Microsoft.AspNetCore.Mvc;
using RawRabbit;
using System;
using System.Threading.Tasks;

namespace Actio.Api.Controllers
{
    [Route("[controller]")]
    public class ActivitiesController : Controller
    {
        private readonly IBusClient _busClient;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="busClient">The RabbitMQ bus client</param>
        public ActivitiesController(IBusClient busClient)
        {
            _busClient = busClient;
        }

        /// <summary>
        /// Sends the Create Activity command to the bus
        /// </summary>
        /// <param name="command">The command to send to the bus</param>
        /// <returns></returns>
        [HttpPost("")]
        public async Task<IActionResult> Post([FromBody]CreateActivity command)
        {
            command.Id = Guid.NewGuid();
            command.CreatedAt = DateTime.UtcNow;

            await _busClient.PublishAsync(command);

            return Accepted($"activities/{command.Id}");
        }
    }
}