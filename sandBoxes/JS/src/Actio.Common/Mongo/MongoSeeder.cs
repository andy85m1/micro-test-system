using MongoDB.Driver;
using System.Linq;
using System.Threading.Tasks;

namespace Actio.Common.Mongo
{
    /// <summary>
    /// Seeds a MongoDB database with predefined data
    /// </summary>
    public class MongoSeeder : IDatabaseSeeder
    {
        
        protected readonly IMongoDatabase Database;
        
        /// <summary>
        /// Instantiates the MongoDB database seeder
        /// </summary>
        /// <param name="database">The MongoDB database</param>
        public MongoSeeder(IMongoDatabase database)
        {
            Database = database;    
        }

        /// <summary>
        /// Seeds the database with predefined data
        /// </summary>
        /// <returns></returns>
        public async Task SeedAsync()
        {
            var collectionCursor = await Database.ListCollectionsAsync();
            var collections = await collectionCursor.ToListAsync();

            if (collections.Any())
                return;

            await CustomSeedAsync();
        }

        /// <summary>
        /// Applys a custom seed to the database
        /// </summary>
        /// <returns></returns>
        protected virtual async Task CustomSeedAsync()
        {
            await Task.CompletedTask;
        }
    }
}
