using LMS.Entities.Models;
using LMS.Repositories.Contracts;

namespace LMS.Repositories
{
    public class ContentTypeRepository : RepositoryBase<ContentType>, IContentTypeRepository
    {
        public ContentTypeRepository(RepositoryContext context) : base(context)
        {
        }

        public IQueryable<ContentType> GetAllContentTypes(bool trackChanges) => FindAll(trackChanges);
        public ContentType GetContentType(int id, bool trackChanges)
        {
            return FindByCondition(x => x.ContentTypeId.Equals(id), trackChanges);
        }
    }
}
