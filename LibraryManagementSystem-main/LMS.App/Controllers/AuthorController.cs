using Microsoft.AspNetCore.Mvc;
using LMS.Services.Contracts;
using LMS.App.Models;
using LMS.Entities.Models;

namespace LMS.App.Controllers
{
    public class AuthorController : Controller
    {
        private readonly IServiceManager _manager;
        public AuthorController(IServiceManager manager)
        {
            _manager = manager;
        }
        public IActionResult Index()
        {
            ViewData["Title"] = "Yazarlar";
            List<AuthorBook> authorBooks = new List<AuthorBook>();
            var authors = _manager.AuthorService.GetAllAuthors(false);
            foreach (var author in authors)
            {
                var bookAuthors = _manager.BookAuthorService.GetAllBookAuthorsByAuthor(author.AuthorId, false);
                List<Book> books = new List<Book>();
                foreach (var book in bookAuthors)
                    books.Add(_manager.BookService.GetOneBook(book.BookId, false));
                authorBooks.Add(new AuthorBook()
                {
                    Author = author,
                    Books = books
                });
            }
            return View(authorBooks);


            //var authors = _manager.AuthorService.GetAllAuthors(false);
            //return View(authors);
        }
    }
}
