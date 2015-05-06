using Test.WebSite.Domain.EntityModel;
using Test.WebSite.Service.Common;

namespace Test.WebSite.Service.Service
{
    public interface IAlbumService : IEntityService<Album>
    {
        /// <summary>
        /// Gets the by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        Album GetById(int id);
    }
}
