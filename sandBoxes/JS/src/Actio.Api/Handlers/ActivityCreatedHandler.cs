using Actio.Common.Events;
using System;
using System.Threading.Tasks;

namespace Actio.Api.Handlers
{
    /// <summary>
    /// Handles the <see cref="ActivityCreated"/> event
    /// </summary>
    public class ActivityCreatedHandler : IEventHandler<ActivityCreated>
    {
        /// <summary>
        /// Handles the <see cref="ActivityCreated"/> event 
        /// </summary>
        /// <param name="event">The <see cref="ActivityCreated"/> event to handle</param>
        /// <returns></returns>
        public async Task HandleAsync(ActivityCreated @event)
        {
            await Task.CompletedTask;
            Console.WriteLine($"Activity created: {@event.Name}");
        }
    }
}
