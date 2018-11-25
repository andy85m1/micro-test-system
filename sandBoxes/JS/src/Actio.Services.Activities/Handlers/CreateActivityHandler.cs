using Actio.Common.Commands;
using Actio.Common.Events;
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
        /// Instantiates an activity handler
        /// </summary>
        /// <param name="busClient">The RawRabbit bus client</param>
        public CreateActivityHandler(IBusClient busClient)
        {
            _busClient = busClient;
        }

        /// <summary>
        /// Handles the incoming <see cref="CreateActivity"/> command and publishes a <see cref="ActivityCreated"/> event
        /// </summary>
        /// <param name="command">The <see cref="CreateActivity"/> command to handle</param>
        /// <returns>A <see cref="Task"/></returns>
        public async Task HandleAsync(CreateActivity command)
        {
            Console.WriteLine($"Creating activity: {command.Name}");
            await _busClient.PublishAsync(new ActivityCreated(command.Id, command.UserId, command.Category, command.Name));
        }
    }
}
