using System;

namespace Actio.Common.Events
{
    /// <summary>
    /// Authenticate event interface
    /// </summary>
    public interface IAuthenticatedEvent : IEvent
    {
        /// <summary>
        /// The authenticated user ID
        /// </summary>
        Guid UserId { get; }
    }
}
