using Actio.Services.Activities.Domain.Models;
using Actio.Services.Activities.Domain.Repositories;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Actio.Services.Activities.Repositories
{
    /// <summary>
    /// Activity repository
    /// </summary>
    public class ActivityRepository : IActivityRepository
    {
        /// <summary>
        /// The MongoDB database
        /// </summary>
        private readonly IMongoDatabase _database;

        /// <summary>
        /// Gets the Activities collection from the repository
        /// </summary>
        private IMongoCollection<Activity> Collection => _database.GetCollection<Activity>("Activities");

        /// <summary>
        /// Instantiates the MongoDB repository
        /// </summary>
        /// <param name="database">The MongoDB database</param>
        public ActivityRepository(IMongoDatabase database)
        {
            _database = database;
        }

        /// <summary>
        /// Gets an activity by its given ID
        /// </summary>
        /// <param name="id">The activity ID</param>
        /// <returns>The activity</returns>
        public async Task<Activity> GetAsync(Guid id)
            => await Collection
            .AsQueryable()
            .FirstOrDefaultAsync(x => x.Id == id);
        
        /// <summary>
        /// Adds an activity to the repository
        /// </summary>
        /// <param name="activity">The activity to add to the repository</param>
        /// <returns></returns>
        public async Task AddAsync(Activity activity)
            => await Collection.InsertOneAsync(activity);
    }
}
