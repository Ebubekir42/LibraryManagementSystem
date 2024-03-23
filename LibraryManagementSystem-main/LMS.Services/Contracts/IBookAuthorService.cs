using LMS.Entities.Models;
using LMS.Entities.Dtos;

namespace LMS.Services.Contracts
{
    public interface IBookAuthorService
    {
        IEnumerable<BookAuthor> GetAllBookAuthors(bool trackChanges);
        IEnumerable<BookAuthor> GetAllBookAuthorsByAuthor(int authorId, bool trackChanges);
        IEnumerable<BookAuthor> GetOneBookAuthorsByBook(int bookId, bool trackChnges);
        void UpdateOneBookAuthor(BookDtoForUpdate bookDto);

    }
}
