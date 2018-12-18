namespace Actio.Common.Mongo
{
    /// <summary>
    /// MongoDB options
    /// </summary>
    public class MongoOptions
    {
        /// <summary>
        /// The database connection string
        /// </summary>
        public string ConnectionString { get; set; }

        /// <summary>
        /// The database name
        /// </summary>
        public string Database { get; set; }

        /// <summary>
        /// Seed the database with predefined data
        /// </summary>
        public bool Seed { get; set; }
    }
}
