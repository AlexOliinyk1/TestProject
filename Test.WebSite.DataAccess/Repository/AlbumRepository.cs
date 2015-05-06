using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Test.WebSite.DataAccess.Infrastructure;
using Test.WebSite.Domain.EntityModel;

namespace Test.WebSite.DataAccess.Repository
{
    public class AlbumRepository : GenericRepository<Album>, IAlbumRepository
    {
        public AlbumRepository(DbContext context)
            : base(context)
        {

        }

        /// <summary>
        /// Gets all.
        /// </summary>
        /// <returns></returns>
        public override IEnumerable<Album> GetAll()
        {
            return _entities.Set<Album>().AsEnumerable();
        }

        /// <summary>
        /// Gets the by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public Album GetById(int id)
        {
            return _dbset.FirstOrDefault(x => x.Id == id);
        }
    }
}
