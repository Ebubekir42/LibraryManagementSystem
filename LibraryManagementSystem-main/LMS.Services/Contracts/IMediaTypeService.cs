using LMS.Entities.Models;

namespace LMS.Services.Contracts
{
    public interface IMediaTypeService
    {
        IEnumerable<MediaType> GetAllMediaTypes(bool trackChanges);
        MediaType GetMediaType(int id, bool trackChanges);
    }
}
