using Actio.Common.Auth;
using Actio.Common.Exceptions;
using Actio.Services.Identity.Domain.Models;
using Actio.Services.Identity.Domain.Repositories;
using Actio.Services.Identity.Domain.Services;
using System.Threading.Tasks;

namespace Actio.Services.Identity.Services
{
    /// <summary>
    /// The user service
    /// </summary>
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IEncryptor _encryptor;
        private readonly IJwtHandler _jwtHandler;

        /// <summary>
        /// Instantiates a user service
        /// </summary>
        /// <param name="userRepository">The user repository</param>
        /// <param name="encryptor">The encryptor</param>
        /// <param name="jwtHandler">The Json web token handler</param>
        public UserService(IUserRepository userRepository, IEncryptor encryptor, IJwtHandler jwtHandler)
        {
            _userRepository = userRepository;
            _encryptor = encryptor;
            _jwtHandler = jwtHandler;
        }

        /// <summary>
        /// Registers a user into the repository
        /// </summary>
        /// <param name="email">The user's email</param>
        /// <param name="password">The user's password</param>
        /// <param name="name">The user's name</param>
        /// <returns></returns>
        public async Task RegisterAsync(string email, string password, string name)
        {
            var user = await _userRepository.GetAsync(email);

            if (user != null)
                throw new ActioException("email_in_use", $"Email: '{email}' is already in use.");

            user = new User(email, name);
            user.SetPassword(password, _encryptor);
            await _userRepository.AddAsync(user);
        }

        /// <summary>
        /// Logs the user into the system
        /// </summary>
        /// <param name="email">The user's email</param>
        /// <param name="password">The user's password</param>
        /// <returns>A Json web token</returns>
        public async Task<JsonWebToken> LoginAsync(string email, string password)
        {
            var user = await _userRepository.GetAsync(email);

            if (user == null)
                throw new ActioException("invalid_credentials", $"Invalid credentials");

            if (!user.ValidatePassword(password, _encryptor))
                throw new ActioException("invalid_credentials", $"Invalid credentials");

            return _jwtHandler.Create(user.Id);
        }
    }
}
