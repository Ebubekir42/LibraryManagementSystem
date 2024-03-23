using LMS.Entities.Models;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using LMS.Services.Contracts;
using Microsoft.AspNetCore.Identity;

namespace LMS.App.Components
{


    public class FineViewComponent : ViewComponent
    {
        private readonly IServiceManager _manager;
        private readonly UserManager<ApplicationUser> _userManager;

        public FineViewComponent(IServiceManager manager, UserManager<ApplicationUser> userManager)
        {
            _manager = manager;
            _userManager = userManager;
        }
        public async Task<string> InvokeAsync()
        {
            //ApplicationUser user = null;
            //var currentUser = HttpContext.User;
            //if (currentUser.Identity.IsAuthenticated)
            //{
            //    var userId = currentUser.FindFirst(ClaimTypes.NameIdentifier).Value;
            //    user = await _userManager.FindByIdAsync(userId);
            //}
            var userName = User.Identity.Name;
            var user = await _manager.ApplicationUserService.GetOneUserByUserName(userName);
            var fine = _manager.FineService.GetFine(user.Id, false);
            return fine.Quantity.ToString();
        }
    }
}
