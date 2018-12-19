using Actio.Api.Models;
using Actio.Api.Repositories;
using Actio.Common.Events;
using System;
using System.Threading.Tasks;

namespace Actio.Api.Handlers
{
    /// <summary>
    /// Handles the <see cref="ActivityCreated"/> event
    /// </summary>
    public class ActivityCreatedHandler : IEventHandler<ActivityCreated>
    {
        private readonly IActivityRepository _activityRepository;

        /// <summary>
        /// Instantiates the Activity created handler
        /// </summary>
        /// <param name="activityRepository">An activity repository</param>
        public ActivityCreatedHandler(IActivityRepository activityRepository)
        {
            _activityRepository = activityRepository;
        }

        /// <summary>
        /// Handles the <see cref="ActivityCreated"/> event and returns the Activity Data Transfer Object to the client
        /// </summary>
        /// <param name="event">The <see cref="ActivityCreated"/> event to handle</param>
        /// <returns></returns>
        public async Task HandleAsync(ActivityCreated @event)
        {
            await _activityRepository.AddAsync(new ActivityDTO
            {
                Id = @event.Id,
                Name = @event.Name,
                Category = @event.Category,
                Description = @event.Description,
                UserId = @event.UserId,
                CreatedAt = @event.CreatedAt
            });

            Console.WriteLine($"Activity created: {@event.Name}");
        }
    }
}
