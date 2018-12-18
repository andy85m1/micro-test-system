using System.Threading.Tasks;

namespace Actio.Common.Events
{
    /// <summary>
    /// Handles an event
    /// </summary>
    /// <typeparam name="T">The type of event which implements IEvent</typeparam>
    public interface IEventHandler<in T> where T: IEvent
    {
        /// <summary>
        /// Handles the event asynchronously
        /// </summary>
        /// <param name="event">The event to handle</param>
        /// <returns>Async task</returns>
        Task HandleAsync(T @event);
    }
}
