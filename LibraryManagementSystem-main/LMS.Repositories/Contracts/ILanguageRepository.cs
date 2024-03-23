using LMS.Entities.Models;

namespace LMS.Repositories.Contracts
{
    public interface ILanguageRepository : IRepostioryBase<Language>
    {
        IQueryable<Language> GetAllLanguages(bool trackChanges);
        Language GetLanguage(int id, bool trackChanges);
    }
}
