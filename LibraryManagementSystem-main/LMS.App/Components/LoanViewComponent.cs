using Microsoft.AspNetCore.Mvc;
using LMS.Services.Contracts;
using Microsoft.AspNetCore.Identity;
using LMS.Entities.Models;
using LMS.App.Models;
using System.Security.Claims;

namespace LMS.App.Components
{
    public class LoanViewComponent : ViewComponent
    {
        private readonly IServiceManager _manager;
        private readonly UserManager<ApplicationUser> _userManager;
        public LoanViewComponent(IServiceManager manager, UserManager<ApplicationUser> userManager)
        {
            _manager = manager;
            _userManager = userManager;
        }
        public async Task<IViewComponentResult> InvokeAsync(BookListViewModel model)
        {
            ApplicationUser user = null;
            var currentUser = HttpContext.User;
            if (currentUser.Identity.IsAuthenticated)
            {
                var userId = currentUser.FindFirst(ClaimTypes.NameIdentifier).Value;
                user = await _userManager.FindByIdAsync(userId);
            }

            //var _user = await _manager.ApplicationUserService.GetOneUser(userName);
            return View(new UserBook() { Model = model, User = user});
        }
    }
}
