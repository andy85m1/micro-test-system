using Actio.Services.Activities.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Actio.Services.Activities.Domain.Repositories
{
    /// <summary>
    /// Defines a repository category
    /// </summary>
    public interface ICategoryRepository
    {
        /// <summary>
        /// Get the category for a given name
        /// </summary>
        /// <param name="name">The name of the category to return</param>
        /// <returns>The category</returns>
        Task<Category> GetAsync(string name);

        /// <summary>
        /// Returns all of the available categorys
        /// </summary>
        /// <returns>The list of categorys</returns>
        Task<IEnumerable<Category>> BrowseAsync();

        /// <summary>
        /// Saves the category to the database
        /// </summary>
        /// <param name="category">The category to save</param>
        /// <returns>A task</returns>
        Task AddAsync(Category category);
    }
}
