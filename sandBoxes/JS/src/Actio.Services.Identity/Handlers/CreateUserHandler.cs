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
    /// <summary>
    /// Create user command handler
    /// </summary>
    public class CreateUserHandler : ICommandHandler<CreateUser>
    {
        /// <summary>
        /// RawRabbit bus client
        /// </summary>
        private readonly IBusClient _busClient;

        /// <summary>
        /// The user service
        /// </summary>
        private readonly IUserService _userService;

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
        public CreateUserHandler(IBusClient busClient, IUserService userService, ILogger<CreateUserHandler> logger)
        {
            _busClient = busClient;
            _userService = userService;
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
                await _userService.RegisterAsync(command.Email, command.Password, command.Name);

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
