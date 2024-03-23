using LMS.Entities.Models;
using LMS.Services.Contracts;
using LMS.Repositories.Contracts;
using LMS.Entities.Dtos;

namespace LMS.Services
{
    public class BookAuthorManager : IBookAuthorService
    {
        private readonly IRepositoryManager _manager;
        public BookAuthorManager(IRepositoryManager manager)
        {
            _manager = manager;
        }

        public IEnumerable<BookAuthor> GetAllBookAuthors(bool trackChanges) => _manager.BookAuthor.GetAllBookAuthors(trackChanges);

        public IEnumerable<BookAuthor> GetAllBookAuthorsByAuthor(int authorId, bool trackChanges)
        {
            var bookAuthors = _manager.BookAuthor.GetAllBookAuthors(false).Where(b => b.AuthorId.Equals(authorId));
            return bookAuthors;
        }
        public IEnumerable<BookAuthor> GetOneBookAuthorsByBook(int bookId, bool trackChnges)
        {
            var bookAuthor = _manager.BookAuthor.GetAllBookAuthors(false).Where(b => b.BookId.Equals(bookId));
            return bookAuthor;
        }
        public void UpdateOneBookAuthor(BookDtoForUpdate bookDto)
        {
            var bookAuthor = GetOneBookAuthorsByBook(bookDto.BookId, true);
            //bookAuthor.AuthorId = bookDto.AuthorId;
            _manager.Save();
        }

    }
}
