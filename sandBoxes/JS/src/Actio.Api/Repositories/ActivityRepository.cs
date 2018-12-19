using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Actio.Api.Models;
using MongoDB.Driver;
using MongoDB.Driver.Linq;

namespace Actio.Api.Repositories
{
    /// <summary>
    /// The Activity repository
    /// </summary>
    public class ActivityRepository : IActivityRepository
    {
        private readonly IMongoDatabase _database;

        /// <summary>
        /// Returns the collection of ActivityDTO 
        /// </summary>
        private IMongoCollection<ActivityDTO> Collection
            => _database.GetCollection<ActivityDTO>("Activities");

        /// <summary>
        /// 
        /// </summary>
        /// <param name="database"></param>
        public ActivityRepository(IMongoDatabase database)
        {
            _database = database;
        }

        /// <summary>
        /// Adds an activity to the repository
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task AddAsync(ActivityDTO activity)
            => await Collection.InsertOneAsync(activity);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public async Task<IEnumerable<ActivityDTO>> BrowseAsync(Guid userId)
            => await Collection
            .AsQueryable()
            .Where(x => x.UserId == userId)
            .ToListAsync();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<ActivityDTO> GetAsync(Guid id)
        => await Collection
            .AsQueryable()
            .FirstOrDefaultAsync(x => x.Id == id);
    }
}
