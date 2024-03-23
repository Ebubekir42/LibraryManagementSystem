using LMS.Repositories.Contracts;
using LMS.Entities.Models;

namespace LMS.Repositories
{
    public class AuthorRepository : RepositoryBase<Author>, IAuthorRepository
    {
        public AuthorRepository(RepositoryContext context) : base(context)
        {
        }

        public void CreateOneAuthor(Author author) => Create(author);
        public void DeleteOneAuthor(Author author) => Remove(author);
        public IQueryable<Author> GetAllAuthors(bool trackChanges) => FindAll(trackChanges);
        public Author? GetOneAuthor(int id, bool trackChanges)
        {
            return FindByCondition(a => a.AuthorId.Equals(id), trackChanges);
        }
        public void UpdateOneAuthor(Author author) => Update(author);
    }
}
