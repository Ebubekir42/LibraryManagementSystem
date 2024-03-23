using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using LMS.Services.Contracts;
using LMS.Entities.RequestParameters;
using LMS.App.Models;
using LMS.Entities.Dtos;
using Microsoft.AspNetCore.Mvc.Rendering;
using LMS.Entities.Models;

namespace LMS.App.Areas.Personel.Controllers
{
    [Area("Personel")]
    [Authorize(Roles = "Personel")]
    public class BookController : Controller
    {
        private readonly IServiceManager _manager;
        public BookController(IServiceManager manager)
        {
            _manager = manager;
        }
        public IActionResult Index([FromQuery] BookRequestParameter b)
        {
            ViewData["Title"] = "Kitaplar";
            var books = _manager.BookService.GetAllBooks(false);
            var loans = _manager.LoanService.GetAllLoans(false);
            var categories = _manager.CategoryService.GetAllCategories(false);
            //var pagination = new Pagination()
            //{
            //    CurrentPage = b.PageNumber,
            //    ItemsPerPage = b.PageSize,
            //    TotalItems = books.Count()
            //};
            return View(new BookListViewModel()
            {
                Books = books,
                Loans = loans,
                Categories = categories
            });
        }
        public IActionResult Create([FromQuery] BookRequestParameterForInsertion b)
        {

            BookDtoForInsertion bookDto = new BookDtoForInsertion();
            bookDto.MediaTypeId = b.MediaType;
            ViewBag.MediaTypes = GetMediaTypesSelectList(b.MediaType);
            ViewBag.ContentTypes = GetContentTypesSelectList();
            ViewBag.CarrierTypes = GetCarrierTypesSelectList(b.MediaType);
            ViewBag.Languages = GetLanguagesSelectList();
            ViewBag.Formats = GetFormatsSelectList();
            ViewBag.Categories = GetCategoriesSelectList();
            ViewBag.Authors = GetAuthorsSelectList();
            TempData["info"] = "Lütfen alanları doldurun.";
            return View(bookDto);
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromForm] BookDtoForInsertion bookDto)
        {
            if (bookDto.Title is null)
                ModelState.AddModelError("Error", "Lütfen kitap başlığını girin.");
            if (bookDto.AuthorIds is null)
                ModelState.AddModelError("Error", "Lütfen en az bir yazar seçmelisin.");
            if (bookDto.ISBN_No is null)
                ModelState.AddModelError("Error", "Lütfen ISBN numarasını girin.");
            else if (!bookDto.ISBN_No.Count().Equals(13))
                ModelState.AddModelError("Error", "Lütfen 13 haneli bir ISBN numarası girin.");
            else
            {
                foreach (var character in bookDto.ISBN_No)
                {
                    if (character >= '0' && character <= '9')
                    {

                    }
                    else
                    {
                        ModelState.AddModelError("Error", "Lütfen geçerli bir ISBN numarası girin.");
                    }
                }
            }
            if (bookDto.Yayinlayan is null)
                ModelState.AddModelError("Error", "Lütfen yayınlayanı girin.");
            if (bookDto.Yayin_Yeri is null)
                ModelState.AddModelError("Error", "Lütfen yayın yerini girin.");
            if (bookDto.Yayin_Tarihi is null)
                ModelState.AddModelError("Error", "Lütfen yayın tarihi girin.");
            if (ModelState.IsValid)
            {
                bookDto.Kopya = "k.1";
                _manager.BookService.CreateOneBook(bookDto);
                TempData["success"] = $"{bookDto.Title} has been created";
                return RedirectToAction("Index");
            }
            return View();
        }

