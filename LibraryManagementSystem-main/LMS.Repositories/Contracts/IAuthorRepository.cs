using LMS.Entities.Models;

namespace LMS.Repositories.Contracts
{
    public interface IAuthorRepository : IRepostioryBase<Author>
    {
        IQueryable<Author> GetAllAuthors(bool trackChanges);
        Author? GetOneAuthor(int id, bool trackChanges);
        void CreateOneAuthor(Author author);
        void UpdateOneAuthor(Author author);
        void DeleteOneAuthor(Author author);
    }
}
