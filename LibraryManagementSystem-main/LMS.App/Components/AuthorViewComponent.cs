using Microsoft.AspNetCore.Mvc;
using LMS.Services.Contracts;
namespace LMS.App.Components
{
    public class AuthorViewComponent : ViewComponent
    {
        private readonly IServiceManager _manager;
        public AuthorViewComponent(IServiceManager manager)
        {
            _manager = manager;
        }
        public string Invoke(int bookId)
        {
            var bookAuthors = _manager.BookAuthorService.GetOneBookAuthorsByBook(bookId, false);
            string text = "";
            foreach (var bookAuthor in bookAuthors)
            {
                var author = _manager.AuthorService.GetOneAuthor(bookAuthor.AuthorId, false);
                text += author.FullName + ", ";
            }
            text = text.Remove(text.Count() - 2);
            return text;
        }
    }
}
