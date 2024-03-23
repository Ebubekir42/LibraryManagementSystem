using LMS.Entities.Models;
namespace LMS.Repositories.Contracts
{
    public interface IFormatRepository : IRepostioryBase<Format>
    {
        IQueryable<Format> GetAllFormats(bool trackChanges);
        Format GetFormat(int id, bool trackChanges);
    }
}
