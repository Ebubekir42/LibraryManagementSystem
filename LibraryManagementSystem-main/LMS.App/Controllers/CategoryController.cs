using Microsoft.AspNetCore.Mvc;
using LMS.Services.Contracts;
using LMS.App.Models;
using LMS.Entities.Models;
namespace LMS.App.Controllers
{
    public class CategoryController : Controller
    {
        private readonly IServiceManager _manager;
        public CategoryController(IServiceManager manager)
        {
            _manager = manager;
        }
        public IActionResult Index()
        {
            ViewData["Title"] = "Kategoriler";
            List<CategoryBook> categoryBooks = new List<CategoryBook>();
            var categories = _manager.CategoryService.GetAllCategories(false);
            foreach (var category in categories)
            {
                IEnumerable<Book> books = _manager.BookService.GetAllBooksByCategory(category.CategoryId, false);
                categoryBooks.Add(new CategoryBook()
                {
                    Category = category,
                    Books = books
                });
            }
            return View(categoryBooks);
        }
    }
}
