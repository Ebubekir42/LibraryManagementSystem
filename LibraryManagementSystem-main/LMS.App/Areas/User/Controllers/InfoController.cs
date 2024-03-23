using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using LMS.Services.Contracts;
namespace LMS.App.Areas.User.Controllers
{
    [Area("User")]
    [Authorize(Roles = "User")]
    public class InfoController : Controller
    {
        private readonly IServiceManager _manager;
        public InfoController(IServiceManager manager)
        {
            _manager = manager;
        }
        public async Task<IActionResult> Index()
        {
            var perId = User.Identity.Name;
            var per = await _manager.ApplicationUserService.GetOneUserByUserName(perId);
            return View(per);
        }
        public IActionResult Update()
        {
            return View();
        }
    }
}
