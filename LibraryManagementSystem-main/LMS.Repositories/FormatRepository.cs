using LMS.Entities.Models;
using LMS.Repositories.Contracts;

namespace LMS.Repositories
{
    public class FormatRepository : RepositoryBase<Format>, IFormatRepository
    {
        public FormatRepository(RepositoryContext context) : base(context)
        {
        }

        public IQueryable<Format> GetAllFormats(bool trackChanges) => FindAll(trackChanges);
        public Format GetFormat(int id, bool trackChanges)
        {
            return FindByCondition(x => x.FormatId.Equals(id), trackChanges);
        }
    }
}
