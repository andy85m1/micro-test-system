using System;

namespace Actio.Services.Activities.Domain.Models
{
    /// <summary>
    /// Category model
    /// </summary>
    public class Category
    {
        /// <summary>
        /// The category ID
        /// </summary>
        public Guid Id { get; protected set; }

        /// <summary>
        /// The category name
        /// </summary>
        public string Name { get; protected set; }

        /// <summary>
        /// Protected constructor
        /// </summary>
        protected Category()
        {
        }

        /// <summary>
        /// Instantiates a category and initialises the properties
        /// </summary>
        /// <param name="name">The name of the category</param>
        public Category(string name)
        {
            Id = Guid.NewGuid();
            Name = name.ToLowerInvariant();
        }
    }
}