        public IActionResult Update([FromRoute(Name = "id")] int id)
        {
            ViewBag.Categories = GetCategoriesSelectList();
            ViewBag.Authors = GetAuthorsSelectList();
            var bookDto = _manager.BookService.GetOneBookForUpdate(id, false);
            IEnumerable<BookAuthor> bookAuthors = _manager.BookAuthorService.GetOneBookAuthorsByBook(id, false);
            List<int> authorIds = new List<int>();
            foreach (var bookAuthor in bookAuthors)
                authorIds.Add(bookAuthor.AuthorId);

            bookDto.AuthorIds = authorIds;
            ViewData["Title"] = bookDto.Title;
            return View(bookDto);
        }
        [HttpPost]
        public async Task<IActionResult> Update([FromForm] BookDtoForUpdate bookDto)
        {
            if (bookDto.Title is null)
                ModelState.AddModelError("Error", "Lütfen kitap başlığını girin.");
            else
            {
                IEnumerable<BookAuthor> bookAuthors = _manager.BookAuthorService.GetOneBookAuthorsByBook(bookDto.BookId, false);
                bookDto.BookAuthorIds = new List<int>();
                foreach (var bookAuthor in bookAuthors)
                    bookDto.BookAuthorIds.Add(bookAuthor.BookAuthorId);
                _manager.BookService.UpdateOneBook(bookDto);
                return RedirectToAction("Index");

            }
            return View();
        }
        public IActionResult Delete([FromRoute(Name = "id")] int id)
        {
            _manager.BookService.DeleteOneBook(id);
            //_manager.BookAuthorService.DeleteOneBookAuthorByBook(id);
            TempData["danger"] = "Kitap kaldırıldı";
            return RedirectToAction("Index");

        }
        public IActionResult Add([FromRoute(Name = "id")] int id)
        {
            var book = _manager.BookService.GetOneBook(id, false);
            _manager.BookService.AddAsCopy(book);
            return RedirectToAction("Index");
        }

        //private SelectList GetCategoriesSelectList(int id)
        //{
        //    Book? book = _manager.BookService.GetOneBook(id, false);
        //    return new SelectList(
        //        _manager.CategoryService.GetAllCategories(false),
        //        "CategoryId",
        //        "CategoryName",
        //        book.CategoryId.ToString());
        //}
        private SelectList GetCategoriesSelectList()
        {
            return new SelectList(
                _manager.CategoryService.GetAllCategories(false),
                "CategoryId",
                "CategoryName");
        }
        private SelectList GetMediaTypesSelectList(int id)
        {
            return new SelectList(
                _manager.MediaTypeService.GetAllMediaTypes(false),
                "MediaTypeId",
                "MediaName", id.ToString());
        }
        private SelectList GetContentTypesSelectList()
        {
            return new SelectList(
                _manager.ContentTypeService.GetAllContentTypes(false),
                "ContentTypeId",
                "ContentName");
        }
        private SelectList GetCarrierTypesSelectList(int mediaTypeId)
        {
            return new SelectList(
                _manager.CarrierTypeService.GetAllCarrierTypes(false).Where(c => c.MediaTypeId.Equals(mediaTypeId)),
                "CarrierTypeId",
                "CarrierName");
        }
        private SelectList GetFormatsSelectList()
        {
            return new SelectList(
                _manager.FormatService.GetAllFormats(false),
                "FormatId",
                "FormatName");
        }
        private SelectList GetLanguagesSelectList()
        {
            return new SelectList(
                _manager.LanguageService.GetAllLanguages(false),
                "LanguageId",
                "Name");
        }
        //private SelectList GetAuthorsSelectList(int id)
        //{
        //    var authorId = _manager.BookAuthorService.GetOneBookAuthorByBook(id, false).AuthorId;
        //    var author = _manager.AuthorService.GetOneAuthor(authorId, false);
        //    return new SelectList(
        //        _manager.AuthorService.GetAllAuthors(false),
        //        "AuthorId",
        //        "FullName",
        //        author.AuthorId.ToString());
        //}
        private SelectList GetAuthorsSelectList()
        {
            return new SelectList(
                _manager.AuthorService.GetAllAuthors(false),
                "AuthorId",
                "FullName");
        }
    }
}
