using Actio.Api.Models;
using Actio.Api.Repositories;
using Actio.Common.Events;
using System;
using System.Threading.Tasks;

namespace Actio.Api.Handlers
{
    /// <summary>
    /// Handles the <see cref="UserCreated"/> event
    /// </summary>
    public class UserCreatedHandler : IEventHandler<UserCreated>
    {
        private readonly IUserRepository _userRepository;

        /// <summary>
        /// Instantiates the User created handler
        /// </summary>
        /// <param name="userRepository">A user repository</param>
        public UserCreatedHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        /// <summary>
        /// Handles the <see cref="UserCreated"/> event and returns the user Data Transfer Object to the client
        /// </summary>
        /// <param name="event">The <see cref="UserCreated"/> event to handle</param>
        /// <returns></returns>
        public async Task HandleAsync(UserCreated @event)
        {
            await _userRepository.AddAsync(new UserDTO
            {
                Email = @event.Email,
                Name = @event.Name
            });

            Console.WriteLine($"User created: {@event.Name}");
        }
    }
}
