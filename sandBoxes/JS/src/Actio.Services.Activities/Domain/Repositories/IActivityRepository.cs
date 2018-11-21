using Actio.Services.Activities.Domain.Models;
using System;
using System.Threading.Tasks;

namespace Actio.Services.Activities.Domain.Repositories
{
    /// <summary>
    /// Defines a repository activity
    /// </summary>
    public interface IActivityRepository
    {
        /// <summary>
        /// Get the activity for a given ID
        /// </summary>
        /// <param name="id">The ID of the activity to return</param>
        /// <returns>The activity</returns>
        Task<Activity> GetAsync(Guid id);

        /// <summary>
        /// Saves the activity to the database
        /// </summary>
        /// <param name="activity">The activity to save</param>
        /// <returns>A task</returns>
        Task AddAsync(Activity activity);
    }
}
