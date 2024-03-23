using LMS.Entities.Models;
using System.Linq.Expressions;

namespace LMS.Repositories.Contracts
{
    public interface IMediaTypeRepository : IRepostioryBase<MediaType>
    {
        IQueryable<MediaType> GetAllMediaTypes(bool trackCghanges);
        MediaType GetMediaType(int id, bool trackChanges);
    }
}
