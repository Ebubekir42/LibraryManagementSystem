using LMS.Entities.RequestParameters;
using LMS.App.Models;
using LMS.Entities.Dtos;
using Microsoft.AspNetCore.Identity;
using LMS.Entities.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using LMS.Services.Contracts;

namespace LMS.App.Areas.User.Controllers
{
    [Area("User")]
    [Authorize(Roles = "User")]
    public class UserController : Controller
    {
        private readonly IServiceManager _manager;
        public UserController(IServiceManager manager)
        {
            _manager = manager;
        }
        public async Task<IActionResult> Update(string id)
        {
            //var userDto = await _manager.ApplicationUserService.GetOneUserDtoForUpdate(id);
            var userName = User.Identity.Name;
            var user = await _manager.ApplicationUserService.GetOneUserByUserName(userName);
            return View(user);
        }
    }
}
