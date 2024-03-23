using LMS.Entities.Models;

namespace LMS.Repositories.Contracts
{
    public interface IBookAuthorRepository
    {
        BookAuthor? GetOneBookAuthorByBook(int bookid, bool trackChanges);
        BookAuthor? GetOneBookAuthor(int bookAuthorId, bool trackChanges);

        IQueryable<BookAuthor> GetAllBookAuthors(bool trackChanges);
        void DeleteBookAuthorByIds(List<int> bookAuthorIds);

    }
}
