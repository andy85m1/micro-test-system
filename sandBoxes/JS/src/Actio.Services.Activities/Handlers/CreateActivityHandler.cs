using Actio.Common.Commands;
using Actio.Common.Events;
using Actio.Common.Exceptions;
using Actio.Services.Activities.Services;
using Microsoft.Extensions.Logging;
using RawRabbit;
using System;
using System.Threading.Tasks;

namespace Actio.Services.Activities.Handlers
{
    /// <summary>
    /// <see cref="CreateActivity"/> command handler
    /// </summary>
    public class CreateActivityHandler : ICommandHandler<CreateActivity>
    {
        /// <summary>
        /// RawRabbit bus client
        /// </summary>
        private readonly IBusClient _busClient;

        /// <summary>
        /// The activity service
        /// </summary>
        private readonly IActivityService _activityService;

        /// <summary>
        /// The logger
        /// </summary>
        private ILogger _logger;

        /// <summary>
        /// Instantiates an activity handler
        /// </summary>
        /// <param name="busClient">The RawRabbit bus client</param>
        /// <param name="activityService">The activity service</param>
        /// <param name="logger">The logger</param>
        public CreateActivityHandler(IBusClient busClient, IActivityService activityService, ILogger<CreateActivityHandler> logger)
        {
            _busClient = busClient;
            _activityService = activityService;
            _logger = logger;
        }

        /// <summary>
        /// Handles the incoming <see cref="CreateActivity"/> command and publishes a <see cref="ActivityCreated"/> event
        /// </summary>
        /// <param name="command">The <see cref="CreateActivity"/> command to handle</param>
        /// <returns>A <see cref="Task"/>The awaitable task</returns>
        public async Task HandleAsync(CreateActivity command)
        {
            _logger.LogInformation($"Creating activity: {command.Category} {command.Name}");

            try
            {
                await _activityService.AddAsync(command.Id, command.UserId, command.Category, command.Name, command.Description, command.CreatedAt);

                await _busClient.PublishAsync(new ActivityCreated(command.Id, command.UserId, command.Category, command.Name, command.Description, command.CreatedAt));

                return;
            }
            catch (ActioException ex)
            {
                await _busClient.PublishAsync(new CreateActivityRejected(command.Id, ex.Code, ex.Message));
                _logger.LogInformation(ex.Message);
            }
            catch (Exception ex)
            {
                await _busClient.PublishAsync(new CreateActivityRejected(command.Id, "error", ex.Message));
                _logger.LogInformation(ex.Message);
            }            
        }
    }
}
