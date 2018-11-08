using System.Threading.Tasks;

namespace Actio.Common.Commands
{
    /// <summary>
    /// Handles a command
    /// </summary>
    /// <typeparam name="T">The command type which implements ICommand</typeparam>
    public interface ICommandHandler<in T> where T : ICommand
    {
        /// <summary>
        /// Handles the command asynchronously
        /// </summary>
        /// <param name="command">The command to handle</param>
        /// <returns>Async task</returns>
        Task HandleAsync(T command);
    }
}
