using LMS.Entities.Models;
using LMS.Services.Contracts;
using LMS.Repositories.Contracts;

namespace LMS.Services
{
    public class FormatManager : IFormatService
    {
        private readonly IRepositoryManager _manager;
        public FormatManager(IRepositoryManager manager)
        {
            _manager = manager;
        }

        public IEnumerable<Format> GetAllFormats(bool trackChanges)
        {
            return _manager.Format.GetAllFormats(trackChanges);
        }
        public Format GetFormat(int id, bool trackChanges)
        {
            return _manager.Format.GetFormat(id, trackChanges);
        }
    }
}
