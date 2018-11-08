using System;

namespace Actio.Common.Commands
{
    public interface IAuthenticatedCommand : ICommand
    {
        /// <summary>
        /// The user ID
        /// </summary>
        Guid UserId { get; set; }
    }
}
