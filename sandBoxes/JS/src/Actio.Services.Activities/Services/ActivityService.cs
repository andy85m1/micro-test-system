using Actio.Common.Exceptions;
using Actio.Services.Activities.Domain.Models;
using Actio.Services.Activities.Domain.Repositories;
using System;
using System.Threading.Tasks;

namespace Actio.Services.Activities.Services
{
    /// <summary>
    /// The activity service
    /// </summary>
    public class ActivityService : IActivityService
    {
        private readonly IActivityRepository _activityRepository;
        private readonly ICategoryRepository _categoryRepository;

        /// <summary>
        /// Instantiates the activity service
        /// </summary>
        /// <param name="activityRepository">The activity repository</param>
        /// <param name="categoryRepository">The category repoistory</param>
        public ActivityService(IActivityRepository activityRepository, ICategoryRepository categoryRepository)
        {
            _activityRepository = activityRepository;
            _categoryRepository = categoryRepository;
        }

        /// <summary>
        /// Adds an activity to the repository
        /// </summary>
        /// <param name="id">The activity ID</param>
        /// <param name="userId">The user ID</param>
        /// <param name="category">The activity category</param>
        /// <param name="name">The activity name</param>
        /// <param name="description">The activity description</param>
        /// <param name="createdAt">The activity created timestamp</param>
        /// <returns></returns>
        public async Task AddAsync(Guid id, Guid userId, string category, string name, string description, DateTime createdAt)
        {
            var activityCategory = await _categoryRepository.GetAsync(category);
            if(activityCategory == null)
            {
                throw new ActioException("category_not_found", $"Category: '{category}' was not found.");
            }

            var activity = new Activity(id, name, activityCategory, description, userId, createdAt);

            await _activityRepository.AddAsync(activity);
        }
    }
}
