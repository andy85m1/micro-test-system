using System;
using System.Threading.Tasks;

namespace Actio.Services.Activities.Services
{
    /// <summary>
    /// Activity service interface
    /// </summary>
    public interface IActivityService
    {
        /// <summary>
        /// Adds an activity to the service
        /// </summary>
        /// <param name="id">The activity ID</param>
        /// <param name="userId">The user ID of the activity creator</param>
        /// <param name="category">The activity category</param>
        /// <param name="name">The activity name</param>
        /// <param name="description">The activity description</param>
        /// <param name="createdAt">The activity's creation timestamp</param>
        /// <returns></returns>
        Task AddAsync(Guid id, Guid userId, string category, string name, string description, DateTime createdAt);
    }
}
