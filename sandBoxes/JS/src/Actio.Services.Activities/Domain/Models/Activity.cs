using Actio.Common.Exceptions;
using System;

namespace Actio.Services.Activities.Domain.Models
{
    /// <summary>
    /// Activity model
    /// </summary>
    public class Activity
    {
        /// <summary>
        /// The activity ID
        /// </summary>
        public Guid Id { get; protected set; }

        /// <summary>
        /// The activity name
        /// </summary>
        public string Name { get; protected set; }

        /// <summary>
        /// The category
        /// </summary>
        public string Category { get; protected set; }

        /// <summary>
        /// The activity description
        /// </summary>
        public string Description { get; protected set; }

        /// <summary>
        /// The activity's creator
        /// </summary>
        public Guid UserId { get; protected set; }

        /// <summary>
        /// The activity created timestamp
        /// </summary>
        public DateTime CreatedAt { get; protected set; }

        /// <summary>
        /// Protected constructor
        /// </summary>
        protected Activity()
        {
        }

        /// <summary>
        /// Instantiates an activity and initialises the properties
        /// </summary>
        /// <param name="id">The activity ID</param>
        /// <param name="name">The activity name</param>
        /// <param name="category">The category</param>
        /// <param name="description">The activity description</param>
        /// <param name="userId">The activity's creator</param>
        /// <param name="createdAt">The activity created timestamp</param>
        public Activity(Guid id, string name, Category category, string description, Guid userId , DateTime createdAt)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ActioException("empty_activity_name", $"Activity name cannot be empty.");

            Id = id;
            Category = category.Name;
            UserId = userId;
            Name = name;
            Description = description;
            CreatedAt = createdAt;
        }
    }
}
