using Test.WebSite.DataAccess.Infrastructure;
using Test.WebSite.Domain.EntityModel;

namespace Test.WebSite.DataAccess.Repository
{
    public interface IAlbumRepository : IGenericRepository<Album>
    {
        /// <summary>
        /// Gets the by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        Album GetById(int id);
    }
}
