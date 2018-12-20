using Actio.Api.Repositories;
using Actio.Common.Commands;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RawRabbit;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Actio.Api.Controllers
{
    [Route("[controller]")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)] //Secures the whole controller
    public class ActivitiesController : Controller
    {
        /// <summary>
        /// RabbitMQ bus client
        /// </summary>
        private readonly IBusClient _busClient;

        /// <summary>
        /// The Activity repository
        /// </summary>
        private readonly IActivityRepository _repository;

        /// <summary>
        /// Instantiates the activities controller
        /// </summary>
        /// <param name="busClient">The RabbitMQ bus client</param>
        public ActivitiesController(IBusClient busClient, IActivityRepository repository)
        {
            _busClient = busClient;
            _repository = repository;
        }

        /// <summary>
        /// GET HTTP request handler: Returns a list of Json activity DTO objects presnet in the repository
        /// </summary>
        /// <returns>Returns A 200 OK response with a Json object containing the user activity DTO</returns>
        [HttpGet("")]
        public async Task<IActionResult> Get()
        {
            var activities = await _repository
                .BrowseAsync(Guid.Parse(User.Identity.Name));

            return Json(activities.Select(x => new { x.Id, x.Name, x.Category, x.CreatedAt }));
        }

        /// <summary>
        /// GET HTTP request handler: Searches the activity repository for a given id and returns the Json object if its found and the current user
        /// is authorised to view
        /// </summary>
        /// <param name="id">The id to search</param>
        /// <returns>Returns A 200 OK response with a Json object containing the user activity DTO</returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var activity = await _repository.GetAsync(id);

            if (activity == null)
                return NotFound();

            if (activity.UserId != Guid.Parse(User.Identity.Name))
                return Unauthorized();

            return Json(activity);
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
            command.UserId = Guid.Parse(User.Identity.Name);

            await _busClient.PublishAsync(command);

            return Accepted($"activities/{command.Id}");
        }
    }
}