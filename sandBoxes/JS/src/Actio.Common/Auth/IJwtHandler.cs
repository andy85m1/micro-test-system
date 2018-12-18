using System;

namespace Actio.Common.Auth
{
    public interface IJwtHandler
    {
        /// <summary>
        /// Creates a Json web token for a given user
        /// </summary>
        /// <param name="userId">The user ID</param>
        /// <returns>The Json web token</returns>
        JsonWebToken Create(Guid userId);
    }
}
