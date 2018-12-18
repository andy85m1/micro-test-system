using MongoDB.Bson;
using MongoDB.Bson.Serialization.Conventions;
using System.Collections.Generic;

namespace Actio.Common.Mongo
{
    public partial class MongoInitializer
    {
        /// <summary>
        /// MongoDB conventions
        /// </summary>
        private class MongoConvention : IConventionPack
        {
            /// <summary>
            /// Gets the MongoDB defined conventions
            /// </summary>
            public IEnumerable<IConvention> Conventions => new List<IConvention>
            {
                new IgnoreExtraElementsConvention(true),
                new EnumRepresentationConvention(BsonType.String),
                new CamelCaseElementNameConvention()
            };
        }
    }
}
