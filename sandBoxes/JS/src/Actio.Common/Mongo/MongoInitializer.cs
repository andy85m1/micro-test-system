using Microsoft.Extensions.Options;
using MongoDB.Bson.Serialization.Conventions;
using MongoDB.Driver;
using System.Threading.Tasks;

namespace Actio.Common.Mongo
{
    /// <summary>
    /// Initialises MongoDB
    /// </summary>
    public partial class MongoInitializer : IDatabaseInitializer
    {
        private bool _initialized;
        private readonly bool _seed;
        private readonly IMongoDatabase _database;
        private readonly IDatabaseSeeder _seeder;

        /// <summary>
        /// Instantiates the MondoDB initialiser
        /// </summary>
        /// <param name="database">A MongoDB database</param>
        /// <param name="options">MongoDB options</param>
        public MongoInitializer(IMongoDatabase database, IDatabaseSeeder seeder, IOptions<MongoOptions> options)
        {
            _database = database;
            _seeder = seeder;
            _seed = options.Value.Seed;
        }
        
        /// <summary>
        /// Initialises MongoDB and seeds the database if applicable
        /// </summary>
        /// <returns></returns>
        public async Task InitialiseAsync()
        {
            if (_initialized)
                return;

            RegisterConventions();
            _initialized = true;

            if (!_seed)
                return;

            await _seeder.SeedAsync();
        }

        /// <summary>
        /// Registers the MongoDB conventions
        /// </summary>
        private void RegisterConventions()
        {
            ConventionRegistry.Register("ActioConventions", new MongoConvention(), x => true);
        }
    }
}
