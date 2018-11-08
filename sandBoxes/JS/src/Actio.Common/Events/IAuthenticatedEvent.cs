using System;

namespace Actio.Common.Events
{
    public interface IAuthenticatedEvent : IEvent
    {
        /// <summary>
        /// The authenticated user ID
        /// </summary>
        Guid UserId { get; }
    }
}
