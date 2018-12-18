using Actio.Common.Events;
using System;
using System.Threading.Tasks;

namespace Actio.Api.Handlers
{
    /// <summary>
    /// Handles the <see cref="UserAuthenticated"/> event
    /// </summary>
    public class UserAuthenticatedHandler : IEventHandler<UserAuthenticated>
    {
        /// <summary>
        /// Handles the <see cref="UserAuthenticated"/> event
        /// </summary>
        /// <param name="event">The <see cref="UserAuthenticated"/> event to handle</param>
        /// <returns></returns>
        public async Task HandleAsync(UserAuthenticated @event)
        {
            await Task.CompletedTask;
            Console.WriteLine($"User authenticated: {@event.Email}");
        }
    }
}
