using Actio.Services.Activities.Domain.Models;
using Actio.Services.Activities.Domain.Repositories;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Actio.Services.Activities.Repositories
{
    /// <summary>
    /// Category repository
    /// </summary>
    public class CategoryRepository : ICategoryRepository
    {
        private readonly IMongoDatabase _database;
        
        /// <summary>
        /// Gets the Categories collection
        /// </summary>
        private IMongoCollection<Category> Collection
            => _database.GetCollection<Category>("Categories");

        /// <summary>
        /// Instantiates the category repository
        /// </summary>
        /// <param name="database">The MongoDB database</param>
        public CategoryRepository(IMongoDatabase database)
        {
            _database = database;
        }

        /// <summary>
        /// Gets a category name
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public async Task<Category> GetAsync(string name)
        => await Collection
            .AsQueryable()
            .FirstOrDefaultAsync(x => x.Name == name.ToLowerInvariant());

        /// <summary>
        /// Adds a category
        /// </summary>
        /// <param name="category"></param>
        /// <returns></returns>
        public async Task AddAsync(Category category)
            => await Collection.InsertOneAsync(category);

        /// <summary>
        /// Gets the collection of categories
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<Category>> BrowseAsync()
            => await Collection
            .AsQueryable()
            .ToListAsync();
    }
}
