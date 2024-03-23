using LMS.Entities.Models;
using LMS.Repositories.Contracts;

namespace LMS.Repositories
{
    public class BookAuthorRepository : RepositoryBase<BookAuthor>, IBookAuthorRepository
    {
        public BookAuthorRepository(RepositoryContext context) : base(context)
        {
        }
        public IQueryable<BookAuthor> GetAllBookAuthors(bool trackChanges) => FindAll(trackChanges);


        public BookAuthor? GetOneBookAuthorByBook(int bookid, bool trackChanges)
        {
            return FindByCondition(b => b.BookId.Equals(bookid), trackChanges);
        }
        public void DeleteBookAuthorByIds(List<int> bookAuthorIds)
        {
            foreach(var bookAuthorId in bookAuthorIds)
            {
                var bookAuthor = GetOneBookAuthor(bookAuthorId, false);
                _context.Remove(bookAuthor);
            }
            _context.SaveChanges();
        }

        public BookAuthor? GetOneBookAuthor(int bookAuthorId, bool trackChanges)
        {
            return FindByCondition(b => b.BookAuthorId.Equals(bookAuthorId), trackChanges);
        }
    }
}
