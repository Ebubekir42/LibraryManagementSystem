using LMS.Entities.Models;

namespace LMS.Repositories.Contracts
{
    public interface IBookRepository : IRepostioryBase<Book>
    {
        IQueryable<Book> GetAllBooks(bool trackChanges);
        Book? GetOneBook(int id, bool trackChanges);
        void CreateOneBook(Book book);
        void UpdateOneBook(Book book);
        void DeleteOneBook(Book book);
        void CreateBookAuthor(Book book);
        void UploadBookAuthor(Book book);
        void LossTheBook(int bookId);


    }
}
