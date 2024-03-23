using LMS.Entities.Models;

namespace LMS.Services.Contracts
{
    public interface IContentTypeService
    {
        IEnumerable<ContentType> GetAllContentTypes(bool trackChanges);
        ContentType GetContentType(int id, bool trackChanges);
    }
}
