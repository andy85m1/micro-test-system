using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Actio.Common.Mongo
{
    public class MongoSeeder : IDatabaseSeeder
    {
        
        protected readonly IMongoDatabase Database;
        

        public MongoSeeder(IMongoDatabase database)
        {
            Database = database;    
        }


        public async Task SeedAsync()
        {
            var collectionCursor = await Database.ListCollectionsAsync();
            var collections = await collectionCursor.ToListAsync();

            if (collections.Any())
                return;

            await CustomSeedAsync();
        }

        protected virtual async Task CustomSeedAsync()
        {
            await Task.CompletedTask;
        }
    }
}
