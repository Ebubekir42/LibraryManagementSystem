using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using LMS.Services.Contracts;
using LMS.Entities.Models;
using LMS.App.Infrastructure.Extensions;
using LMS.App.Models;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace LMS.App.Pages
{
    public class LoanBookModel : PageModel
    {
        private readonly IServiceManager _manager;
        private readonly UserManager<ApplicationUser> _userManager;
        public Book Book { get; set; }
        public ApplicationUser User { get; set; }
        public LoanBookModel(IServiceManager manager, Book book, ApplicationUser user, UserManager<ApplicationUser> userManager)
        {
            _manager = manager;
            Book = book;
            User = user;
            _userManager = userManager;
        }
        public void OnGet()
        {
            
        }
        public async Task<IActionResult> OnPost(int id)
        {
            Book book = _manager.BookService.GetOneBook(id, false);
            HttpContext.Session.SetJson<Book>("book", book);
            ApplicationUser user = null;
            var currentUser = HttpContext.User;
            if (currentUser.Identity.IsAuthenticated)
            {
                var userId = currentUser.FindFirst(ClaimTypes.NameIdentifier).Value;
                user = await _userManager.FindByIdAsync(userId);
            }
            HttpContext.Session.SetJson<ApplicationUser>("user", user);
            return RedirectToPage();
        }
    }
}
