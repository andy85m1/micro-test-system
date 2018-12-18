using Actio.Services.Identity.Domain.Models;
using System;
using System.Threading.Tasks;

namespace Actio.Services.Identity.Domain.Repositories
{
    /// <summary>
    /// User repository interface
    /// </summary>
    public interface IUserRepository
    {
        /// <summary>
        /// Get the user by ID
        /// </summary>
        /// <param name="id">The user's ID</param>
        /// <returns>The user object</returns>
        Task<User> GetAsync(Guid id);

        /// <summary>
        /// Get the user by email
        /// </summary>
        /// <param name="email">The user's email</param>
        /// <returns>The user object</returns>
        Task<User> GetAsync(string email);

        /// <summary>
        /// Add a user to the repository
        /// </summary>
        /// <param name="user">The user to add</param>
        /// <returns>The user object</returns>
        Task AddAsync(User user);
    }
}
