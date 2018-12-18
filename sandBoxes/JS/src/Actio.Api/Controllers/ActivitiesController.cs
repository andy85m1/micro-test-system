using Actio.Common.Commands;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RawRabbit;
using System;
using System.Threading.Tasks;

namespace Actio.Api.Controllers
{
    [Route("[controller]")]
    public class ActivitiesController : Controller
    {
        /// <summary>
        /// RabbitMQ bus client
        /// </summary>
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
        /// POST HTTP request handler: Sends the <see cref="CreateActivity"/> command to the bus
        /// </summary>
        /// <param name="command">The <see cref="CreateActivity"/> command to send to the bus</param>
        /// <returns>A 202 Accepted response if successful</returns>
        [HttpPost("")]
        public async Task<IActionResult> Post([FromBody]CreateActivity command)
        {
            command.Id = Guid.NewGuid();
            command.CreatedAt = DateTime.UtcNow;

            await _busClient.PublishAsync(command);

            return Accepted($"activities/{command.Id}");
        }

        /// <summary>
        /// GET HTTP request handler
        /// </summary>
        /// <returns>Returns A 200 OK response containing "Secured" if the JWT is valid</returns>
        [HttpGet("")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public IActionResult Get() => Content("Secured");
    }
}