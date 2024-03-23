using LMS.Entities.Models;
using LMS.Entities.Dtos;

namespace LMS.Services.Contracts
{
    public interface IAuthorService
    {
        IEnumerable<Author> GetAllAuthors(bool trackChanges);
        Author? GetOneAuthor(int id, bool trackChanges);
        void CreateOneAuthor(AuthorDtoForInsertion authorDto);
        void UpdateOneAuthor(AuthorDtoForUpdate authorDto);
        void DeleteOneAuthor(int id);
        AuthorDtoForUpdate GetOneAuthorForUpdate(int authorId, bool trackChanges);

    }
}
