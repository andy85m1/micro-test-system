using System.Threading.Tasks;

namespace Actio.Common.Mongo
{
    /// <summary>
    /// Database seeder interface
    /// </summary>
    public interface IDatabaseSeeder
    {
        /// <summary>
        /// Seeds the database with predefined data
        /// </summary>
        /// <returns></returns>
        Task SeedAsync();
    }
}
