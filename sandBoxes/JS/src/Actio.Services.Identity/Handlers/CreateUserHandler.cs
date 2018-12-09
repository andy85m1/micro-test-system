using Actio.Common.Commands;
using Actio.Common.Events;
using Actio.Common.Exceptions;
using Actio.Services.Identity.Services;
using Microsoft.Extensions.Logging;
using RawRabbit;
using System;
using System.Threading.Tasks;

namespace Actio.Services.Identity.Handlers
{
    public class CreateUserHandler : ICommandHandler<CreateUser>
    {
        /// <summary>
        /// RawRabbit bus client
        /// </summary>
        private readonly IBusClient _busClient;

        /// <summary>
        /// The identity service
        /// </summary>
        private readonly IIdentityService _identityService;

        /// <summary>
        /// The logger
        /// </summary>
        private ILogger _logger;

        /// <summary>
        /// Instantiates a user handler
        /// </summary>
        /// <param name="busClient">The RawRabbit bus client</param>
        /// <param name="identityService">The identity service</param>
        /// <param name="logger">The logger</param>
        public CreateUserHandler(IBusClient busClient, IIdentityService identityService, ILogger<CreateUserHandler> logger)
        {
            _busClient = busClient;
            _identityService = identityService;
            _logger = logger;
        }

        /// <summary>
        /// Handles the incoming <see cref="CreateUser"/> command and publishes a <see cref="UserCreated"/> event
        /// </summary>
        /// <param name="command">The <see cref="CreateUser"/> command to handle</param>
        /// <returns>A <see cref="Task"/>The awaitable task</returns>
        public async Task HandleAsync(CreateUser command)
        {
            _logger.LogInformation($"Creating user: {command.Name} {command.Email}");

            try
            {
                await _identityService.AddAsync(command.Email, command.Name, command.Password);

                await _busClient.PublishAsync(new UserCreated(command.Email, command.Name));

                return;
            }
            catch (ActioException ex)
            {
                await _busClient.PublishAsync(new CreateUserRejected(command.Email, ex.Code, ex.Message));
                _logger.LogInformation(ex.Message);
            }
            catch (Exception ex)
            {
                await _busClient.PublishAsync(new CreateUserRejected(command.Email, "error", ex.Message));
                _logger.LogInformation(ex.Message);
            }
        }
    }
}
