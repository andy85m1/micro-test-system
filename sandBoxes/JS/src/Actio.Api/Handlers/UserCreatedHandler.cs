using Actio.Common.Events;
using System;
using System.Threading.Tasks;

namespace Actio.Api.Handlers
{
    /// <summary>
    /// Handles the <see cref="UserCreated"/> event
    /// </summary>
    public class UserCreatedHandler : IEventHandler<UserCreated>
    {
        /// <summary>
        /// Handles the <see cref="UserCreated"/> event
        /// </summary>
        /// <param name="event">The <see cref="UserCreated"/> event to handle</param>
        /// <returns></returns>
        public async Task HandleAsync(UserCreated @event)
        {
            await Task.CompletedTask;
            Console.WriteLine($"User created: {@event.Name}");
        }
    }
}
