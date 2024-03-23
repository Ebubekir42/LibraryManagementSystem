using LMS.Entities.Models;

namespace LMS.Services.Contracts
{
    public interface IFormatService
    {
        IEnumerable<Format> GetAllFormats(bool trackChanges);
        Format GetFormat(int id, bool trackChanges);
    }
}
