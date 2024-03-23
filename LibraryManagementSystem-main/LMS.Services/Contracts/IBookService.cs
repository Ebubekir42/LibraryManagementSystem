using LMS.Entities.Models;
using LMS.Entities.Dtos;

namespace LMS.Services.Contracts
{
    public interface IBookService
    {
        IEnumerable<Book> GetAllBooks(bool trackChanges);
        Book? GetOneBook(int id, bool trackChanges);
        void CreateOneBook(BookDtoForInsertion book);
        void UpdateOneBook(BookDtoForUpdate bookDto);

        void DeleteOneBook(int id);
        void DeleteAllBooksByBookAuthors(IEnumerable<BookAuthor> bookAuthors);
        IEnumerable<Book> GetAllBooksByCategory(int categoryId, bool trackChanges);
        BookDtoForUpdate GetOneBookForUpdate(int bookId, bool trackChanges);
        void AddAsCopy(Book book);
        void LossTheBook(int bookId);


    }
}
