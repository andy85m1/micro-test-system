using Actio.Api.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Actio.Api.Repositories
{
    /// <summary>
    /// Activity repository interface
    /// </summary>
    public interface IActivityRepository
    {
        Task<ActivityDTO> GetAsync(Guid id);

        Task AddAsync(ActivityDTO model);

        Task<IEnumerable<ActivityDTO>> BrowseAsync(Guid userId);
    }
}
