using LMS.Entities.Models;
using LMS.Services.Contracts;
using LMS.Repositories.Contracts;
using LMS.Entities.Dtos;
using AutoMapper;

namespace LMS.Services
{
    public class AuthorManager : IAuthorService
    {
        private readonly IRepositoryManager _manager;
        private readonly IMapper _mapper;
        public AuthorManager(IRepositoryManager manager, IMapper mapper)
        {
            _manager = manager;
            _mapper = mapper;
        }
        public void CreateOneAuthor(AuthorDtoForInsertion authorDto)
        {
            var author = _mapper.Map<Author>(authorDto);
            _manager.Author.CreateOneAuthor(author);
            _manager.Save();
        }

        public void DeleteOneAuthor(int id)
        {
            Author? author = GetOneAuthor(id, false);
            if (author is not null)
            {
                _manager.Author.DeleteOneAuthor(author);
                _manager.Save();
            }
        }

        public IEnumerable<Author> GetAllAuthors(bool trackChanges)
        {
            return _manager.Author.GetAllAuthors(trackChanges);
        }

        public Author? GetOneAuthor(int id, bool trackChanges)
        {
            Author? author = _manager.Author.GetOneAuthor(id, trackChanges);
            if (author is null)
                throw new Exception("Author Not Found");
            return author;
        }

        public void UpdateOneAuthor(AuthorDtoForUpdate authorDto)
        {
            var author = _mapper.Map<Author>(authorDto);
            _manager.Author.UpdateOneAuthor(author);
            _manager.Save();
        }
        public AuthorDtoForUpdate GetOneAuthorForUpdate(int authorId, bool trackChanges)
        {
            var author = _manager.Author.GetOneAuthor(authorId, trackChanges);
            var authorDto = _mapper.Map<AuthorDtoForUpdate>(author);
            return authorDto;
        }
    }
}
