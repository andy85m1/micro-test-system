using System.Threading.Tasks;

namespace Actio.Services.Identity.Services
{
    public interface IIdentityService
    {
        /// <summary>
        /// Adds an identity to the service
        /// </summary>
        /// <param name="email"></param>
        /// <param name="name"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        Task AddAsync(string email, string name, string password);
    }
}
