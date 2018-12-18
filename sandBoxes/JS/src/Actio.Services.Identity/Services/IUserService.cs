using Actio.Common.Auth;
using System.Threading.Tasks;

namespace Actio.Services.Identity.Services
{
    /// <summary>
    /// User service interface
    /// </summary>
    public interface IUserService
    {
        /// <summary>
        /// Registers a user to the repository
        /// </summary>
        /// <param name="email">The user's email</param>
        /// <param name="password">The user's password</param>
        /// <param name="name">The user's name</param>
        /// <returns></returns>
        Task RegisterAsync(string email, string password, string name);

        /// <summary>
        /// Log in to the system
        /// </summary>
        /// <param name="email">The user's email</param>
        /// <param name="password">The user's password</param>
        /// <returns>A Json web token</returns>
        Task<JsonWebToken> LoginAsync(string email, string password);
    }
}
