using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using LMS.Services.Contracts;
using LMS.Entities.RequestParameters;
using LMS.App.Models;
using LMS.Entities.Dtos;
using LMS.Entities.Models;
namespace LMS.App.Areas.Personel.Controllers
{
    [Area("Personel")]
    [Authorize(Roles = "Personel")]
    public class AuthorController : Controller
    {
        private readonly IServiceManager _manager;
        public AuthorController(IServiceManager manager)
        {
            _manager = manager;
        }
        public IActionResult Index([FromQuery] AuthorRequestParameter a)
        {
            ViewData["Title"] = "Yazarlar";
            var authors = _manager.AuthorService.GetAllAuthors(false);
            //var pagination = new Pagination()
            //{
            //    CurrentPage = a.PageNumber,
            //    ItemsPerPage = a.PageSize,
            //    TotalItems = authors.Count()
            //};
            return View(new AuthorListViewModel()
            {
                Authors = authors
            });
        }
        public IActionResult Create()
        {
            TempData["info"] = "Lütfen alanları doldurun.";
            return View();
        }
        [HttpPost]
        public IActionResult Create([FromForm] AuthorDtoForInsertion authorDto)
        {
            if (authorDto.FirstName is null)
                ModelState.AddModelError("Error", "Lütfen adı girin.");
            if (authorDto.LastName is null)
                ModelState.AddModelError("Error", "Lütfen soyadı girin.");
            if (ModelState.IsValid)
            {
                _manager.AuthorService.CreateOneAuthor(authorDto);
                TempData["success"] = $"{authorDto.FirstName} {authorDto.LastName} isimli bir yazar eklendi.";
                return RedirectToAction("Index");
            }
            return View();
        }
        public IActionResult Update([FromRoute(Name = "id")] int id)
        {
            var authorDto = _manager.AuthorService.GetOneAuthorForUpdate(id, false);
            ViewData["Title"] = authorDto.FirstName + " " + authorDto.LastName;
            return View(authorDto);
        }
        [HttpPost]
        public IActionResult Update([FromForm] AuthorDtoForUpdate authorDto)
        {
            if (authorDto.FirstName is null)
                ModelState.AddModelError("Error", "Lütfen adı girin.");
            if (authorDto.LastName is null)
                ModelState.AddModelError("Error", "Lütfen soyadı girin.");
            if (ModelState.IsValid)
            {
                _manager.AuthorService.UpdateOneAuthor(authorDto);
                return RedirectToAction("Index");
            }
            return View();
        }
        public IActionResult Delete([FromRoute(Name = "id")] int id)
        {
            List<BookAuthor> bookAuthors = new List<BookAuthor>();
            var _bookAuthors = _manager.BookAuthorService.GetAllBookAuthors(false).Where(b => b.AuthorId.Equals(id));
            foreach (var bookAuthor in _bookAuthors)
                bookAuthors.Add(bookAuthor);
            _manager.AuthorService.DeleteOneAuthor(id);
            _manager.BookService.DeleteAllBooksByBookAuthors(bookAuthors);
            TempData["danger"] = "Seçilen yazar kaldırıldı.";
            return RedirectToAction("Index");
        }
    }
}
