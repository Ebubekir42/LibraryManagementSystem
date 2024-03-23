using LMS.Entities.Models;

namespace LMS.Services.Contracts
{
    public interface ILanguageService
    {
        IEnumerable<Language> GetAllLanguages(bool trackChanges);
        Language GetLanguage(int id, bool trackChanges);
    }
}
