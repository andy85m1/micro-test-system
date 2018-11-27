using Actio.Services.Activities.Domain.Models;
using Actio.Services.Activities.Domain.Repositories;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Actio.Services.Activities.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly IMongoDatabase _database;


        /// <summary>
        /// 
        /// </summary>
        private IMongoCollection<Category> Collection
            => _database.GetCollection<Category>("Categories");

        /// <summary>
        /// 
        /// </summary>
        /// <param name="database"></param>
        public CategoryRepository(IMongoDatabase database)
        {
            _database = database;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public async Task<Category> GetAsync(string name)
        => await Collection
            .AsQueryable()
            .FirstOrDefaultAsync(x => x.Name == name.ToLowerInvariant());

        /// <summary>
        /// 
        /// </summary>
        /// <param name="category"></param>
        /// <returns></returns>
        public async Task AddAsync(Category category)
            => await Collection.InsertOneAsync(category);

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<Category>> BrowseAsync()
            => await Collection
            .AsQueryable()
            .ToListAsync();
    }
}
