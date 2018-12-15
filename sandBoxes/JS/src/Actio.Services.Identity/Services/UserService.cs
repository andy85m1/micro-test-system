using Actio.Common.Exceptions;
using Actio.Services.Identity.Domain.Models;
using Actio.Services.Identity.Domain.Repositories;
using Actio.Services.Identity.Domain.Services;
using System.Threading.Tasks;

namespace Actio.Services.Identity.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IEncryptor _encryptor;

        public UserService(IUserRepository userRepository, IEncryptor encryptor)
        {
            _userRepository = userRepository;
            _encryptor = encryptor;
        }

        public async Task RegisterAsync(string email, string password, string name)
        {
            var user = await _userRepository.GetAsync(email);

            if (user != null)
                throw new ActioException("email_in_use", $"Email: '{email}' is already in use.");

            user = new User(email, name);
            user.SetPassword(password, _encryptor);
            await _userRepository.AddAsync(user);
        }

        public async Task LoginAsync(string email, string password)
        {
            var user = await _userRepository.GetAsync(email);

            if (user == null)
                throw new ActioException("invalid_credentials", $"Invalid credentials");

            if (!user.ValidatePassword(password, _encryptor))
                throw new ActioException("invalid_credentials", $"Invalid credentials");
        }
    }
}
