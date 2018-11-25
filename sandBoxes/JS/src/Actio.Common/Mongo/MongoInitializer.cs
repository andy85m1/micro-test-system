using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Conventions;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Actio.Common.Mongo
{
    public class MongoInitializer : IDatabaseInitializer
    {
        private bool _initialized;
        private readonly bool _seed;
        private readonly IMongoDatabase _database;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="database">A MongoDB database</param>
        /// <param name="options">MongoDB options</param>
        public MongoInitializer(IMongoDatabase database, IOptions<MongoOptions> options)
        {
            _database = database;
            _seed = options.Value.Seed;
        }
        
        /// <summary>
        /// 
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
        }

        /// <summary>
        /// 
        /// </summary>
        private void RegisterConventions()
        {
            ConventionRegistry.Register("ActioConventions", new MongoConvention(), x => true);
        }

        /// <summary>
        /// 
        /// </summary>
        private class MongoConvention : IConventionPack
        {
            public IEnumerable<IConvention> Conventions => new List<IConvention>
            {
                new IgnoreExtraElementsConvention(true),
                new EnumRepresentationConvention(BsonType.String),
                new CamelCaseElementNameConvention()
            };
        }
    }
}
