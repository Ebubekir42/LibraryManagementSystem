using LMS.Entities.Models;
using LMS.Services.Contracts;
using LMS.Repositories.Contracts;

namespace LMS.Services
{
    public class MediaTypeManager : IMediaTypeService
    {
        private readonly IRepositoryManager _manager;
        public MediaTypeManager(IRepositoryManager manager)
        {
            _manager = manager;
        }

        public IEnumerable<MediaType> GetAllMediaTypes(bool trackChanges)
        {
            return _manager.MediaType.GetAllMediaTypes(trackChanges);
        }
        public MediaType GetMediaType(int id, bool trackChanges)
        {
            return _manager.MediaType.GetMediaType(id, trackChanges);
        }
    }
}
