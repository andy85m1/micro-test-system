using Actio.Services.Identity.Domain.Models;
using Actio.Services.Identity.Domain.Repositories;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using System;
using System.Threading.Tasks;

namespace Actio.Services.Identity.Repositories
{
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
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<User> GetAsync(Guid id)
            => await Collection
            .AsQueryable()
            .FirstOrDefaultAsync(x => x.Id == id);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        public async Task<User> GetAsync(string email)
            => await Collection
            .AsQueryable()
            .FirstOrDefaultAsync(x => x.Email == email.ToLowerInvariant());

        /// <summary>
        /// 
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public async Task AddAsync(User user)
            => await Collection.InsertOneAsync(user); 


    }
}
