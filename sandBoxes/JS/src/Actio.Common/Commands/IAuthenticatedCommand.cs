using System;

namespace Actio.Common.Commands
{
    /// <summary>
    /// Authenticated command interface
    /// </summary>
    public interface IAuthenticatedCommand : ICommand
    {
        /// <summary>
        /// The user ID
        /// </summary>
        Guid UserId { get; set; }
    }
}
