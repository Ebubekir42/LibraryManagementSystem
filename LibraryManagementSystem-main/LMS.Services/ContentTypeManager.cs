using LMS.Entities.Models;
using LMS.Services.Contracts;
using LMS.Repositories.Contracts;

namespace LMS.Services
{
    public class ContentTypeManager : IContentTypeService
    {
        private readonly IRepositoryManager _manager;
        public ContentTypeManager(IRepositoryManager manager)
        {
            _manager = manager;
        }

        public IEnumerable<ContentType> GetAllContentTypes(bool trackChanges)
        {
            return _manager.ContentType.GetAllContentTypes(trackChanges);
        }
        public ContentType GetContentType(int id, bool trackChanges)
        {
            return _manager.ContentType.GetContentType(id, trackChanges);
        }
    }
}
