using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using LMS.Entities.Models;
using LMS.Services.Contracts;
using LMS.App.Models;

namespace LMS.App.Controllers
{
    public class HomeController : Controller
    {
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly IServiceManager _manager;
        public HomeController(SignInManager<ApplicationUser> signInManager, IServiceManager manager)
        {
            _signInManager = signInManager;
            _manager = manager;
        }
        public async Task<IActionResult> Index()
        {
            //ViewData["Title"] = "Anasayfa";
            //var per = await _manager.ApplicationUserService.GetOneUserByUserName("19046446116");
            //if (per is not null)
            //{
            //    await _signInManager.SignOutAsync();
            //    if ((await _signInManager.PasswordSignInAsync(per, "Admin+123456", false, false)).Succeeded)
            //    {
            //        return RedirectToAction("Index", "Dashboard", new { area = "Admin" });
            //    }
            //}
            return View();
        }
        public IActionResult Anasayfa()
        {
            var books = _manager.BookService.GetAllBooks(false).OrderByDescending(x => x.BookId).Take(5).ToList();
            var books_ = _manager.BookService.GetAllBooks(false);
            List<BookOduncSayisi> BookOdunc = new List<BookOduncSayisi>();
            foreach(var book in books_)
            {
                BookOdunc.Add(new BookOduncSayisi() { Book = book, sayi = _manager.LoanService.GetAllLoans(false).Where(x => x.BookId.Equals(book.BookId)).Count() });
            }
            List<BookOduncSayisi> bookOdunc = BookOdunc.OrderByDescending(x => x.sayi).Take(5).ToList(); 
            return View(new AnasayfaBook() { Books = books, BookOduncSayisilar = bookOdunc});
        }
        public IActionResult Hakkimizda()
        {
            return View();
        }
    }
}
