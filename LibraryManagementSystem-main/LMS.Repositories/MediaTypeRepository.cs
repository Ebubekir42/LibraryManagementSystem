using LMS.Entities.Models;
using LMS.Repositories.Contracts;

namespace LMS.Repositories
{
    public class MediaTypeRepository : RepositoryBase<MediaType>, IMediaTypeRepository
    {
        public MediaTypeRepository(RepositoryContext context) : base(context)
        {
        }

        public IQueryable<MediaType> GetAllMediaTypes(bool trackCghanges) => FindAll(trackCghanges);
        public MediaType GetMediaType(int id, bool trackChanges)
        {
            return FindByCondition(x => x.MediaTypeId.Equals(id),trackChanges);
        }
    }
}
