using Actio.Services.Identity.Domain.Models;
using Actio.Services.Identity.Domain.Repositories;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using System;
using System.Threading.Tasks;

namespace Actio.Services.Identity.Repositories
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
        private IMongoCollection<User> Collection => _database.GetCollection<User>("Users");

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
        public async Task<User> GetAsync(Guid id)
            => await Collection
            .AsQueryable()
            .FirstOrDefaultAsync(x => x.Id == id);

        /// <summary>
        /// Gets a user using a given email
        /// </summary>
        /// <param name="email">The user email</param>
        /// <returns>the user</returns>
        public async Task<User> GetAsync(string email)
            => await Collection
            .AsQueryable()
            .FirstOrDefaultAsync(x => x.Email == email.ToLowerInvariant());

        /// <summary>
        /// Adds a user to the repository
        /// </summary>
        /// <param name="user">The user to add to the repository</param>
        /// <returns></returns>
        public async Task AddAsync(User user)
            => await Collection.InsertOneAsync(user); 
    }
}
