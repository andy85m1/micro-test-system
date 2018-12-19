using Actio.Api.Models;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Actio.Api.Repositories
{
    /// <summary>
    /// User repository
    /// </summary>
    public class UserRepository : IUserRepository
    {
        /// <summary>
        /// The MongoDB database
        /// </summary>
        private readonly IMongoDatabase _database;

        /// <summary>
        /// Gets the Users collection from the repository
        /// </summary>
        private IMongoCollection<UserDTO> Collection => _database.GetCollection<UserDTO>("Users");

        /// <summary>
        /// Instantiates the MongoDB repository
        /// </summary>
        /// <param name="database"></param>
        public UserRepository(IMongoDatabase database)
        {
            _database = database;
        }

        /// <summary>
        /// Gets a user using a given ID
        /// </summary>
        /// <param name="id">The user ID</param>
        /// <returns>The user</returns>
        public async Task<UserDTO> GetAsync(Guid id)
            => await Collection
            .AsQueryable()
            .FirstOrDefaultAsync(x => x.Id == id);

        /// <summary>
        /// Gets a user using a given email
        /// </summary>
        /// <param name="email">The user email</param>
        /// <returns>the user</returns>
        public async Task<UserDTO> GetAsync(string email)
            => await Collection
            .AsQueryable()
            .FirstOrDefaultAsync(x => x.Email == email.ToLowerInvariant());

        /// <summary>
        /// Adds a user to the repository
        /// </summary>
        /// <param name="user">The user to add to the repository</param>
        /// <returns></returns>
        public async Task AddAsync(UserDTO user)
            => await Collection.InsertOneAsync(user);
    }
}
