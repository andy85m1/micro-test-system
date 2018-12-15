using System;

namespace Actio.Common.Events
{
    /// <summary>
    /// Activity created event
    /// </summary>
    public class ActivityCreated : IAuthenticatedEvent
    {
        /// <summary>
        /// The activity's unique ID
        /// </summary>
        public Guid Id { get; }

        /// <summary>
        /// The user ID of the activity creator
        /// </summary>
        public Guid UserId { get; }

        /// <summary>
        /// The category of the activity
        /// </summary>
        public string Category { get; }

        /// <summary>
        /// The name of the activity
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// Description of the activity
        /// </summary>
        public string Description { get; }

        /// <summary>
        /// The activity creation time stamp
        /// </summary>
        public DateTime CreatedAt { get; }


        /// <summary>
        /// Protected constructor
        /// </summary>
        protected ActivityCreated()
        {
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="id">The activity's unique ID</param>
        /// <param name="userId">The user ID of the activity creator</param>
        /// <param name="category">The category of the activity</param>
        /// <param name="name">The name of the activity</param>
        /// <param name="description">Description of the activity</param>
        /// <param name="createdAt">The activity creation time stamp</param>
        public ActivityCreated(Guid id, Guid userId, string category, string name, string description, DateTime createdAt)
        {
            Id = id;
            UserId = userId;
            Category = category;
            Name = name;
            Description = description;
            CreatedAt = createdAt;
        }
    }
}
