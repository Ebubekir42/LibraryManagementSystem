using LMS.Entities.Models;
using LMS.Repositories.Contracts;

namespace LMS.Repositories
{
    public class BookRepository : RepositoryBase<Book>, IBookRepository
    {
        public BookRepository(RepositoryContext context) : base(context)
        {
        }
        public void CreateBookAuthor(Book book)
        {
            _context.AddRange(book.BookAuthors);
        }
        public void UploadBookAuthor(Book book)
        {
            _context.UpdateRange(book.BookAuthors);
        }

        public void CreateOneBook(Book book)
        {
            Create(book);
            _context.SaveChanges();
        }
        public void DeleteOneBook(Book book)
        {
            Remove(book);
            _context.SaveChanges();
        } 
        public IQueryable<Book> GetAllBooks(bool trackChanges) => FindAll(trackChanges);
        public Book? GetOneBook(int id, bool trackChanges)
        {
            return FindByCondition(b => b.BookId.Equals(id), trackChanges);
        }
        public void UpdateOneBook(Book book) => Update(book);
        public void LossTheBook(int bookId)
        {
            var book = GetOneBook(bookId, true);
            book.isLoss = true;

        }
    }
}
