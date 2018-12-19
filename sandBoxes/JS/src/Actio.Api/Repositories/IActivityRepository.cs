using Actio.Api.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Actio.Api.Repositories
{
    /// <summary>
    /// DTO Activity repository interface
    /// </summary>
    public interface IActivityRepository
    {
        /// <summary>
        /// Gets an ActivityDTO for a given id
        /// </summary>
        /// <param name="id">The activity id</param>
        /// <returns>The ActivityDTO</returns>
        Task<ActivityDTO> GetAsync(Guid id);

        /// <summary>
        /// Adds an ActivityDTO to the repository
        /// </summary>
        /// <param name="activity">The ActivityDTO to add to the repository</param>
        /// <returns></returns>
        Task AddAsync(ActivityDTO activity);

        /// <summary>
        /// Searches the activity repository for an activityDTO for a given user ID
        /// </summary>
        /// <param name="userId">The activity user ID to search</param>
        /// <returns>The activityDTO</returns>
        Task<IEnumerable<ActivityDTO>> BrowseAsync(Guid userId);
    }
}
