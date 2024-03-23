using LMS.Entities.Models;
using LMS.Repositories.Contracts;

namespace LMS.Repositories
{
    public class LanguageRepository : RepositoryBase<Language>, ILanguageRepository
    {
        public LanguageRepository(RepositoryContext context) : base(context)
        {
        }

        public IQueryable<Language> GetAllLanguages(bool trackChanges) => FindAll(trackChanges);
        public Language GetLanguage(int id, bool trackChanges)
        {
            return FindByCondition(x => x.LanguageId.Equals(id), trackChanges);
        }
    }
}
