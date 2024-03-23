using LMS.Entities.Models;
namespace LMS.Repositories.Contracts
{
    public interface IContentTypeRepository : IRepostioryBase<ContentType>
    {
        IQueryable<ContentType> GetAllContentTypes(bool trackChanges);
        ContentType GetContentType(int id, bool trackChanges);
    }
}
