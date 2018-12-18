using System.Threading.Tasks;

namespace Actio.Common.Mongo
{
    /// <summary>
    /// Database initialiser interface
    /// </summary>
    public interface IDatabaseInitializer
    {
        /// <summary>
        /// Initialises the database
        /// </summary>
        /// <returns></returns>
        Task InitialiseAsync(); 
    }
}
