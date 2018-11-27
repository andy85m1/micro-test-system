using Actio.Services.Activities.Domain.Models;
using Actio.Services.Activities.Domain.Repositories;
using System;
using MongoDB.Driver.Linq;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Driver;

namespace Actio.Services.Activities.Repositories
{
    public class ActivityRepository : IActivityRepository
    {

        private readonly IMongoDatabase _database;

        /// <summary>
        /// 
        /// </summary>
        private IMongoCollection<Activity> Collection
            => _database.GetCollection<Activity>("Activities");

        /// <summary>
        /// 
        /// </summary>
        /// <param name="database"></param>
        public ActivityRepository(IMongoDatabase database)
        {
            _database = database;
        }


        public async Task<Activity> GetAsync(Guid id)
            => await Collection
            .AsQueryable()
            .FirstOrDefaultAsync(x => x.Id == id);


        public async Task AddAsync(Activity activity)
            => await Collection.InsertOneAsync(activity);
    }
}
