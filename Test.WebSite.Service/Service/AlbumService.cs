using Test.WebSite.DataAccess.Infrastructure;
using Test.WebSite.DataAccess.Repository;
using Test.WebSite.Domain.EntityModel;
using Test.WebSite.Service.Common;

namespace Test.WebSite.Service.Service
{
   public class AlbumService: EntityService<Album>, IAlbumService
    {
        IUnitOfWork _unitOfWork;
        IAlbumRepository _albumRepository;
       
        /// <summary>
        /// Initializes a new instance of the <see cref="AlbumService"/> class.
        /// </summary>
        /// <param name="unitOfWork">The unit of work.</param>
        /// <param name="albumRepository">The album repository.</param>
        public AlbumService(IUnitOfWork unitOfWork, IAlbumRepository albumRepository)
            : base(unitOfWork, albumRepository)
        {
            _unitOfWork = unitOfWork;
            _albumRepository = albumRepository;
        }

        /// <summary>
        /// Gets the by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public Album GetById(int id)
        {
            return _albumRepository.GetById(id);
        }
    }
}
