using Actio.Common.Mongo;
using Actio.Services.Activities.Domain.Models;
using Actio.Services.Activities.Domain.Repositories;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Actio.Services.Activities.Services
{
    /// <summary>
    /// Custom MongoDB database seeder
    /// </summary>
    public class CustomMongoSeeder : MongoSeeder
    {
        private readonly ICategoryRepository _categoryRepoisitory;

        /// <summary>
        /// Instantiates the custom MongoDB database seeder
        /// </summary>
        /// <param name="database"></param>
        /// <param name="categoryRepository"></param>
        public CustomMongoSeeder(IMongoDatabase database, ICategoryRepository categoryRepository) : base(database)
        {
            _categoryRepoisitory = categoryRepository;
        }

        /// <summary>
        /// Seeds the database with predefined data
        /// </summary>
        /// <returns></returns>
        protected override async Task CustomSeedAsync()
        {
            var categories = new List<string>()
            {
                "work",
                "sport",
                "hobby"
            };
            await Task.WhenAll(categories.Select(x => _categoryRepoisitory.AddAsync(new Category(x))));
        }
    }
}
