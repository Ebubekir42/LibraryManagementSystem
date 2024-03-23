using LMS.Entities.Models;
using LMS.Services.Contracts;
using LMS.Repositories.Contracts;

namespace LMS.Services
{
    public class LanguageManager : ILanguageService
    {
        private readonly IRepositoryManager _manager;
        public LanguageManager(IRepositoryManager manager)
        {
            _manager = manager;
        }

        public IEnumerable<Language> GetAllLanguages(bool trackChanges)
        {
            return _manager.Language.GetAllLanguages(trackChanges);
        }
        public Language GetLanguage(int id, bool trackChanges)
        {
            return _manager.Language.GetLanguage(id, trackChanges);
        }
    }
}
